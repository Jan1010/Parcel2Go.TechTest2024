namespace Parcel2Go.TechTest2024.Domain.ProductEntity
{
    public class Product
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
