using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Model.StoreManagement;
using StoreManagement.Dtos;
using StoreManagement.Interface;

namespace StoreManagement.Repositories;
public class StoreInventoryRepo : IStoreInventory
{
   private readonly StoreManagementContext _context;

    public StoreInventoryRepo(StoreManagementContext context)
    {
        _context = context;
    }

    public async Task<List<ProductCategory>> GetCategory()
    {
        var categories = _context.ProductCategories.ToList();
        return categories;
    }

    public async Task<List<Product>> GetProductList(StoreViewDto product)
    {
        var isAvailable = product.IsAvailable == "True" ? true : false;

        var productList = _context.Products.OrderByDescending(x => x.Id).ToList();

        if(product.ProductName != null)
        {
            productList = productList.Where(x => x.ProductName == product.ProductName).ToList();
        }
        if (product.IsAvailable != null)
        {
            productList = productList.Where(x => x.IsAvailable == isAvailable).ToList();
        }
        if (product.CategoryId != null)
        { 
            productList = productList.Where(x => x.CategoryId == Convert.ToInt32(product.CategoryId)).ToList();
        }

        return productList;
    }

    public bool DuplicateCheck(Product product)
    {
        var duplicateChecker = _context.Products.FirstOrDefault(x => x.ProductName == product.ProductName);
        if (duplicateChecker != null)
        {
            return true;
        }
        return false;
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
    }

}