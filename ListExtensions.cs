
namespace Store.App;

internal static class ListExtensions
{
    
    /// <summary>
    /// Returns a new list of products in the original list that are in stock with a 
    /// quantity greater than zero. The type of the product must be a subclass of Product.
    /// </summary>
    /// <typeparam name="T">The type of the product, which must be a subclass of Product.</typeparam>
    /// <param name="list">The original list of products.</param>
    /// <returns>A new list of products in the original list that are in stock.</returns>
    public static List<T> InStock<T>(this List<T> list) where T: Product
    {
        return list.Where(x => x.Quantity > 0).ToList();
    }
}