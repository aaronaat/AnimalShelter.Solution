using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
    public class RabbitController : Controller
    {

      [HttpGet("/rabbits")]
      public ActionResult Index()
      {
        return View(Rabbit.GetAllRabbits());
      }

    }
}
