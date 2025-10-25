using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace LTWeb05_Bai03.Models
{
    public class Data
    {
        static string strcon = "Data Source = LAPTOP-PA3FT87S\\SQLEXPRESS; database = QL_DTDD1; User ID = sa; Password = sas123; TrustServerCertificate = true";
        public List<ProductType> ptlist = new List<ProductType>();
        public List<Product> plist = new List<Product>();
        public Data()
        {
            ThietLap_LoaiSanPham();
            ThietLap_SanPham();
        }
        public void ThietLap_LoaiSanPham()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LOAI", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var pt = new ProductType();
                    pt.IDType = int.Parse(dr["MALOAI"].ToString());
                    pt.TypeName = dr["TENLOAI"].ToString();
                    ptlist.Add(pt);
                }
            }
        }
        public void ThietLap_SanPham()
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM SANPHAM", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    var p = new Product();
                    p.ProductID = int.Parse(dr["MASP"].ToString());
                    p.ProductName = dr["TENSP"].ToString();
                    p.ProductPath = dr["DUONGDAN"].ToString();
                    p.Price = float.Parse(dr["GIA"].ToString());
                    p.Description = dr["MOTA"].ToString();
                    p.IDType = int.Parse(dr["MALOAI"].ToString());
                    plist.Add(p);
                }
            }
        }
        public List<Product> SanPhamTheoLoai(int idType)
        {
            List<Product> pl = new List<Product>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                string sqlScript = String.Format("SELECT * FROM SANPHAM WHERE MALOAI = {0}", idType);
                SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    var p = new Product();
                    p.ProductID = int.Parse(dr["MASP"].ToString());
                    p.ProductName = dr["TENSP"].ToString();
                    p.ProductPath = dr["DUONGDAN"].ToString();
                    p.Price = float.Parse(dr["GIA"].ToString());
                    p.Description = dr["MOTA"].ToString();
                    p.IDType = int.Parse(dr["MALOAI"].ToString());
                    pl.Add(p);
                }
                return pl;
            }
        }
    }
}