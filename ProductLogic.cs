using System.Linq;

namespace Store.App
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;

        private Dictionary<string, DogLeash> _dogLeash;

        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>()
            {
                new DogLeash
                {
                    Description = "A nylon dog leash.",
                    LengthInches = 30,
                    Material = "Nylon",
                    Name = "Nylon Dog Leash",
                    Price = 15.00m,
                    Quantity = 0
                },

                new CatFood
                {
                    Description = "A box of cans of healthy non-dry cat food.",
                    Name = "Meow Chow",
                    Price = 10.99m,
                    Quantity = 15,
                    KittenFood = false
                },

                new DryCatFood
                {
                    Description = "A bag of healthy dry cat food.",
                    Name = "Crunch Bunch",
                    Price = 12.99m,
                    Quantity = 12,
                    KittenFood = true
                }

            };
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            if (product is DogLeash)
            {
                _dogLeash.Add(product.Name!, product as DogLeash);
            }
            else if (product is CatFood)
            {
                _catFood.Add(product.Name!, product as CatFood);
            }
            else
            {
                _products.Add(product);
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                return _dogLeash[name];
            }
            catch (KeyNotFoundException ex)
            {
                throw new Exception($"DogLeash with name {name} not found. {ex.Message}");
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
            var prod = _products.Where(product => product.Quantity > 0)
                .Select(product => product.Name)
                .ToList();

            return prod!;
        }

    }
}