using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Biological: Product
    {
        public string Herbs { get; set; }

        public override void GetMyType()
        {
            Console.WriteLine("Je suis un produit Bio");
        }

        public override void GetDetails()
        {
            base.GetDetails();
            Console.WriteLine($"-[{Herbs}]");
        }
    }
}
