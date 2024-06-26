using File_Backup_Service.Repositories;
using StoreManagement.Data.Model.StoreManagement;
using StoreManagement.Dtos;

namespace StoreManagement.Interface
{
    public interface IStoreInventory 
    {
        public Task<List<Product>> GetProductList(StoreViewDto storeView);
        public bool DuplicateCheck(Product product);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(Product product);
        public  Task<List<ProductCategory>> GetCategory();





    }
}