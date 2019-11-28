
using System.ComponentModel.DataAnnotations;

namespace FakeUberEat.Models{

    public class Plat{
        private int? id{get;set;}
        [Required]
        private string titre {get;set;}
        [Required]
        private string image {get;set;}
        [Required]
        private string description {get;set;}
        [Required]
        private decimal price {get;set;}
        public Plat(){

        }
        public Plat(int? id,string titre,string image,string description,decimal price){
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.image = image;
            this.price = price;
        }
        public int? Id{
            get{
                return id;
            }
            set{
                id = value;
            }
        }
        public string Titre{
            get{
                return titre;
            }
            set{
                titre = value;
            }
        }

        public string Description{
            get{
                return description;
            }
            set{
                description = value;
            }
        }
        public string Image{
            get{
                return image;
            }
            set{
                image = value;
            }
        }
        public decimal Price{
            get{
                return price;
            }
            set{
                price = value;
            }
        }
    }
}