using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMem_HoTroChonChuyenNganh.BUS;

namespace PhanMem_HoTroChonChuyenNganh
{
    public partial class Form1 : Form
    {
        BUS_ChuyenNganh busCN = new BUS_ChuyenNganh();
        BUS_MONHOC busMH = new BUS_MONHOC();
        BUS_SinhVien busSV = new BUS_SinhVien();
        public Form1()
        {
            InitializeComponent();
            busSV.kMeans();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load combox tên các môn học của học sinh viên
            cboTenMH.Items.AddRange(busMH.loadFull_TenMH());
        }
        public void load_Tre()
        {
            treChuyenNganh.Nodes.Clear();
            //Load nodes cha
            for (int i = 0; i < busCN.loadChuyenNganh().Count(); i++)
            {
                treChuyenNganh.Nodes.Add(busCN.loadChuyenNganh()[i]);
            }
            //Load nodes con
            for (int i = 0; i < busCN.loadChuyenNganh().Count(); i++)
            {
                for (int j = 0; j < busMH.loadTenMH_TheoCN(treChuyenNganh.Nodes[i].Text).Count(); j++) {
                    treChuyenNganh.Nodes[i].Nodes.Add(busMH.loadTenMH_TheoCN(treChuyenNganh.Nodes[i].Text)[j]);
                }
            }
            treChuyenNganh.ExpandAll();
        }

        private void btn_HienCN_Click(object sender, EventArgs e)
        {
            //Hiển thị tên các chuyên ngành
            load_Tre();
        }

        private void dgv_DSSV_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgv_DSSV.CurrentRow != null) {
            //    txtHoTen.Text = dgv_DSSV.CurrentRow.Cells[1].Value.ToString();
            //    txtMSSV.Text = dgv_DSSV.CurrentRow.Cells[0].Value.ToString();
            //}
            //cboDiemSo.Text = cboDiemSo.Items[0].ToString();
            //cboTenMH.Text = cboTenMH.Items[0].ToString();
            //cboDiemSo_SelectedIndexChanged(sender, e);
            //cboTenMH_SelectedIndexChanged(sender, e);
        }

        public double getDiemMH(string MSSV, string tenMH) {
            double kq = -1;
            for(int i=0;i<dgv_DSSV.Columns.Count;i++)
            {
                if (dgv_DSSV.Columns[i].HeaderText == tenMH.ToUpper())
                {
                    kq = double.Parse(dgv_DSSV.CurrentRow.Cells[i].Value.ToString());
                }
            }
            return kq;
        }

        private void cboDiemSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgv_DSSV.CurrentRow != null)
            {
                if (cboDiemSo.Text == "ĐIỂM HỆ SỐ 10")
                {
                    txtDiemHeSo.Text = busSV.getDiemHS_10(txtMSSV.Text).ToString();
                }
                if (cboDiemSo.Text == "ĐIỂM HỆ SỐ 4")
                {
                    txtDiemHeSo.Text = busSV.getDiemHS_4(txtMSSV.Text).ToString();
                }
            }
        }

        private void cboTenMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Lấy điểm môn học theo comboBox
            if(dgv_DSSV.CurrentRow !=null)
                txtDiemMH.Text = getDiemMH(dgv_DSSV.CurrentRow.Cells[0].Value.ToString(), cboTenMH.Text).ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Load dataGridView 
            dgv_DSSV.DataSource = busSV.getDSDV();
            lbSoLuongSV.Text = "Tổng sinh viên sau khi lọc: " + dgv_DSSV.RowCount.ToString() + " sinh viên";
            lbSoLuongSV.Visible = true;
        }


        private void treChuyenNganh_AfterSelect(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < treChuyenNganh.Nodes.Count; i++)
            {
                if (treChuyenNganh.Nodes[i].IsSelected)
                {
                    if (treChuyenNganh.Nodes[i].Text == "Công nghệ phần mềm")
                    {
                        dgv_DSSV.DataSource = busSV.SVKN_CNPM();
                        lbSoLuongSV.Text = "Tổng sinh viên sau khi lọc: " + dgv_DSSV.RowCount.ToString() + " sinh viên";
                        lbSoLuongSV.Visible = true;
                    }
                    if (treChuyenNganh.Nodes[i].Text == "Hệ thống thông tin")
                    {
                        dgv_DSSV.DataSource = busSV.SVKN_HTTT();
                        lbSoLuongSV.Text = "Tổng sinh viên sau khi lọc: " + dgv_DSSV.RowCount.ToString() + " sinh viên";
                        lbSoLuongSV.Visible = true;
                    }
                    if (treChuyenNganh.Nodes[i].Text == "Mạng máy tính")
                    {
                        dgv_DSSV.DataSource = busSV.SVKN_MMT();
                        lbSoLuongSV.Text = "Tổng sinh viên sau khi lọc: " + dgv_DSSV.RowCount.ToString() + " sinh viên";
                        lbSoLuongSV.Visible = true;
                    }
                }
            }
        }
    }
}
