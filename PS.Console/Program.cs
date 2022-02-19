using System;
using System.Collections.Generic;
using PS.Domain;
using PS.Service;

namespace PS.Console
{
    class Program121
    {



        public static void AfficheClient()
        {
            System.Console.WriteLine("Point Fonction");
        }

        public static void AfficheClient2()
        {
            System.Console.WriteLine("Point Fonction2");
        }
        public static void DemanderPrix(ref float newPrix)
        {
            newPrix = 0;
            while (newPrix <= 0)
            {
                System.Console.Write("Donner le prix: ");
                //variable implicitement typée
                var prix = System.Console.ReadLine();
                try
                {
                    newPrix = float.Parse(prix) * 0.9f;
                    //System.Console.WriteLine("Vous avez saisi le produit : "+ nom);
                }
                catch { System.Console.WriteLine("Erreur de parse"); }

            }
        }
        static void Main(string[] args)
        {

            //Product p = new Product();
            //Product b = new Biological();
            //Product c = new Chemical();

            //p.GetMyType();
            //c.GetMyType();
            //b.GetMyType();


            Provider provider = new Provider();
            provider.Password = "1234567";
            provider.ConfirmPassword = "1234567";

            //provider.Affiche = AfficheClient;
            //provider.Affiche();
            //provider.Affiche = delegate ()
            //{
            //    System.Console.WriteLine("Hello");
            //};


            //provider.Affiche();

            //// Provider.SetIsApproved(provider);
            //var result = false;
            //System.Console.WriteLine("++++"+provider.IsApproved);
            //Provider.SetIsApproved(provider.Password,
            //    provider.ConfirmPassword,
            //      out result);
            //provider.IsApproved = result;

            //System.Console.WriteLine(provider);

            //

           // provider.Affiche = () =>
           //{
           //    System.Console.WriteLine("Hello");
           //};

            //provider.ScanProduct(() =>
            //{
            //    System.Console.WriteLine("Hello");
            //});

            List<Product> products = new List<Product>() {
                new Product()
                {
                    Category= new Category(){Name="cat1" }
                }
            };

            ProductManage productManage = new ProductManage(products);
            //productManage.Find = (List<Product> list, string c) =>
            //  {
            //      List<Product> result = new List<Product>();
            //      foreach (var item in list)
            //      {
            //          if (item.Name.StartsWith(c))
            //              result.Add(item);
            //      }
            //      return result;
            //  };

            productManage.Scan(
            (List<Product> list, Category c) =>
                {
                    foreach (var item in list)
                    {
                        if (item.Category.CategoryId == c.CategoryId)
                        {
                            System.Console.WriteLine(item.Name);
                        }
                    }
                }
                ,
                new Category()
                );

           var list= productManage.Find(
                (List<Product> products, string c) =>
                {
                    List<Product> result = new List<Product>();
                    foreach (var item in products)
                    {
                        if (item.Name.StartsWith(c))
                            result.Add(item);
                    }
                    return result;
                }
                ,
                "f"
                );
            
        }
    }
}
