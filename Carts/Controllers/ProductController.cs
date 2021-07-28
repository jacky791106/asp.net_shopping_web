using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Models.Product> result = new List<Models.Product>();

            ViewBag.ResultMessage = TempData["ResultMessage"];

            using(Models.CartsEntities db = new Models.CartsEntities())
            {
                result = (from s in db.Products select s).ToList();

                return View(result);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Product postback)
        {
            if (this.ModelState.IsValid)
            {
                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    db.Products.Add(postback);
                    db.SaveChanges();
                    TempData["ResultMessage"] = String.Format("商品[{0}]成功建立", postback.Name);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ResultMessage = "資料有誤，請檢查";
            
            return View(postback);
        }

        public ActionResult Edit(int id)
        {
            using(Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products where s.Id == id select s).FirstOrDefault();
                if (result != default(Models.Product))
                {
                    return View(result);
                }
                else
                {
                    TempData["ResultMessage"] = "資料有誤，請重新操作";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Edit(Models.Product postback)
        {
            if (this.ModelState.IsValid)
            {
                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    var result = (from s in db.Products where s.Id == postback.Id select s).FirstOrDefault();
                    result.Name = postback.Name;
                    result.Price = postback.Price;
                    result.PublishDate = postback.PublishDate;
                    result.Quantity = postback.Quantity;
                    result.Status = postback.Status;
                    result.CategoryId = postback.CategoryId;
                    result.DefaultImageId = postback.DefaultImageId;
                    result.Description = postback.Description;

                    db.SaveChanges();
                    TempData["ResultMessage"] = String.Format("商品[{0}]成功編輯", postback.Name);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(postback);
            }
        }

        public ActionResult Delete(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products where s.Id == id select s).FirstOrDefault();
                if (result != default(Models.Product))
                {
                    db.Products.Remove(result);

                    db.SaveChanges();

                    TempData["ResultMessage"] = String.Format("商品[{0}]成功刪除", result.Name);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ResultMessage"] = "指定資料不存在，無法刪除，請重新操作";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}