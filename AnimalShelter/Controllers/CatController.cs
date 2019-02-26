using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class CatController : Controller
    {

      [HttpGet("/cats")]
      public ActionResult Index()
      {
        return View(Cat.GetAllCatsByBreed());
      }

    }
}
