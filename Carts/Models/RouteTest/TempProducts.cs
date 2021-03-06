using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Models.RouteTest
{
    public class TempProducts : Controller
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        // GET: TempProducts
        public static List<TempProducts> getAllproducts()
        {
            List<TempProducts> result = new List<TempProducts>();

            result.Add(new Carts.Models.RouteTest.TempProducts
            {
                ID = 1,
                Name = "鉛筆",
                Price = 30.0m
            });
            result.Add(new Carts.Models.RouteTest.TempProducts
            {
                ID = 2,
                Name = "記事本",
                Price = 50.0m
            });
            result.Add(new Carts.Models.RouteTest.TempProducts
            {
                ID = 3,
                Name = "橡皮擦",
                Price = 10.0m
            });
            return result;
        }
    }
}