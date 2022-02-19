using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Category: Concept
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; }
        public override void GetDetails()
        {
            Console.WriteLine($"[{CategoryId},{Name}]");
        }
    }
}
