using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain
{
    public class Chemical: Product
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string LabName { get; set; }

        public override void GetMyType()
        {
            Console.WriteLine("Je suis un produit Chemic");
        }
    }
}
