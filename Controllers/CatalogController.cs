using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotnet2.Models;

namespace dotnet2.Controllers
{
    public class CatalogController : Controller{

        private DataContext dbContext;

    public CatalogController(DataContext context){
        this.dbContext = context;

    }


        public IActionResult Index(){
            return View();
        }
        public IActionResult Register(){
            return View();
        }

        [HttpPost]
        public IActionResult saveCar( [FromBody] Car theCar   ){
                dbContext.Cars.Add(theCar);
                dbContext.SaveChanges();
            

            return Json(theCar);
        }

        [HttpGet]
        public IActionResult GetCatalog(){
            var carList = dbContext.Cars.ToList();
            return Json(carList);
        }



    }
}