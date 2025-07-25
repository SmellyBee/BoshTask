﻿namespace BoshAPI.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public decimal Price { get; set; }

        public List<Image> Images { get; set; }
        public TechsSpec TechsSpec { get; set; }
        
    }
}
