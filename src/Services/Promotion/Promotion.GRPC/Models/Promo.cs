using System;
using System.Collections.Generic;

namespace Promotion.GRPC.Models
{
    public class Promo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime From { get; set; }
        public int Percentage { get; set; }
        public int Duration { get; set; }
        public bool IsActive { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();
        public Promo()
        {

        }
    }
}
