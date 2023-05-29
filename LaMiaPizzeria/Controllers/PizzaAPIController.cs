using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using LaMiaPizzeria.Models.ModelForViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaMiaPizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizza()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizzas = db.Pizze.ToList();
                return Ok(pizzas);
            }
        }

        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToSearch = db.Pizze.Where(pizza => pizza.Title.Contains(name)).FirstOrDefault();

                if (pizzaToSearch != null)
                {
                    return Ok(pizzaToSearch);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToSearch = db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaToSearch != null)
                {
                    return Ok(pizzaToSearch);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
