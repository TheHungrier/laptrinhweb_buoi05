using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb05_Bai02.Models;

namespace LTWeb05_Bai02.Controllers
{
    public class HomeController : Controller
    {
        DuLieu csdl = new DuLieu();
        public ActionResult DanhSachNhanVien()
        {
            List<Employee> ds = csdl.dsNV;
            return View(ds);
        }
        public ActionResult HienThiPhongBan()
        {
            List<Department> dspb = csdl.dsPB;
            return View(dspb);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Department dspb = csdl.ChiTietPB(id);
            return View(dspb);
        }
        public ActionResult NhanVienTheoPB(int id)
        {
            DuLieu dl = new DuLieu();
            var nvTheoPB = dl.NhanVienTheoPB(id);
            var pb = dl.ChiTietPB(id);
            ViewBag.TenPB = pb.TenPg;
            return View(nvTheoPB);
        }
    }
}