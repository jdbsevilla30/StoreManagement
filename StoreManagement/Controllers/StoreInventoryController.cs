using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Dtos;
using StoreManagement.Interface;
using StoreManagement.Data.Model.StoreManagement;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreInventoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreInventoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetProductList")]
        public async Task<ActionResult<List<StoreInventoryDto>>> GetProductList([FromQuery]StoreViewDto storeView)
        {
            try
            {
                var item = await _unitOfWork.storeInventory.GetProductList(storeView);
                var category = await _unitOfWork.storeInventory.GetCategory();

                var products = (from productDetails in item
                                  join productCategory in category on productDetails.CategoryId equals productCategory.CategoryId
                                  select new StoreInventoryDto
                                  {
                                      Id = productDetails.Id,
                                      ProductName = productDetails.ProductName,
                                      CategoryId = productCategory.CategoryId,
                                      Category = productCategory.Category,
                                      Description = productDetails.Description,
                                      IsAvailable = productDetails.IsAvailable,
                                      Price = productDetails.Price,
                                      Quantity = productDetails.Quantity,    
                                  }).ToList();

                return Ok(products);



                
            }
            catch (Exception ex)
            {
                //add logging of bad requests here
                return BadRequest("Product fetching failed..." + ex.Message.ToString());
            }
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] StoreInventoryDto product)
        {
            try
            {
                var newProduct = _mapper.Map<Product>(product);
                var isDuplicateProduct = _unitOfWork.storeInventory.DuplicateCheck(newProduct);
                if (isDuplicateProduct)
                {
                    return StatusCode(209);
                }

                _unitOfWork.storeInventory.AddProduct(newProduct);
                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                //add logging of bad requests here
                return BadRequest("Adding of product failed..." + ex.Message.ToString());
            }
        }

        [HttpPost("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct([FromBody] StoreInventoryDto product)
        {
            try
            {
                var updateProduct = _mapper.Map<Product>(product);
                var isDuplicateProduct = _unitOfWork.storeInventory.DuplicateCheck(updateProduct);
                if (isDuplicateProduct)
                {
                    return StatusCode(209);
                }
                _unitOfWork.storeInventory.UpdateProduct(updateProduct);
                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest("Uppdating of product failed..." + ex.Message.ToString());

            }
        }

        [HttpPost("RemoveProduct")]
        public async Task<ActionResult> RemoveProduct([FromBody] StoreInventoryDto product)
        {
            try
            {
                var deleteProduct = _mapper.Map<Product>(product);
                _unitOfWork.storeInventory.DeleteProduct(deleteProduct);
                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                return BadRequest("Deletion of product failed..." + ex.Message.ToString());

            }
        }

    }
}