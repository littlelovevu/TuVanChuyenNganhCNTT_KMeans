using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMem_HoTroChonChuyenNganh.DTO;
using PhanMem_HoTroChonChuyenNganh.DAL;
using System.Data.SqlClient;

namespace PhanMem_HoTroChonChuyenNganh.BUS
{
    class BUS_ChuyenNganh
    {
        List<string> tenChuyenNganh=null;
        DAL_KetNoiSQL kn = new DAL_KetNoiSQL();
        public List<string> loadChuyenNganh() {
            tenChuyenNganh = new List<string>();
            string sql = "Select tenChuyenNganh from chuyenNganh";
            kn.Mo();
            SqlDataReader rd=kn.ExecuteReader(sql);
            while (rd.Read()) {
                tenChuyenNganh.Add(rd["tenChuyenNganh"].ToString());
            }
            kn.Dong();
            return tenChuyenNganh;
        }
        
    }
}
