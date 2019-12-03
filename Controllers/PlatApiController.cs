using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FakeUberEat.Models;
using FakeUberEat.Repository;

namespace FakeUberEat.Controllers.Api
{
    [Route("api/[controller]")]
    public class PlatApiController : Controller
    {
        private IRepository repository;
        public PlatApiController(IRepository repository){
            this.repository = repository;
        }
        [HttpGet]
        public IEnumerable<Plat> Get(){
            return (IEnumerable<Plat>)repository.All().OfType<Plat>();
        }

        [HttpGet("{id}")]
        public ActionResult<Plat> Get(int id){
            try{
                return (Plat) repository.getById(id);
            }catch(InvalidOperationException ex){
                Console.Write(ex);
                return NotFound("Aucun résutat");
            }
        }
        
        [HttpPost]
        public ActionResult<string> Insert([FromBody]Plat plat){
            if(plat.Id.HasValue){
                return NotFound("Objet non valide");
            }
            repository.Save(plat);
            return Created($"/platapi/get/{plat.Id}",plat);
        }

        [HttpPut("{id}")]
        public ActionResult<string> Update([FromBody]Plat plat){
            repository.Save(plat);
            return Created($"/platapi/get/{plat.Id}",plat);
        }
    }
}