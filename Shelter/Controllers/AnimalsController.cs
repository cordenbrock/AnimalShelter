using Microsoft.AspNetCore.Mvc;
using Shelter.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Shelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly ShelterContext _db;

    public AnimalsController(ShelterContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Animal> model = _db.Animals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      animal.DateOfAdmittance = (DateTime.Now).Date;
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}