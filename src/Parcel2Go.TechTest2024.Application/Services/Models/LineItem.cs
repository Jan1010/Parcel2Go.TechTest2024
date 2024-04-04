using Parcel2Go.TechTest2024.Domain.ProductEntity;

namespace Parcel2Go.TechTest2024.Application.Services.Models
{
    internal class LineItem
    {
        public Product Product { get; }
        public int Quantity { get; internal set; }
        public int TotalPrice => Quantity * Product.Price;
        public int? PromoptionTotalPrice { get; internal set; }

        public LineItem(Product product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}