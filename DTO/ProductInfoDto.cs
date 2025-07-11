using ECommerceApi.Models;


namespace ECommerceApi.DTO
{
    public class ProductInfoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvaliable { get; set; }
        public string CategoryName { get; set; }
    }
}
