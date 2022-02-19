using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{

    public delegate void AfficheDelegate();
    public class Provider : Concept
    {
        [Key]
        public int Key {
            get;
            set;
        }
        public string UserName { get; set; }
        string password;
        [Required,MinLength(8),DataType(DataType.Password)]
        public string Password {
            set {
                if (value.Length < 5 || value.Length > 20)
                {
                    Console.WriteLine("erreur password");
                }
                else { password = value; }

            }
            get { return password; }
        }
        string confirmPassword;
        [Required,DataType(DataType.Password),NotMapped,Compare("Password")]
        public string ConfirmPassword {
            get { return confirmPassword; }
            set {
                if (value == password)
                    confirmPassword = value;
                else
                    Console.WriteLine("erreur confirmPassword");
            }
        }
        //[DataType(DataType.EmailAddress)]
        [EmailAddress,Required]
        public string Email { get; set; }
        public bool IsApproved { get; set; }
        [Display(Name ="Date")]
        public DateTime DateCreated { get; set; }
        public IList<Product> Products { get; set; }

        public bool Login(string userName, string password, string email = null)
        {
            if (email == null)
            { return UserName == userName && this.password == password; }
            else
                return UserName == userName && this.password == password && this.Email == email;
        }

        //public void ScanProduct(AfficheDelegate affiche)
        //{
        //    Affiche();
        //}
        public override void GetDetails()
        {
            Console.WriteLine($"[{UserName},{Password},{ConfirmPassword},{DateCreated}]");
        }


        public static void SetIsApproved(Provider p)
        {
            p.IsApproved = p.password == p.confirmPassword;
            //if (p.password == p.confirmPassword)
            //    p.IsApproved = true;
            //else
            //    p.IsApproved = false;
        }

        public static void SetIsApproved(string password,
            string confirmPassword, out bool isApproved)
        {
            isApproved = password == confirmPassword;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        //public AfficheDelegate Affiche{get; set;}

        public IList<Product> GetProducts(string filterType, string filterValue)
        {
            IList<Product> list = new List<Product>();

            switch (filterType)
            {
                case "DateCreated":
                    foreach (var item in Products)
                    {
                        DateTime date;
                        DateTime.TryParse(filterValue,out date);
                        if (date == item.DateCreated)
                        {
                            list.Add(item);
                        }
                    }
                    break;
                case "Price":
                    foreach (var item in Products)
                    {
                        float date = float.Parse(filterValue);
                        if (date == item.Price)
                        {
                            list.Add(item);
                        }
                    }
                    break;


            }


            if (filterType == "DateCreated")
            { 
                foreach (var item in Products)
                {
                    DateTime date=DateTime.Parse(filterValue);
                    if(date==item.DateCreated)
                    {
                        list.Add(item);
                    }
                }
                
            }


            return null;
        }

        //const
        //methode
        //get, set
        //etc

    }
}
