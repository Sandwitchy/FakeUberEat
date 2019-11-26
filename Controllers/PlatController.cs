using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FakeUberEat.Models;

namespace FakeUberEat.Controllers
{
    public class PlatController : Controller{
        private List<Plat> Galery = new List<Plat>(){
                new Plat(id: 1L,
                        titre:"Tacos",
                        image:"https://www.tacobueno.com/assets/food/tacos/Taco_Crispy_Beef_990x725.jpg",
                        description: "Délicieux plat mexicain",
                        price: 6),
                new Plat(id: 2L,
                        titre:"Burrito",
                        image:"https://deltaco.com/files/menu/item/machocomboburrito.png",
                        description: "Délicieux plat mexicain",
                        price: 9),
                new Plat(id: 3L,
                        titre:"Pizza",
                        image:"https://wallpapercave.com/wp/wp1813255.jpg",
                        description: "Délicieux plat italien",
                        price: 12),
                new Plat(id: 4L,
                        titre:"Sushi",
                        image:"http://wallpapersdsc.net/wp-content/uploads/2016/09/Sushi-Photos.jpg",
                        description: "Délicieux plat japonais",
                        price: 10),
            }; 
        public IActionResult Index()
        {

            return View(this.Galery);
        }
        public IActionResult Details(int id){
            foreach(Plat plat in this.Galery){
                if(plat.Id == id){
                    return View(plat);
                }
            }
            throw new Exception("Le plat n'existe pas!");
        }
    }
}