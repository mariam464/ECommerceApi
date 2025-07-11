using ECommerceApi.Models;

namespace ECommerceApi.DTO
{
    public class CategoryInfoDto
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public dynamic Products { get; set; }

        
    }
}
