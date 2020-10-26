using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using ScoolDAL;

namespace School.Controllers
{
    public class HomeController : Controller
    {
        SchoolContext ctx = new SchoolContext();
        public IActionResult Index()
        {
            var students = ctx.Students.ToList();
            return View(students);

        }

        public IActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            Student student = new Student()
            {
                Name = model.Name,
                Surname = model.Surname,
                Username = model.Username,
                Password = model.Password,
                Age = model.Age
            };
            ctx.Students.Add(student);
            ctx.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Edit(int id)
        {
            var student = ctx.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            ctx.Students.Update(model);
            ctx.SaveChanges();

            return RedirectToAction("index");
        }



        public IActionResult Delete(Student model)
        {
            ctx.Remove(model);
            ctx.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ctx.Students.Any(a => a.Username == username & a.Password == password))
            {
                ViewBag.Data = username;
                return View();
            }

            return RedirectToAction("Login");





        }
    }
}

