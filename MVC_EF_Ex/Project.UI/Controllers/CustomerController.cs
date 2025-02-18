using Project.Business.Concrete;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerManager cm = new CustomerManager();
        public ActionResult Index()
        {
            List<Customer> customers = cm.GetAll();
            return View(customers);
        }
    }
}