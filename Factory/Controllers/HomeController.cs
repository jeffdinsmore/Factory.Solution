using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db ;
    }
    public ActionResult Index()
    {
      List<Engineer> modelEng = _db.Engineers.ToList();
      List<Machine> modelMach = _db.Machines.ToList();
      ViewBag.Eng = modelEng;
      ViewBag.Mach = modelMach;
      return View();
    }
  }
}