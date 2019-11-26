
namespace FakeUberEat.Models{

    public class Plat{
        private long id;
        private string titre;
        private string image;
        private string description;
        private decimal price;
        public Plat(long id,string titre,string image,string description,decimal price){
            this.id = id;
            this.titre = titre;
            this.description = description;
            this.image = image;
            this.price = price;
        }
        public long Id{
            get{
                return id;
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