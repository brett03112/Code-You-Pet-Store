

namespace Store.App;

internal interface IProductLogic
{
    public void AddProduct(Product product);
    
    public List<Product> GetAllProducts();

    public DogLeash GetDogLeashByName(string name);

    public List<string> GetOnlyInStockProducts();
}