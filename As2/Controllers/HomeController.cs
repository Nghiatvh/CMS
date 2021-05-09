using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using As2.Data;
using As2.Models;

namespace As2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CMSContext context;

        public HomeController(CMSContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.IsLoginFail = "hidden";
            ViewBag.IsWrong = "";
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(string role, string username, string password)
        {
            if (username == null || password == null)
            {
                ViewBag.IsWrong = "is-invaled";
            }
            else
            {
                if (role == new Admin().GetType().Name)
                {
                    try
                    {
                        var admin = context.Admins.Where(admin => admin.Username == username && admin.Password == password).Single();
                        return RedirectToAction("Index", "Admins");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ViewBag.IsWrong = "";
                        return View();
                    }
                }
                if (role == new TrainingStaff().GetType().Name)
                {
                    try
                    {
                        var ts = context.TrainingStaffs.Where(ts => ts.Username == username && ts.Password == password).Single();
                        return RedirectToAction("Index", "Trainingstaffs");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ViewBag.IsWrong = "";
                        return View();
                    }
                }
                if (role == new Trainer().GetType().Name)
                {
                    try
                    {
                        var tn = context.Trainers.Where(tn => tn.Username == username && tn.Password == password).Single();
                        return RedirectToAction("Index", "Trainers");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        ViewBag.IsWrong = "";
                        return View();
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}