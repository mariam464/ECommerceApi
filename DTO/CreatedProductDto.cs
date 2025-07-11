namespace ECommerceApi.DTO
{
    public class CreatedProductDto

    {
        public string Name{ get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityAvaliable { get; set; }

        public int CategoryId{ get; set; }

    }
}
