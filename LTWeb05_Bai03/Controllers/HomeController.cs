using LTWeb05_Bai03.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;

namespace LTWeb05_Bai03.Controllers
{
    public class HomeController : Controller
    {
        Data database = new Data();

        public ActionResult Index(int id = 0)
        {
            ViewBag.ProductTypes = database.ptlist;
            List<Product> products;
            products = database.SanPhamTheoLoai(id);
            return View(products);
        }
        public ActionResult HienThiLoaiSanPham()
        {
            List<ProductType> types = database.ptlist;
            return View(types);
        }
        public ActionResult HienThiSanPham()
        {
            List<Product> products = database.plist;
            return View(products);
        }
        public ActionResult TimTheoSanPham(string keyword = "")
        {
            var result = database.plist.Where(p => p.ProductName.Contains(keyword)).ToList();
            ViewBag.Keyword = keyword;
            return View(result);
        }
        public ActionResult TimTheoNhieuLoai(int idLoai = 0)
        {
            ViewBag.ProductTypes = database.ptlist;
            ViewBag.SelectedID = idLoai;
            List<Product> products;
            if (idLoai > 0)
                products = database.plist.Where(p => p.IDType == idLoai).ToList();
            else
                products = database.plist;

            return View(products);
        }
    }
}