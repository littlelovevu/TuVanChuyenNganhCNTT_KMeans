using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMem_HoTroChonChuyenNganh.DTO
{
    class DTO_HTTT
    {
        string MSSV;

        public string MSSV1
        {
            get { return MSSV; }
            set { MSSV = value; }
        }
        double LT_CSDL, TH_CSDL, HQT_CSDL;

        public double HQT_CSDL1
        {
            get { return HQT_CSDL; }
            set { HQT_CSDL = value; }
        }

        public double TH_CSDL1
        {
            get { return TH_CSDL; }
            set { TH_CSDL = value; }
        }

        public double LT_CSDL1
        {
            get { return LT_CSDL; }
            set { LT_CSDL = value; }
        }
    }
}
