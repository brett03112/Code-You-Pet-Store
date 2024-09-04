

namespace Store.App;

internal interface IProductLogic
{
    
    public void AddProduct(Product product);
    
    public List<Product> GetAllProducts();

    public T GetProductByName<T>(string name) where T : Product;

    public List<string> GetOnlyInStockProducts();

    public decimal GetTotalPriceOfInventory();
}