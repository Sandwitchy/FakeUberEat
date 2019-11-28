using System;
using System.ComponentModel.DataAnnotations;

namespace FakeUberEat.Models
{
    public class User{
        private int? id;
        [Required]
        private string name;
        [Required]
        private string email;
        [Required]
        private string password;
        private DateTime? createdAt;

        public User(int? id,string name,string email,string password,DateTime? createdAt){
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.createdAt = createdAt;
        }
        public int? Id{
            get{
                return id;
            }
        }
        public string Name{
            get{
                return name;
            }
            set{
                name = value;
            }
        }
        public string Email{
            get{
                return email;
            }
            set{
                email = value;
            }
        }
        public string Password{
            get{
                return password;
            }
            set{
                password = value;
            }
        }

        public DateTime? CreatedAt{
            get{
                return createdAt;
            }
        }
    }
}