using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PS.Service
{
    public class ProductManage
    {
        List<Product> products;
      //  public FindDel Find { get; set; }        
        public ProductManage(List<Product> products)
        {
            this.products = products;
        }
        public void Scan(ScanDel del, Category c)
        {
            del(products, c);
        }

        public List<Product> Find(FindDel find, string c)
        {
            return find(products, c);
        }


        public List<Product> FindProductByName( string c)
        {
            var list = new List<Product>();
            foreach (var item in products)
            {
                if (item.Name.StartsWith(c))
                    list.Add(item);
            }
           // return list;


            //langage Linq --> Syntaxe de requete
            IEnumerable<string> query=from item in products
            where item.Name.StartsWith(c)
            select item.Name;
            var name = from item in products
                        orderby item.DateCreated descending
                        where item.Name.StartsWith(c)
                        group item by item.Price;

            //langage Linq --> Syntaxe de méthode
            IEnumerable<string> query2 = products.Where(p => p.Name.StartsWith(c))
                .OrderBy(p => p.DateCreated).Select(p => p.Name);//ascend
            var query4= products.Where(p => p.Name.StartsWith(c)).OrderByDescending(p=>p.DateCreated)
                .Select(p =>new { p.Name, p.Price });//desc
            IEnumerable<Product> query3= products.Where(p => p.Name.StartsWith(c));
            IEnumerable<IGrouping<DateTime,Product>> query5= products.Where(p => p.Name.StartsWith(c)).GroupBy(p=>p.DateCreated);

            foreach (var group in query5)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine(item.Name);
                }
            }

            return null;
        }

        public IList<Product> Get5Chemical(double price)
        {
            var query = (from p in products
                        where p.Price > price
                        select p).Take(5);

             query = products
                        .Where(p=> p.Price > price)
                         .Take(5);

            return query.ToList();
        }
        public IList<Product> GetProductPrice(double price)
        {
            var query = (from p in products
                        where p.Price > price
                        select p).Skip(2);

             query = products
                        .Where(p=> p.Price > price)
                         .Skip(2);

            return query.ToList();
        }


        public double GetAveragePrice()
        {
            var query = (from p in products
                         select p.Price).Average();
            //var query = (from p in products
            //             select p).Average(p=>p.Price);
            return query;
        }

        public Product GetMaxPrice() 
        {
            var product = (from p in products
                           orderby p.Price descending
                           select p).First();

            product =  products
                           .OrderByDescending(p=> p.Price) 
                           .First();

            return product;
        }

        public int GetCountProduct(string city) {
            //var query = from p in products
            //            where p is Chemical && ((Chemical)p).City == city
            //            select (Chemical)p;
            //var query = from p in products.OfType<Chemical>()
            //            where p.City == city
            //            select p;
           // return query.Count();
            var query = products.OfType<Chemical>().Count(p=>p.City==city);

            return query;
        }

        public IList<Chemical> GetChemicalCity()
        {
            var query = products.OfType<Chemical>().OrderBy(p => p.City);
            return query.ToList();
        }

        public IList<IGrouping<string, Chemical>> GetChemicalGroupByCity()
        {
            var query =products.OfType<Chemical>().OrderBy(p => p.City).GroupBy(p=>p.City).ToList();
            foreach (var group in query)
            {
                Console.WriteLine(group.Key);//city
                foreach (var item in group)
                {
                    Console.WriteLine(item.Name);
                }
            }

            return query;
        }
        
    }
}
