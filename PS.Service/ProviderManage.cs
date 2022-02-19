using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace PS.Service
{

    //delegate
    public delegate List<Product> FindDel(List<Product> list, string ch);
    public delegate void ScanDel(List<Product> list, Category c);
    public class ProviderManage
    {

        List<Provider> providers;

       
        public ProviderManage(List<Provider> providers)
        {
            this.providers = providers;
        }


        public IList<Provider> GetProviderByName(string name)
        {
            //Syntaxe de requête
            //IEnumerable<Provider> query=from item in providers
            //where item.UserName.Contains(name)
            //select item;
            //return query.ToList();
            //Syntaxe des méthodes
            IEnumerable<Provider> query = providers.Where(p => p.UserName.Contains(name));
            return query.ToList();
        }

        public Provider GetFirstProviderByName(string name)
        {
            //Syntaxe de requête
            //IEnumerable<Provider> query=from item in providers
            //where item.UserName.StartsWith(name)
            //select item;
            //return query.First();
            //Syntaxe des méthodes
            var query2 = providers.Where(p => p.UserName.StartsWith(name)).FirstOrDefault();
            return query2;
        }

        public Provider GetProviderById(int id) {
            //var query = from p in providers
            //            where p.Id == id
            //            select p;

            //return query.Single();

            return providers.Where(p => p.Key == id).SingleOrDefault();
        }


    }
}
