using PS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Service
{
    public class DataTest
    {
        public static List<Product> Products
        {
            get
            {
                Product acideCitrique = new Chemical()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "ACIDE CITRIQUE",
                    Description = "Monohydrate - E330 - USP32",
                    Category = Categories[1],
                    Price = 90,
                    Quantity = 30,
                     //City = "Sousse"
                };
                Product cacaoNaturelle = new Chemical()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "POUDRE DE CACAO NATURELLE",
                    Description = "10% -12%",
                    Category = Categories[1],
                    Price = 419,
                    Quantity = 80,
                   //   City = "Sfax"
                };
                Product cacaoAlcalinisee = new Chemical()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "POUDRE DE CACAO ALCALINISÉE",
                    Description = "10% -12%",
                    Category = Categories[1],
                    Price = 60,
                    Quantity = 300
                    
                    
                };
                Product dioxyde = new Chemical()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "DIOXYDE DE TITANE",
                    Description = "TiO2 grade alimentaire, cosmétique et pharmaceutique.",
                    Category = Categories[1],
                    Price = 200,
                    Quantity = 50,
                      //City = "Tunis"
                };
                Product amidon = new Chemical()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "AMIDON DE MAÏS",
                    Description = "Amidon de maïs natif",
                    Category = Categories[1],
                    Price = 70,
                    Quantity = 30,
                    // City = "Tunis"
                };
                Product blackberry = new Biological()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Name = "Blackberry",
                    Description = "",
                    Category = Categories[0],
                    Price = 60,
                    Quantity = 0

                };
                Product apple = new Biological()
                {
                    DateCreated = new DateTime(2000, 12, 12),
                    Description = "",
                    Category = Categories[0],
                    Name = "Apple",
                    Price = 100.00f,                    
                    Quantity = 100

                };

                return new List<Product>() { dioxyde, amidon, cacaoAlcalinisee, blackberry, apple, acideCitrique, cacaoNaturelle };
            }
        }


        public static List<Category> Categories
        {
            get
            {
                Category fruit = new Category() {  Name = "Fruit" };
                Category Alimentaire = new Category() {  Name = "Alimentaire" };
                return new List<Category> { fruit, Alimentaire };
            }
        }

        public static List<Provider> Providers
        {
            get
            {
                Provider sater = new Provider() {  UserName = "SATER" };
                Provider sudMedical = new Provider() { UserName = "SUDMEDICAL" };
                Provider palliserSa = new Provider() {  UserName = "Palliser SA" };
                Provider prov4 = new Provider() {  UserName = "PROV4" };
                Provider prov5 = new Provider() {  UserName = "PROV5" , Email= "PROV5@esprit.tn"};
                return new List<Provider>() { sater, sudMedical, palliserSa, prov4, prov5 };
            }
        }

    }
}
