using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMem_HoTroChonChuyenNganh.DTO
{
    class DTO_MMT
    {
        string MSSV;
        double LT_MMT, KTMT, TH_MMT, HDH;

        public double HDH1
        {
            get { return HDH; }
            set { HDH = value; }
        }

        public double TH_MMT1
        {
            get { return TH_MMT; }
            set { TH_MMT = value; }
        }

        public double KTMT1
        {
            get { return KTMT; }
            set { KTMT = value; }
        }

        public double LT_MMT1
        {
            get { return LT_MMT; }
            set { LT_MMT = value; }
        }

        public string MSSV1
        {
            get { return MSSV; }
            set { MSSV = value; }
        }
    }
}
