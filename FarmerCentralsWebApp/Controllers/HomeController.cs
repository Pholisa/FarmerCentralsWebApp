using FarmerCentralsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmerCentralsWebApp.Controllers
{
    public class HomeController : Controller
    {
        FarmCentralDBEntities database = new FarmCentralDBEntities();

        // GET: Home
        public ActionResult Index()
        {

            return View(database.tblEmployees.ToList());


        }

        public ActionResult Filters(string searching)
        {
            var filter = from f in database.ProductInfoes
                         select f;
            if (!String.IsNullOrEmpty(searching))
            {
                filter = filter.Where(f => f.Product_Type_Name.Contains(searching));
            }
            return View(filter.ToList());


        }
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(tblEmployee registers)
        {
            if (database.tblEmployees.Any(x => x.empName == registers.empName))
            {
                ViewBag.Notification = "This account already exists";
                return View();
            }
            else
            {
                database.tblEmployees.Add(registers);
                database.SaveChanges();

                Session["logIdSS"] = registers.empId.ToString();
                Session["UsernameSS"] = registers.empName.ToString();

                return RedirectToAction("HomePage", "Home");
            }

        }

        public ActionResult LogInFarmer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LogInFarmer(tblFarmer lg)
        {
            var viewLogin = database.tblFarmers.Where(p => p.farmerName.Equals(lg.farmerName) && p.password.Equals(lg.password)).FirstOrDefault();
            if (viewLogin != null)
            {
                Session["logIdSS"] = lg.farmerId.ToString();
                Session["UsernameSS"] = lg.farmerName.ToString();
                return RedirectToAction("ProductList", "Home");
            }
            else
            {
                ViewBag.Notification = "Incorrect Username or Password";
            }
            return View();
        }


        public ActionResult LogInEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInEmployee(tblEmployee logs)
        {
            var viewLogin = database.tblEmployees.Where(p => p.empName.Equals(logs.empName) && p.password.Equals(logs.password)).FirstOrDefault();
            if (viewLogin != null)
            {
                Session["logIdSS"] = logs.empId.ToString();
                Session["UsernameSS"] = logs.empName.ToString();
                return RedirectToAction("ViewFarmers", "Home");
            }
            else
            {
                ViewBag.Notification = "Incorrect Username or Password";
            }
            return View();
        }
        public ActionResult HomePage()
        {
            return View();
        }

        public ActionResult ViewFarmers()
        {
            return View(database.tblFarmers.ToList());
        }

        public ActionResult Farmer()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Farmer(tblFarmer farmers)
        {
            database.tblFarmers.Add(farmers);
            database.SaveChanges();


            Session["UsernameSS"] = farmers.farmerName.ToString();
            Session["ContactSS"] = farmers.contact.ToString();
            Session["Address"] = farmers.address.ToString();
            Session["EmailAddress"] = farmers.emailAddress.ToString();



            return RedirectToAction("ViewFarmers", "Home");
        }

        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Employee(tblEmployee employees)
        {
            database.tblEmployees.Add(employees);
            database.SaveChanges();


            Session["UsernameSS"] = employees.empName.ToString();
            Session["ContactSS"] = employees.contact.ToString();
            Session["Address"] = employees.address.ToString();
            Session["EmailAddress"] = employees.emailAddress.ToString();




            return RedirectToAction("HomePage", "Home");
        }
        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Product(tblProduct prod)
        {
            database.tblProducts.Add(prod);
            database.SaveChanges();


            return RedirectToAction("Productlist", "Home");
        }

        public ActionResult ProductList()
        {
            return View(database.tblProducts.ToList());
        }


        public ActionResult ProductInfo()
        {
            return View(database.ProductInfoes.ToList());
        }


        public ActionResult ProductType()
        {
            return View();
        }

        [HttpPost]

        public ActionResult ProductType(tblProductType prodT)
        {
            database.tblProductTypes.Add(prodT);
            database.SaveChanges();


            return RedirectToAction("Product", "Home");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("HomePage", "Home");
        }
    }
}