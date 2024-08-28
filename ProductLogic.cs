using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.App
{
    
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;

        private Dictionary<string, DogLeash> _dogLeash;

        private Dictionary<string, CatFood> _catFood;
        private Dictionary<string, DryCatFood> _dryCatFood;

        
        /// <summary>
        /// Constructs a new instance of the ProductLogic class.
        /// 
        /// This class is responsible for managing the products in the pet store.
        /// It initializes a list of products, and a dictionary of products for each type.
        /// 
        /// The list of products is initialized with the following products:
        /// 
        /// - A DogLeash product named "NDL" with a price of $15.00 and a quantity of 0.
        /// - A CatFood product named "MeowChow" with a price of $10.99 and a quantity of 15.
        /// - A DryCatFood product named "CrunchBunch" with a price of $12.99 and a quantity of 12.
        /// </summary>
        public ProductLogic()
        {
            _products = new List<Product>()
            {
                new DogLeash
                {
                    Description = "A nylon dog leash.",
                    LengthInches = 30,
                    Material = "Nylon",
                    Name = "NDL",
                    Price = 15.00m,
                    Quantity = 0
                },

                new CatFood
                {
                    Description = "A box of cans of healthy non-dry cat food.",
                    Name = "MeowChow",
                    Price = 10.99m,
                    Quantity = 15,
                    KittenFood = false
                },

                new DryCatFood
                {
                    Description = "A bag of healthy dry cat food.",
                    Name = "CrunchBunch",
                    Price = 12.99m,
                    Quantity = 12,
                    KittenFood = true
                }

            };
            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
            _dryCatFood = new Dictionary<string, DryCatFood>();

            foreach (var product in _products)
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
                    _dryCatFood.Add(product.Name!, product as DryCatFood);
                }
            }
        }

        
        /// <summary>
        /// Adds a product to the pet store.
        /// </summary>
        /// <param name="product">The product to be added.</param>
        /// <remarks>
        /// This method adds a product to the pet store. It first checks if the product is a 
        /// dog leash, cat food, or dry cat food. If it is a dog leash, it adds it to the 
        /// dictionary of dog leashes. If it is cat food, it adds it to the dictionary of 
        /// cat foods. Otherwise, it adds it to the list of products.
        /// </remarks>
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

        
        /// <summary>
        /// Returns a list of all products in the pet store.
        /// </summary>
        /// <returns>A list of all products in the pet store.
        /// with their product descriptions, names, prices, and quantities.
        /// <returns>// /// /// </returns
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        
        /// <summary>
        /// Returns the dog leash with the specified name.
        /// Throws an exception if no dog leash with the specified name is found.
        /// </summary>
        /// <param name="name">The name of the dog leash to return.</param>
        /// <returns>The dog leash with the specified name.</returns>
        /// <exception cref="KeyNotFoundException">The specified name does not match any dog leash in the pet store.</exception>
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

        
        /// <summary>
        /// Returns a list of names of all products in the pet store that are in stock.
        /// </summary>
        /// <returns>A list of names of all products in the pet store that are in stock.</returns>
        public List<string> GetOnlyInStockProducts()
        {
            var prod = _products.Where(product => product.Quantity > 0)
                .Select(product => product.Name)
                .ToList();

            return prod!;
        }

        
        /// <summary>
        /// Returns the total price of all products in the pet store that are in stock.
        /// </summary>
        /// <returns>The total price of all products in the pet store that are in stock.</returns>
        public decimal GetTotalPriceOfInventory()
        {
            return _products.InStock().Select(x => x.Price).Sum();
        }

    }
}