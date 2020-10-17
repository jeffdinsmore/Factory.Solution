using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      List<Engineer> model = _db.Engineers.ToList();
      List<Machine> model2 = _db.Machines.ToList();
      ViewBag.Eng = model;
      ViewBag.Mach = model2;
      // List<Engineer> model = _db.Engineers.ToList();
      // List<Machine> model2 = _db.Machines.ToList();
      return View();
    }
    [HttpPost]
    public ActionResult Index(Machine machine, int EngineerId)
    {
      // if (EngineerId != 0)
      // {
      // _db.MachineEngineer.Add(new MachineEngineer() { EngineerId = EngineerId, MachineId = machine.MachineId });
      // }
      // _db.SaveChanges();
      return RedirectToAction("Details", "Engineer", new { id = machine.MachineId});
    }
  }
}