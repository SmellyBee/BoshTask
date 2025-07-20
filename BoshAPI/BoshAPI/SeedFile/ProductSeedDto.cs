namespace BoshAPI.SeedFile
{
    public class ProductSeedDto
    {
        public string name { get; set; }
        public decimal price { get; set; }
        public string shortDescription { get; set; }
        public string fullDescription { get; set; }
        public List<string> images { get; set; }
        public Dictionary<string, string> technicalSpecifications { get; set; }
    }
}
