using Microsoft.AspNetCore.Mvc;

namespace Shelter.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}