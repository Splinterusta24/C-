using FluentValidation.Results;
using Project.Business.Concrete;
using Project.Business.Validation;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        ProductManager pm = new ProductManager();
        public ActionResult Index()
        {
            var categories = cm.GetAllByfilter(x => x.IsDeleted == 0);
            return View(categories);
        }
        public ActionResult AddCategory() 
        {
            List<SelectListItem> value = (from x in cm.GetAll()
                                          select new SelectListItem
                                          {
                                              Value = x.Id.ToString(),
                                              Text = x.Name
                                          }).ToList();
            ViewBag.a = value;
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidation validation = new CategoryValidation();
            ValidationResult sonuc = validation.Validate(category);
            if (sonuc.IsValid)
            {
                cm.Insert(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in sonuc.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int categoryId)
        {
            Category category = cm.Get(x => x.Id == categoryId && x.IsDeleted == 0);
            //List<Product> list = pm.GetAllByfilter(x => x.CategoryId == categoryId);
            
            category.IsDeleted = 1;
            cm.Update(category);
            return Redirect("Index");
        }
        public ActionResult UpdateCategory(int id)
        {
            var category = cm.Get(x => x.Id == id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            CategoryValidation validations = new CategoryValidation();
            ValidationResult result = validations.Validate(category);
            if (result.IsValid)
            {
                cm.Update(category);
                return Redirect("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}