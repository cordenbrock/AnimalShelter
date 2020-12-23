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
      List<Animal> unsortedModel = _db.Animals.ToList();
      List<Animal> model = unsortedModel.OrderBy(i => i.Type).ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      animal.DateOfAdmittance = (DateTime.Now).ToShortDateString();
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animals => animals.AnimalId == id);
      return View(thisAnimal);
    }

  }
}