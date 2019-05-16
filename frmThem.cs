using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace DoAnTotNghiep_QuanLyTuyenSinh_v0._4
{
    public partial class frmThem : DevExpress.XtraEditors.XtraForm
    {
        public frmThem()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        //khởi tạo biến kết nối.
        String ketnoi = "Data Source = DESKTOP-5PSSEM5\\SQLEXPRESS; Initial Catalog = QLTuyenSinh_2; Integrated Security = true";
        // khởi tạo biến kiểm tra
        int kiemtra = 0;
        int xet = 0;

        string dantoc = "";
        string manganh = "";
        int he = 0;

        private void expandablePanel1_Click(object sender, EventArgs e)
        {
            expandablePanel1.Visible = true;
        }

        // xử lý combobox ngành
        private void cbbxNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chuoi = cbbxNganh.SelectedItem.ToString();
            manganh = chuoi.Substring(0, 3);
        }

        // xử lý textbox hệ
        private void tbHe_TextChanged(object sender, EventArgs e)
        {
            string a = "";
            if (tbHe.Text == "Cao Đẳng")
            {
                a = "select * from NGANH WHERE khoi = '" + tbkhoi1.Text + "'and left(manganh, 1)='C'";
            }
            if (tbHe.Text == "Đại học")
            {
                a = "select * from NGANH where khoi '" + tbkhoi1.Text + "'and left(manganh, 1)<>'C'";
            }
            cbbxNganh.Items.Clear();
            SqlConnection obconn = new SqlConnection();
            obconn.Open();
            SqlCommand cm = new SqlCommand(a, obconn);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cbbxNganh.Items.Add(dr["Manganh"].ToString() + " | " + dr["Ten_nganh"].ToString());
            }
            obconn.Close();
            cbbxNganh.SelectedIndex = 0;
        }

        // xử lý nút tìm
        private void btxTim_Click(object sender, EventArgs e)
        {
            cbbxNguyenvong.SelectedIndex = -1;

            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            string a = "Select * from ABC";
            obconn.Open();
            SqlCommand cm = new SqlCommand(a, obconn);
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                if (tbtruong.Text == dr["truong"].ToString() && tbkhoi.Text == dr["khoi"].ToString() && tbSBD.Text == dr["sobaodanh"].ToString())
                {
                    tbTuyenSinh.Text = dr["bants"].ToString();
                    tbDonVi.Text = dr["donvidt"].ToString();
                    tbHo.Text = dr["ho"].ToString();
                    tbTen.Text = dr["ten"].ToString();
                    tbGioi.Text = dr["phai"].ToString();
                    dantoc = dr["dantoc"].ToString();
                    tbNgaySinh.Text = dr["ngaysinh"].ToString();
                    tbDoiTuongUT.Text = dr["doituong"].ToString();
                    tbNhomUT.Text = dr["khuvuc"].ToString();
                    tbTinh.Text = dr["tinh"].ToString();
                    tbHuyen.Text = dr["huyen"].ToString();
                    tbLop10.Text = dr["lop10"].ToString();
                    tbLop11.Text = dr["lop11"].ToString();
                    tbLop12.Text = dr["lop12"].ToString();
                    tbTotNghiep.Text = dr["namtn"].ToString();
                    tbMon1.Text = dr["Dm1"].ToString();
                    tbMon2.Text = dr["Dm2"].ToString();
                    tbMon3.Text = dr["Dm3"].ToString();
                    tbDiemTC.Text = dr["DiemTC"].ToString();
                    tbDiemTron.Text = dr["DiemLT"].ToString();
                    tbSoBaoDanh.Text = dr["sobaodanh"].ToString();
                    tbDotXet.Text = dr["Dotxet"].ToString();
                    tbTruong1.Text = dr["Matruong"].ToString();
                    tbkhoi.Text = dr["Khoi"].ToString();
                    kiemtra = 0;
                    break;
                }
                else
                {
                    kiemtra = 1;
                }
                // đóng kết nối
                obconn.Close();
                if (tbKhuVuc.Text == "3" && tbNhomUT.Text == "3")
                {
                    tbDiemUT.Text = "0000";
                }
                else if (tbKhuVuc.Text == "3" && tbNhomUT.Text == "2")
                {
                    tbDiemUT.Text = "0100";
                }
                else if (tbKhuVuc.Text == "3" && tbNhomUT.Text == "1")
                {
                    tbDiemUT.Text = "0200";
                }
                else if (tbKhuVuc.Text == "2" && tbNhomUT.Text == "3")
                {
                    tbDiemUT.Text = "0050";
                }
                else if (tbKhuVuc.Text == "2" && tbNhomUT.Text == "2")
                {
                    tbDiemUT.Text = "0150";
                }
                else if (tbKhuVuc.Text == "2" && tbNhomUT.Text == "1")
                {
                    tbDiemUT.Text = "0250";
                }
                else if (tbKhuVuc.Text == "2NT" && tbNhomUT.Text == "3")
                {
                    tbDiemUT.Text = "0100";
                }
                else if (tbKhuVuc.Text == "2NT" && tbNhomUT.Text == "2")
                {
                    tbDiemUT.Text = "0200";
                }
                else if (tbKhuVuc.Text == "2NT" && tbNhomUT.Text == "1")
                {
                    tbDiemUT.Text = "0300";
                }
                else if (tbKhuVuc.Text == "1" && tbNhomUT.Text == "3")
                {
                    tbDiemUT.Text = "0150";
                }
                else if (tbKhuVuc.Text == "1" && tbNhomUT.Text == "2")
                {
                    tbDiemUT.Text = "0250";
                }
                else if (tbKhuVuc.Text == "1" && tbNhomUT.Text == "1")
                {
                    tbDiemUT.Text = "0350";
                }
                if (int.Parse(tbDiemTron.Text) + int.Parse(tbDiemUT.Text) >= 1300 && (tbkhoi.Text != "B" || tbkhoi.Text != "C"))
                {
                    he = 0;
                }
                if (int.Parse(tbDiemTron.Text) + int.Parse(tbDiemUT.Text) >= 1400)
                {
                    he = 0;
                }
                if (int.Parse(tbDiemTron.Text) + int.Parse(tbDiemUT.Text) < 1000)
                {
                    he = 2;
                }
                else
                {
                    he = 1;
                }
                if (he == 0 && tbTruong1.Text[0] != 'C')
                {
                    tbHe.Text = "Đại học";
                }
                else if (he == 0 && tbTruong1.Text[0] == 'C')
                {
                    tbHe.Text = "Cao đẳng";
                }
                if (kiemtra == 1)
                {
                    MessageBox.Show("Thí sinh bạn cần tìm không có", "thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string d = "select * from NGANH where manganh = '" + manganh + "' and khoi='" + tbkhoi1.Text + "'";
                    obconn.Open();
                    SqlCommand cmtt = new SqlCommand(d, obconn);
                    SqlDataReader drtt = cmtt.ExecuteReader();
                    while (drtt.Read())
                    {
                        if (int.Parse(tbDiemTron.Text) + int.Parse(tbDiemUT.Text) >= int.Parse(drtt["Diemchuan"].ToString()))
                        {
                            tbTrungTuyen.Text = "TRUE";
                        }
                        else
                        {
                            tbTrungTuyen.Text = "FALSE";
                        }
                    }
                    obconn.Close();
                }
            }
         }

        // xử lý nút lưu
        private void btxLuu_Click(object sender, EventArgs e)
        {
            if (he == 2)
            {
                MessageBox.Show("Thí sinh  không đủ điểm sàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlConnection obconn = new SqlConnection();
                obconn.ConnectionString = ketnoi;
                string a = "select * from DHV where Matruong ='" + tbtruong.Text + "'and Makhoi= '" + tbkhoi.Text + "'and SBD = '" + tbSBD.Text + "'";
                obconn.Open();
                SqlCommand cm = new SqlCommand(a, obconn);
                SqlDataReader dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        xet = 1;
                        break;
                    }
                    else
                    {
                        xet = 0;
                    }
                }
                obconn.Close();
                int max = 0;
                if (tbTrungTuyen.Text == "")
                {
                    MessageBox.Show("Dữ liệu không hợp lệ, xin kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    xet = 0;
                }
                else if (xet == 0)
                {
                    max = 0;
                    string b = "selected max(STT) as max from DHV";
                    SqlCommand cmmax = new SqlCommand(b, obconn);
                    SqlDataReader drmax = cmmax.ExecuteReader();
                    while (drmax.Read())
                    {
                        max = int.Parse(drmax["max"].ToString());
                    }
                    obconn.Close();
                    max = max + 1;
                    DialogResult thongbao = MessageBox.Show("Bạn muốn thêm dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (thongbao == DialogResult.Yes)
                    {
                        string c = "insert into DHV (STT, Mabants, Madonvidt, Matruong, Makhoi, truong2, khoi2, Manganh, Ho, Ten, Gioi_tinh, SBD, Ngay_sinh, Dan_toc, Matinh, Mahuyen, Doituong, Nhom_UT, Namtn, Lop_10, Lop_11, Lop_12,";
                        c += "Dm1, Dm2, Dm3, DiemTC, DiemLT, Khuvuc, Dotxet, Nguyenvong, DiemUT, Trungtuyen, Diemchuan) values('" + max + "','" + tbTuyenSinh.Text + "','" + tbDonVi.Text + "','" + tbTruong1.Text + "','";
                        c += "" + tbkhoi1.Text + "',' DHV ','" + tbkhoi1.Text + "','" + manganh + "',N'" + tbHo.Text + "',N'" + tbTen.Text + "','" + tbGioi.Text + "','" + tbSoBaoDanh.Text + "','" + tbNgaySinh.Text + "','";
                        c += "" + dantoc + "','" + tbTinh.Text + "','" + tbHuyen.Text + "','" + tbDoiTuongUT.Text + "','" + tbNhomUT.Text + "','" + tbTotNghiep.Text + "','" + tbLop10.Text + "','" + tbLop11.Text + "','" +
                            tbLop12.Text + "','";
                        c += "" + tbMon1.Text + "','" + tbMon2.Text + "','" + "','" + tbMon3.Text + "','" + tbDiemTC.Text + "','" + tbDiemTron.Text + "','" + tbKhuVuc.Text + "','" + tbDotXet.Text + "','" + cbbxNguyenvong.SelectedItem.ToString() + "','" + tbDiemUT.Text + "','" + "','" + tbTrungTuyen.Text + "','0')";
                        obconn.Open();
                        SqlCommand cmthem = new SqlCommand(c, obconn);
                        SqlDataReader drthem = cmthem.ExecuteReader();
                        obconn.Close();
                        MessageBox.Show("Dữ liệu thí sinh đã được thêm!", "thông báo!");
                    }
                }
            }
        }

        // Xử lý nút thoát
        private void btxthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThem_Load(object sender, EventArgs e)
        {

        }
    }
}