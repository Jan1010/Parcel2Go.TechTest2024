namespace Parcel2Go.TechTest2024.Domain.PromotionEntity
{
    public class Promotion
    {
        public int Id { get; private set; }
        public string ProductId { get; private set; }
        public int Quantity { get; private set; }
        public int Price { get; private set; }

        public Promotion(int id, string productId, int quantity, int price)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }
    }
}
