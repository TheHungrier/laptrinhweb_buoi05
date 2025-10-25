using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LTWeb05_Bai02.Models
{
    public class DuLieu
    {
        static string strcon = "Data Source=LAPTOP-PA3FT87S\\SQLEXPRESS; database=QL_NHANSU; User ID=sa; Password=sas123; TrustServerCertificate=true";
        SqlConnection con = new SqlConnection(strcon);
        public List<Employee> dsNV = new List<Employee>();
        public List<Department> dsPB = new List<Department>();
        public DuLieu()
        {
            ThietLap_DSNV();
            ThietLap_DSPB();
        }
        public void ThietLap_DSNV()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EMPLOYEE", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var em = new Employee();
                em.MaNV = int.Parse(dr["ID"].ToString());
                em.Ten = dr["NAME"].ToString();
                em.GioiTinh = dr["GENDER"].ToString();
                em.Tinh = dr["CITY"].ToString();
                em.MaPg = (int)dr["DEPID"];
                dsNV.Add(em);
            }
        }
        public void ThietLap_DSPB()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DEPARTMENT", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                var dep = new Department();
                dep.MaPg = int.Parse(dr["DEPID"].ToString());
                dep.TenPg = dr["NAME"].ToString();
                dsPB.Add(dep);
            }
        }
        public Department ChiTietPB(int maPg)
        {
            Department pb = new Department();
            string sqlScript = string.Format("SELECT * FROM DEPARTMENT WHERE DEPID = {0}", maPg);
            SqlDataAdapter da = new SqlDataAdapter(sqlScript, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            pb.MaPg = int.Parse(dt.Rows[0]["DEPID"].ToString());
            pb.TenPg = dt.Rows[0]["NAME"].ToString();
            return pb;
        }
        public List<Employee> NhanVienTheoPB(int maPg)
        {
            return dsNV.Where(nv => nv.MaPg == maPg).ToList();
        }
    }
}