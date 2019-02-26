using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class DogController : Controller
    {

      [HttpGet("/dogs")]
      public ActionResult Index()
      {
        return View(Dog.GetAllDogs());
      }

    }
}
