using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW12.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Cost { get; set; }
        public virtual Basket Basket { get; set; }
    }
}
