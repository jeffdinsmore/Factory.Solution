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
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      List<Engineer> model = _db.Engineers.ToList();
      List<Machine> model2 = _db.Machines.ToList();
      return View();
    }
    [HttpPost]
    public ActionResult Index(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
      _db.MachineEngineer.Add(new MachineEngineer() { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Details", "Engineer", new { id = machine.MachineId});
    }
  }
}