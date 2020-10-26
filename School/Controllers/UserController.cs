using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoolDAL;

namespace School.Controllers
{
  
    public class UserController : Controller
    {
        SchoolContext ctx = new SchoolContext();

        public IActionResult Index()
        {
            return View();
           
        }
    }
}
