using System;

namespace backend_labo01_wijn.Models
{
    public class Wine
    {
        public int WineId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Grapes { get; set; }
    }
}
