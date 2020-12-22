using Microsoft.AspNetCore.Mvc;

namespace Shelter
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }
  }
}