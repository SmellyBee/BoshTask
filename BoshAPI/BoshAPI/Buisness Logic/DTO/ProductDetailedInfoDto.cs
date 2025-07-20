using BoshAPI.Entities;

namespace BoshAPI.Buisness_Logic.DTO
{
    public class ProductDetailedInfoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; }
        public TechSpecDto TechSpec { get; set; }
    }
}
