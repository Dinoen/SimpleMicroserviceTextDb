using System.Text.Json;

namespace SimpleMicroservice.Services
{
    public class ProductService
    {
        private readonly string filePath = "products.txt";

        public string AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product is null.");
            }

            product.Id = GetNextProductId();
            var productJson = JsonSerializer.Serialize(product);
            File.AppendAllText(filePath, productJson + Environment.NewLine);

            return "Product added successfully.";
        }
        public string GetProducts()
        {
            var products = File.ReadAllLines(filePath);
            return JsonSerializer.Serialize(products);
        }

        public string GetProduct(int id) {
            var products = File.ReadAllLines(filePath);
            foreach (var product in products)
            {
                var productObj = JsonSerializer.Deserialize<Product>(product);
                if (productObj.Id == id)
                {
                    return JsonSerializer.Serialize(productObj);
                }
            }
            return null;
        }
        private int GetNextProductId()
        {
            var products = File.ReadAllLines(filePath);
            if (products.Length == 0)
            {
                return 1;
            }

            var maxId = products
                .Select(product => JsonSerializer.Deserialize<Product>(product).Id)
                .Max();

            return maxId + 1;
        }
    }
}
