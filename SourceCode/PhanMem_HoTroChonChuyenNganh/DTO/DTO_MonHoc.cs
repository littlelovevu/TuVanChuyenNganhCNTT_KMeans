using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMem_HoTroChonChuyenNganh.DTO
{
    class DTO_MonHoc
    {
        string maMH, tenMH, soTC, maChuyenNganh;

        public string MaChuyenNganh
        {
            get { return maChuyenNganh; }
            set { maChuyenNganh = value; }
        }

        public string SoTC
        {
            get { return soTC; }
            set { soTC = value; }
        }

        public string TenMH
        {
            get { return tenMH; }
            set { tenMH = value; }
        }

        public string MaMH
        {
            get { return maMH; }
            set { maMH = value; }
        }
    }
}
