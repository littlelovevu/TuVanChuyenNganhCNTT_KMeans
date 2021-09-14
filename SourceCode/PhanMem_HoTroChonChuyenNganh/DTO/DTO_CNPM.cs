using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMem_HoTroChonChuyenNganh.DTO
{
    class DTO_CNPM
    {
        string MSSV;

        public string MSSV1
        {
            get { return MSSV; }
            set { MSSV = value; }
        }
        double LT_NMLT, TH_NMLT, LT_LTHDT, TH_LTHDT, LT_CTDLGT, TH_CTDLGT;

        public double TH_CTDLGT1
        {
            get { return TH_CTDLGT; }
            set { TH_CTDLGT = value; }
        }

        public double LT_CTDLGT1
        {
            get { return LT_CTDLGT; }
            set { LT_CTDLGT = value; }
        }

        public double TH_LTHDT1
        {
            get { return TH_LTHDT; }
            set { TH_LTHDT = value; }
        }

        public double LT_LTHDT1
        {
            get { return LT_LTHDT; }
            set { LT_LTHDT = value; }
        }

        public double TH_NMLT1
        {
            get { return TH_NMLT; }
            set { TH_NMLT = value; }
        }

        public double LT_NMLT1
        {
            get { return LT_NMLT; }
            set { LT_NMLT = value; }
        }
    }
}
