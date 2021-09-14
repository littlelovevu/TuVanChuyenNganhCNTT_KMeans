using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMem_HoTroChonChuyenNganh.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PhanMem_HoTroChonChuyenNganh.DTO;

namespace PhanMem_HoTroChonChuyenNganh.BUS
{
    class BUS_SinhVien
    {
        DAL_KetNoiSQL kn = new DAL_KetNoiSQL();
        public List<DTO_SinhVien> getDSDV() {
            List<DTO_SinhVien> dssv = new List<DTO_SinhVien>();
            try
            {
                string sql = "select * from DS_SINHVIEN";
                kn.Mo();
                SqlDataReader rd=kn.ExecuteReader(sql);
                while (rd.Read()) {
                    DTO_SinhVien sv = new DTO_SinhVien();
                    sv.MSSV1 = rd["MSSV"].ToString();
                    sv.HDH1 = double.Parse(rd["HDH"].ToString());
                    sv.HQT_CSDL1 = double.Parse(rd["HQT_CSDL"].ToString());
                    sv.KTMT1 = double.Parse(rd["KTMT"].ToString());
                    sv.LT_CSDL1 = double.Parse(rd["LT_CSDL"].ToString());
                    sv.LT_CTDLGT1 = double.Parse(rd["LT_CTDLGT"].ToString());
                    sv.LT_LTHDT1 = double.Parse(rd["LT_LTHDT"].ToString());
                    sv.LT_MMT1 = double.Parse(rd["LT_MMT"].ToString());
                    sv.LT_NMLT1 = double.Parse(rd["LT_NMLT"].ToString());
                    sv.TH_CSDL1 = double.Parse(rd["TH_CSDL"].ToString());
                    sv.TH_CTDLGT1 = double.Parse(rd["TH_CTDLGT"].ToString());
                    sv.TH_LTHDT1 = double.Parse(rd["TH_LTHDT"].ToString());
                    sv.TH_MMT1 = double.Parse(rd["TH_MMT"].ToString());
                    sv.TH_NMLT1 = double.Parse(rd["TH_NMLT"].ToString());
                    dssv.Add(sv);
                }
                kn.Dong();
                return dssv;
            }
            catch {
                return dssv;
            }
        }

