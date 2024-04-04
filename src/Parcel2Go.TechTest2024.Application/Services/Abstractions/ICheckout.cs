namespace Parcel2Go.TechTest2024.Application.Services.Abstractions
{
    public interface ICheckout
    {
        Task Scan(string service, CancellationToken cancellationToken = default); // Adds a service to the checkout
        /// <summary>
        /// Returns total price
        /// </summary>
        /// <returns>Total price in minor currency units</returns>
        int GetTotalPrice(); // Calculates the total price, applying the best discount option
    }
}
