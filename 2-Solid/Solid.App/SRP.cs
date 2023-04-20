namespace Solid.App.SRP
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private static List<Product> productList = new();

        public List<Product> GetProducts => productList;

        public Product()
        {
            productList = new()
            {
                new() { Id = 1, Name = "Kalem 1" },
                new() { Id = 2, Name = "Kalem 2" },
                new() { Id = 3, Name = "Kalem 3" },
                new() { Id = 4, Name = "Kalem 4" },
                new() { Id = 5, Name = "Kalem 5" }
            };
        }

        public void SaveOrUpdate(Product product)
        {
            bool hasProduct = productList.Any(p => p.Id == product.Id);

            if (!hasProduct)
                productList.Add(product);
            else
            {
                int index = productList.FindIndex(p => p.Id == product.Id);
                productList[index] = product;
            }
        }

        public void Delete(int id)
        {
            Product hasProduct = productList.Find(p => p.Id == id);
            if (hasProduct == null)
                throw new Exception("Ürün Bulunamadı");

            productList.Remove(hasProduct);
        }

        public void WriteToConsole()
        {
            productList.ForEach(p => Console.WriteLine($"{p.Id} - {p.Name}"));
        }
    }
}
