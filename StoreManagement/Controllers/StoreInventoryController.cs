using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StoreManagement.Dtos;
using StoreManagement.Interface;
using StoreManagement.Data.Model.StoreManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Reflection;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StoreInventoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IErrorLoggerFactory _createErrorLog;
        private readonly IActivityLoggerFactory _createActivityLog;

        public StoreInventoryController(IUnitOfWork unitOfWork, IMapper mapper, IErrorLoggerFactory errorLogger, IActivityLoggerFactory activityLogger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createErrorLog = errorLogger;
            _createActivityLog = activityLogger;
        }

        [HttpGet("GetProductList")]
        public async Task<ActionResult<List<StoreInventoryDto>>> GetProductList([FromQuery] StoreViewDto storeView)
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
                var errors = _createErrorLog.Create("User", DateTime.Now, "Error fetching data", "Store View");
                var errorData = _mapper.Map<ErrorLog>(errors);
                _unitOfWork.errorLogger.LogError(errorData);
                await _unitOfWork.Complete();
                return BadRequest("Product fetching failed: " + ex.Message.ToString());
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

                var activity = _createActivityLog.Create
                    ("User", DateTime.Now, $"added new product {newProduct.ProductName} in ", "Module");

                var activityLog = _mapper.Map<ActivityLog>(activity);

                _unitOfWork.activityLogger.LogActivity(activityLog);
                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                var errors = _createErrorLog.Create
                    ("Username", DateTime.Now, $"Update error: {ex.Message}", "Products Module");

                var errorData = _mapper.Map<ErrorLog>(errors);
                _unitOfWork.errorLogger.LogError(errorData);
                await _unitOfWork.Complete();
                return BadRequest("Adding of product failed: " + ex.Message.ToString());
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
                    return StatusCode(209); //209 = good response but duplicate
                }
                _unitOfWork.storeInventory.UpdateProduct(updateProduct);

                var activity = _createActivityLog.Create
                    ("User", DateTime.Now, $"Updating of product failed: {updateProduct.ProductName} in ", "Products module");
                var activityLog = _mapper.Map<ActivityLog>(activity);

                _unitOfWork.activityLogger.LogActivity(activityLog);

                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                var errors = _createErrorLog.Create("User", DateTime.Now, $"Updating of product failed: {ex.Message} in ", "Products module");
                var errorData = _mapper.Map<ErrorLog>(errors);
                _unitOfWork.errorLogger.LogError(errorData);
                await _unitOfWork.Complete();
                return BadRequest("Updating of product failed: " + ex.Message.ToString());
            }
        }

        [HttpPost("RemoveProduct")]
        public async Task<ActionResult> RemoveProduct([FromBody] StoreInventoryDto product)
        {
            try
            {
                var activity = _createActivityLog.Create("User", DateTime.Now, $"Updating of product failed: {product.ProductName} in ", "Products module");


                var activityLog = _mapper.Map<ActivityLog>(activity);

                _unitOfWork.activityLogger.LogActivity(activityLog);

                var deleteProduct = _mapper.Map<Product>(product);
                _unitOfWork.storeInventory.DeleteProduct(deleteProduct);
                await _unitOfWork.Complete();
                return Ok(200);
            }
            catch (Exception ex)
            {
                var errors = _createErrorLog.Create("User", DateTime.Now, $"Deletion of product failed: {ex.Message}", "Products Module");

                var errorData = _mapper.Map<ErrorLog>(errors);

                _unitOfWork.errorLogger.LogError(errorData);
                await _unitOfWork.Complete();
                return BadRequest("Deletion of product failed..." + ex.Message.ToString());
            }
        }

    }
}