using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhanMem_HoTroChonChuyenNganh.DAL
{
    class DAL_KetNoiSQL
    {
        public SqlConnection cnn = new SqlConnection("Data Source=DESKTOP-5V9RJ2M\\SQLEXPRESS;Initial Catalog=dbQuanLySinhVienDH;Integrated Security=True");
        SqlDataAdapter da;
        DataTable dt;
        public DataTable getData(string sql)
        {
            da = new SqlDataAdapter(sql, cnn);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void Mo()
        {
            if (cnn.State == System.Data.ConnectionState.Closed)
                cnn.Open();
        }
        public void Dong()
        {
            if (cnn.State == System.Data.ConnectionState.Open)
                cnn.Close();
        }
        public int ExecuteScalar(string sql)
        {
            int kq = -1;
            try
            {
                Mo();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                kq = (int)cmd.ExecuteScalar();
                Dong();
                return kq;
            }
            catch
            {
                return kq;
            }
        }
        public bool ExecuteNonQuery(string sql)
        {
            try
            {
                Mo();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                Dong();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader rd = cmd.ExecuteReader();
                return rd;
            }
            catch
            {
                return null;
            }
        }
    }
}
