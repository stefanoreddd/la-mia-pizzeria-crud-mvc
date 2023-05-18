using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using LaMiaPizzeria.Models.ModelForViews;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> ourTecArticles = db.Pizzas.ToList();
                return View("Index", ourTecArticles);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? articleDetails = db.Pizzas.Where(article => article.Id == id).FirstOrDefault();

                if (articleDetails != null)
                {
                    return View("Details", articleDetails);
                }
                else
                {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                }
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza newArticle)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newArticle);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizzas.Add(newArticle);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }


        public IActionResult FindArticles(string titleKeyword, int viewCount)
        {
            UserProfile connectedProfile = new UserProfile("Stefano", "Caggiula", 27);

            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> matchTitleArticles = db.Pizzas.Where(article => article.Title.Contains(titleKeyword)).ToList();

                ProfileListPizzas resultModel = new ProfileListPizzas(connectedProfile, titleKeyword, matchTitleArticles);


                return View("SearchArticles", resultModel);
            }
        }
    }
}