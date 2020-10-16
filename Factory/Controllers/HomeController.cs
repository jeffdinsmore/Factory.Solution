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
      var thisEngineer = _db.Engineers
        .Include(engineer => engineer.Machines)
        .ThenInclude(join => join.Machine)
        // .FirstOrDefault(engineer => engineer.EngineerId == id);
      // return View(thisEngineer);
      return View(model, thisEngineer);
    }
  }
}