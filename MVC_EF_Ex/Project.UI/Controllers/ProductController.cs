using Project.Business.Concrete;
using Project.Entites.Concrete;
using Project.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Project.UI.Controllers
{
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager();
        //ProductManager pm = new ProductManager(new EFProductDal());
        CategoryManager cm = new CategoryManager();
        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products = pm.GetAll();
            List<Category> categories = cm.GetAll();
            List<ControllerModels> lists = (from c in categories
                                            join p in products on c.Id equals p.CategoryId
                                            where c.IsDeleted == 0
                                            select new ControllerModels
                                            {
                                                Id = p.Id,
                                                Price = p.Price,
                                                ProductName = p.Name,
                                                CategoryName = c.Name,
                                                Quantity = p.Quantity,
                                                IsDeleted = p.IsDeleted
                                            }).ToList();
            var result = lists.Where(x => x.IsDeleted == 0);
            return View(result.ToList());
        }
        public ActionResult AddProduct()
        {
            //List<SelectListItem> value = (from x in cm.GetAll()
            //                              select new SelectListItem
            //                              {
            //                                  Value = x.Id.ToString(),
            //                                  Text = x.Name
            //                              }).ToList();
            //ViewBag.a = value;

            var result = cm.GetAll();
            result.Where(x => x.IsDeleted == 0);
            return View(result);
        }
        [HttpPost]
        public ActionResult Add(string name, int categoryId, decimal price, int quantity)
        {
            Product product = new Product
            {
                Name = name,
                CategoryId = categoryId,
                Price = price,
                Quantity = quantity
            };
            pm.Insert(product);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            var result = pm.Get(x => x.Id == productId && x.IsDeleted == 0);
            result.IsDeleted = 1;
            pm.Update(result);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Update(int productId, string productName, decimal price, int quantity, int categoryId)
        {
            Product product = pm.Get(x => x.Id == productId && x.IsDeleted == 0);
            product.Name = productName;
            product.Price = price;
            product.Quantity = quantity;

            pm.Update(product);
            return Redirect("Index");
        }
    }
}