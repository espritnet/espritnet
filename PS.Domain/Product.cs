using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Product: Concept
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        [MinLength(10)]
        [StringLength(25, ErrorMessage ="Longueur >25")]
        [Required(ErrorMessage ="Name required")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
      
        [DataType(DataType.Date),Display(Name="Production Date")]
        public DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }
        public IList<Provider> Providers { get; set; }
        public Category Category { get; set; }//propriété de navigation 
        //CategoryId
        public override void GetDetails()
        {
            //var provider = new Provider();
            //    provider.Affiche = delegate () { //
                    
            //                                     };
            //provider.Affiche();
            Console.WriteLine($"[{ProductId}, {Name}, {Description}, {Price}, {Quantity}, {DateCreated}]");
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("Je suis un produit");
        }
    }
}