        public double getDiemHS_10(string MSSV)
        {
            string sql = "select diem_HS10 from DS_SinhVien"
                        +" where MSSV='"+MSSV+"'";
            kn.Mo();
            SqlDataReader rd=kn.ExecuteReader(sql);
            double kq = -1;
            while (rd.Read()) {
                kq = double.Parse(rd["diem_HS10"].ToString());
            }
            kn.Dong();
            return kq;
        }
        public double getDiemHS_4(string MSSV)
        {
            string sql = "select diem_HS4 from DS_SinhVien"
                        + " where MSSV='" + MSSV + "'";
            kn.Mo();
            SqlDataReader rd = kn.ExecuteReader(sql);
            double kq = -1;
            while (rd.Read())
            {
                kq = double.Parse(rd["diem_HS4"].ToString());
            }
            kn.Dong();
            return kq;
        }
        public List<DTO_CNPM> SVKN_CNPM() {
            string sql = "select * from DS_SinhVien"
                       + " where LT_NMLT>4 and TH_NMLT>4 and TH_LTHDT>4"
                       + " and LT_LTHDT>4 and LT_CTDLGT>4 and TH_CTDLGT>4";
            List<DTO_CNPM> dssv = new List<DTO_CNPM>();
            try
            {
                kn.Mo();
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read())
                {
                    DTO_CNPM sv = new DTO_CNPM();
                    sv.MSSV1 = rd["MSSV"].ToString();
                    sv.LT_CTDLGT1 = double.Parse(rd["LT_CTDLGT"].ToString());
                    sv.LT_LTHDT1 = double.Parse(rd["LT_LTHDT"].ToString());
                    sv.LT_NMLT1 = double.Parse(rd["LT_NMLT"].ToString());
                    sv.TH_CTDLGT1 = double.Parse(rd["TH_CTDLGT"].ToString());
                    sv.TH_LTHDT1 = double.Parse(rd["TH_LTHDT"].ToString());
                    sv.TH_NMLT1 = double.Parse(rd["TH_NMLT"].ToString());
                    dssv.Add(sv);
                }
                kn.Dong();
                return dssv;
            }
            catch
            {
                return dssv;
            }
        }
        public List<DTO_HTTT> SVKN_HTTT()
        {
            string sql = "select * from DS_SinhVien"
                       + " where HQT_CSDL>4 and LT_CSDL>4 and TH_CSDL>4";
            List<DTO_HTTT> dssv = new List<DTO_HTTT>();
            try
            {
                kn.Mo();
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read())
                {
                    DTO_HTTT sv = new DTO_HTTT();
                    sv.MSSV1 = rd["MSSV"].ToString();
                    sv.HQT_CSDL1 = double.Parse(rd["HQT_CSDL"].ToString());
                    sv.LT_CSDL1 = double.Parse(rd["LT_CSDL"].ToString());
                    sv.TH_CSDL1 = double.Parse(rd["TH_CSDL"].ToString());
                    dssv.Add(sv);
                }
                kn.Dong();
                return dssv;
            }
            catch
            {
                return dssv;
            }
        }
        public List<DTO_MMT> SVKN_MMT()
        {
            string sql = "select * from DS_SinhVien"
                       + " where LT_MMT>4 and TH_MMT>4 and KTMT>4"
                       + " and HDH>4";
            List<DTO_MMT> dssv = new List<DTO_MMT>();
            try
            {
                kn.Mo();
                SqlDataReader rd = kn.ExecuteReader(sql);
                while (rd.Read())
                {
                    DTO_MMT sv = new DTO_MMT();
                    sv.MSSV1 = rd["MSSV"].ToString();
                    sv.HDH1 = double.Parse(rd["HDH"].ToString());
                    sv.KTMT1 = double.Parse(rd["KTMT"].ToString());
                    sv.LT_MMT1 = double.Parse(rd["LT_MMT"].ToString());
                    sv.TH_MMT1 = double.Parse(rd["TH_MMT"].ToString());
                    dssv.Add(sv);
                }
                kn.Dong();
                return dssv;
            }
            catch
            {
                return dssv;
            }
        }

       

        public bool KiemTra_Trung(List<DTO_CNPM> dsSV_CNPM, List<DTO_HTTT> dsSV_HTTT , DTO_SinhVien sv)
        {//Kiểm tra trùng giữa phần tử n với tất cả các phần tử bắt đầu của cụm
            if (dsSV_CNPM[0].MSSV1 == sv.MSSV1)
                {
                    return false;
                }
            if (dsSV_HTTT.Count > 0)
            {
                if (dsSV_HTTT[0].MSSV1 == sv.MSSV1)
                {
                    return false;
                }
            }
            return true;
        }

        public void kMeans() {
            //
            List<DTO_CNPM> dsSV_CNPM = new List<DTO_CNPM>();
            List<DTO_HTTT> dsSV_HTTT = new List<DTO_HTTT>();
            List<DTO_MMT> dsSV_MMT = new List<DTO_MMT>();
            //Random tâm cụm bắt đầu
            Random r = new Random();
            //CNPM
            //int n = r.Next() % SVKN_CNPM().Count();
            int n = 0;
            dsSV_CNPM.Add(SVKN_CNPM()[n]);
            //HTTT
            n = 2;
            while (!KiemTra_Trung(dsSV_CNPM, dsSV_HTTT, getDSDV()[n]))
            {
                n = r.Next() % SVKN_HTTT().Count();
            }
            dsSV_HTTT.Add(SVKN_HTTT()[n]);
            //MMT
            n = 2;
            while (!KiemTra_Trung(dsSV_CNPM, dsSV_HTTT, getDSDV()[n]))
            {
                n = r.Next() % SVKN_MMT().Count();
            }
            dsSV_MMT.Add(SVKN_MMT()[n]);
            Console.WriteLine(dsSV_CNPM[0].MSSV1 + "  " + dsSV_HTTT[0].MSSV1 + "  " + dsSV_MMT[0].MSSV1);
        }

    }
}
