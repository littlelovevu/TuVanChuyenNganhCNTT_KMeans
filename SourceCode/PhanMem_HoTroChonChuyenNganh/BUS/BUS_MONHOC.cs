using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMem_HoTroChonChuyenNganh.BUS
{
    class BUS_MONHOC
    {
        DAL.DAL_KetNoiSQL kn = new DAL.DAL_KetNoiSQL();
        public List<string> loadTenMH_TheoCN(string tenChuyenNganh) {
            string sql = "select tenMH from monHoc,chuyenNganh"
                       + " where monHoc.maChuyenNganh=chuyenNganh.maChuyenNganh"
                       + " and tenChuyenNganh=N'" + tenChuyenNganh.Trim() + "'";
            try {
                List<string> dsTenMH = new List<string>();
                kn.Mo();
                SqlDataReader rd=kn.ExecuteReader(sql);
                while (rd.Read()) {
                    dsTenMH.Add(rd["tenMH"].ToString());
                }
                kn.Dong();
                return dsTenMH;
            }
            catch {
                return null;
            }
        }
        public Object[] loadFull_TenMH() {
            List<string> ds_TenMH = new List<string>();
            try {
                kn.Mo();
                string sql = "select tenMH from MonHoc";
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read()) {
                    ds_TenMH.Add(rd["tenMH"].ToString());
                }
                Object[] kq = ds_TenMH.Cast<Object>().ToArray();
                kn.Dong();
                return kq;
            }
            catch {
                return null;
            }
        }
    }
}
