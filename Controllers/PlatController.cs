using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeUberEat.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using FakeUberEat.Repository;

namespace FakeUberEat.Controllers
{
    public class PlatController : Controller {
        private IRepository repository;
        public PlatController(IRepository repository){
            this.repository = repository;
        }
        public IActionResult Index()
        {
            List<Plat> plats = repository.All().Cast<Plat>().ToList();
            return View(plats);
        }

        public IActionResult Insert(){
            return View(new Plat());
        }
        [HttpPost]
        public IActionResult Insert(Plat nouveau)
        {
            Console.WriteLine(nouveau);
            repository.Save(nouveau);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int id)
        {
            return View(repository.getById(id));
        }
    }
}