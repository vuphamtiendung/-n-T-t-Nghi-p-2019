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
using System.Threading;

namespace DoAnTotNghiep_QuanLyTuyenSinh_v0._4
{
    public partial class frmQuantri : DevExpress.XtraEditors.XtraForm
    {
        public frmQuantri()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        // 1. thực hiện viết chuỗi kết nối
        // Initial Catalog, đây là chỉ định cách kết nối đến cơ sở dữ liệu
        // Trên máy của chúng ta thường để Windows Authentication, cho nên tham số Intergrated Security mang giá trị True như trên khi kết nối.
        String ketnoi = "Data Source = DESKTOP-5PSSEM5\\SQLEXPRESS; Initial Catalog = QLTuyenSinh_2; Integrated Security = true";
        // 2. Khởi tạo biến i kiểu số nguyên, gán giá trị ban đầu bằng 0
        int i = 0;
        // 3. Khởi tạo biến manganh(mã ngành) kiểu chuỗi.
        string manganh;
        // 4. Khởi tạo biến a kiểu chuỗi, gán giá trị của a ban đầu bằng rỗng.
        string a = "";
        // 5. khởi tạo biến lớp 10, lớp 11, lớp 12 kiểu chuỗi, gán giá trị ban đầu bằng rỗng.
        string lop10 = "", lop11 = "", lop12 = "";
        // 6. khai báo các biến kiểu chuỗi, gán giá trị chúng ban đầu bằng rỗng bao gồm:
        string sbdsua = "", truongsua = "", khoisua = "";
        string chuoi1 = "", chuoi2 = "", ma_t = "", ma_h = "", cbmabants = "", cbmadonvidt = "";
        string cbnganh = "", cbmalop_10 = "", cbmalop_11 = "", cbmalop_12 = "", cbmatruongdk = "";




        // xử lý menu hack
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // xử lý menu tra cứu
        private void traCứuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuantri fr = new frmQuantri();
            fr.ShowDialog();
        }
        
        // xử lý menuStrip thêm thí sinh
        private void thêmThíSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThem fm = new frmThem();
            fm.ShowDialog();
        }

        // Xử lý sự kiện thống kê
        // số lượng thí sinh theo khối
        private void sốLượngThíSinhTheoKhốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongke_1 fmtk = new thongke_1();
            fmtk.ShowDialog();
        }

        // Thí sinh theo ngành
        private void thíSinhTheoNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thongke_2 thongke = new thongke_2();
            thongke.ShowDialog();
        }

        // thí sinh theo nguyện vọng
        private void thíSinhTheoNguyệnVọngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //thongke_3 fm = new thongke_3();
            //fm.ShowDialog();
        }

        /*  Số lượng thí sinh theo điểm */
        private void sốLượngThíSinhTheoĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //thongke_4 fm = new thongke_4();
            //fm.ShowDialog();
        }

        /* Thí sinh theo điểm chuẩn */
        private void thíSinhTheoĐiểmChuẩnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmttuyendiemchuan fmt = new fmttuyendiemchuan();
            //fmt.ShowDialog();
        }

        // in danh sách trúng tuyển 
        private void danhSáchThíSinhTrúngTuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmintrungtuyen fmin = new fmintrungtuyen();
            //fmin.ShowDialog();
        }

        // In danh sách không trúng tuyển
        private void danhSáchThíSinhKhôngTrúngTuyểnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmktrungtuyen fmin = new fmktrungtuyen();
            //fmin.ShowDialog();
        }

        // Ban tuyển sinh
        private void banTuyểnSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmbantuyensinh fmdm = new fmdmbantuyensinh();
            //fmdm.ShowDialog();
        }

        // Tỉnh, thành phố
        private void tỉnhThànhPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdtinh fmdm = new fmdmtinh();
            //fmdm.ShowDialog();
        }

        // Quận, huyện
        private void quậnHuyệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmquan fmdm = new fmdmquan();
            //fmdm.ShowDialog();
        }

        // trường trung học phổ thông
        private void trườngTrungHọcPhổThôngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmtruongpt fmdm = new fmdmtruongpt;
            //fmdm.ShowDialog();
        }

        // khu vực ưu tiên
        private void khuVựcƯuTiênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmkhuvuc fmdm = new fmdmkhuvuc();
            //fmdm.ShowDialog();
        }

        // Đối tượng ưu tiên
        private void đốiTượngƯuTiênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmdoituong fmdm = new fmdmdoituong();
            //fmdm.ShowDialog();
        }

        // trường đại học - cao đẳng
        private void trườngĐạiHọcCaoĐẳngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmtruong fmdm = new fmdmtruong();
            //fmdm.ShowDialog();
        }

        // Khối và môn thi
        private void khốiVàMônThiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmkhoi fmdm = new fmdmkhoi();
            //fmdm.ShowDialog();
        }

        // ngành
        private void ngànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fmdmnganh fmdm = new fmdmnganh();
            //fmdm.ShowDialog();
        }

        // xử lý combobox ban tuyển sinh
        private void cbbxBTS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox đơn vị đăng ký dự thi */
        private void cbbxDVDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox tỉnh thành */
        private void cbbTinh1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox Huyen */
        private void cbbHuyen1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        /* xử lý combobox lớp 10 */
        private void cbb_Lop10_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox lớp 11 */
        private void cbb_Lop11_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox lớp 12 */
        private void cbb_Lop12_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        /* xử lý combobox đăng ký dự thi */
        private void cbbTruongDK_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /* xử lý combobox đăng lý dự thi */
        private void cbb_Nganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        /* xử lý combobox nguyện vọng */
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // xử lý combobox ban tuyển sinh
        private void cbbxBTS_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1. Xóa items được chọn trong combobox đơn vị đăng ký dự thi.
            cbbxDVDK.Items.Clear();
            // 2. Khởi tạo biến tam kiểu chuỗi, lấy giá trị các item trong combobox bỏ vào biến tam
            string tam = cbbxBTS.SelectedItem.ToString();
            // 3. Sử dụng hàm Substring để cắt 2 ký tự trong biến tạm, bắt đầu bằng ký tự 0 sau đó gán vào cho biến cbmabants.
            cbmabants = tam.Substring(0, 2);
            // 4. Tạo câu lệnh kết nối cơ sở dữ liệu.
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            // 5. Thực hiện câu lệnh truy vấn cơ sở dữ liệu. Lấy về tất cả các cột trong bảng DONVIDT với trường Mabants.
            a = "select * from DONVIDT where Mabants = '" + cbmabants + "'";
            // Mở câu lệnh kết nối
            obconn.Open();
            // 6. Sử dụng SqlCommand để thực thi các câu lệnh sql, tạo đối tượng mới gắn vào biến cmdonvi.
            SqlCommand cmdonvi = new SqlCommand(a, obconn);
            // 7. Tạo DataReader gán vào biến drtruong.
            SqlDataReader drdonvi = cmdonvi.ExecuteReader();
            // 8. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            while (drdonvi.Read())
            {
                // 9. Add cột Madonvidt và cột Ten_don_vi_dt vào combobox đơn vị đăng kí dự thi.
                cbbxDVDK.Items.Add(drdonvi["Madonvidt"].ToString() + " | " + drdonvi["Ten_don_vi_dt"].ToString());
            }
            // 10. Đóng kết nối với cơ sở dữ liệu.
            obconn.Close();
        }


        // Xử lý sự kiện combobox đơn vị đăng ký dự thi
        private void cbbxDVDK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1. khởi tạo biến tam kiểu chuỗi, lấy giá trị các item trong combobox đơn vị đăng kí bỏ vào biến tam
            string tam = cbbxDVDK.SelectedItem.ToString();
            // 2. Sử dụng hàm Substring để cắt 2 ký tự trong biến tạm, bắt đầu bằng ký tự 0 sau đó gán vào cho biến cbmadonvidt.
            cbmadonvidt = tam.Substring(0, 2);
        }

        /* xử lý combobox tỉnh thành */
        private void cbbTinh1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1. khởi tạo biến cbTinh kiểu chuỗi, lấy về giá trị trong combobox tỉnh gán vào biến cbTinh */
            string cbTinh = cbbTinh1.SelectedItem.ToString();
            // 2. Sử dụng hàm Substring cắt bỏ chuỗi cbTinh, bắt đầu với ký tự thứ 5 và lấy chiều dài còn lại trong chuỗi, sau đó gán giá trị này cho biến tbHoKhau.
            tbHoKhau.Text = cbTinh.Substring(5, cbTinh.Length - 5);
            // 3. Gán giá trị tbHokhau cho biến chuoi1.
            chuoi1 = tbHoKhau.Text;
            // 4. Cắt lấy 2 ký tự trong chuỗi cbTinh, bắt dầu bằng ký tự 0 rồi gán cho biến ma_t.
            ma_t = cbTinh.Substring(0, 2);
            // 5. Xóa giá trị được chọn để về giá trị ban đầu trong combobox huyện.
            cbbHuyen1.Items.Clear();
            // 6. thực hiện kết nói csdl
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            // 7. Truy vấn toàn bộ dữ liệu trong bảng HUYEN.
            a = "select * from HUYEN";
            obconn.Open(); // mở câu lệnh kết nối.
            // 8. Sử dụng SqlCommand để thực thi các câu lệnh sql, tạo đối tượng mới gán vào biến cm1.
            SqlCommand cm1 = new SqlCommand(a, obconn);
            // 9. tạo datareader gán vào biến dr1.
            SqlDataReader dr1 = cm1.ExecuteReader();
            // 10. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            while (dr1.Read())
            {
                if (ma_t == dr1["Matinh"].ToString())
                {
                    cbbHuyen1.Items.Add(dr1["Mahuyen"].ToString() + " | " + dr1["Ten_huyen"].ToString());
                }
            }
            obconn.Close(); // đóng kết nối.
        }

        /* xử lý combobox Huyen */
        private void cbbHuyen1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1
            string cbhuyen = cbbHuyen1.SelectedItem.ToString();
            // 2.
            ma_h = cbhuyen.Substring(0, 2);
            // 3.
            chuoi2 = cbhuyen.Substring(5, cbhuyen.Length - 5);
            // 4.
            tbHoKhau.Text = chuoi1 + "," + chuoi2;
        }

        /* xử lý combobox lớp 10 */
        private void cbb_Lop10_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1.
            string t1 = cbb_Lop10.SelectedItem.ToString();
            // 2. 
            tbLop10.Text = t1.Substring(8, t1.Length - 8);
            // 3.
            cbmalop_10 = t1.Substring(0, 5);
        }

        /* xử lý combobox lớp 11 */
        private void cbb_Lop11_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1.
            string t2 = cbb_Lop11.SelectedItem.ToString();
            // 2. 
            tbLop11.Text = t2.Substring(8, t2.Length - 8);
            // 3.
            cbmalop_11 = t2.Substring(0, 5);
        }

        /* xử lý combobox lớp 12 */
        private void cbb_Lop12_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1.
            string t3 = cbb_Lop12.SelectedItem.ToString();
            // 2. 
            tbLop12.Text = t3.Substring(8, t3.Length - 8);
            // 3.
            cbmalop_12 = t3.Substring(0, 5);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /* xử lý combobox đăng ký dự thi */
        private void cbbTruongDK_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string tam = cbbTruongDK.SelectedItem.ToString();
            cbmatruongdk = tam.Substring(0, 3);
        }

        // xử lý combobox ngành
        private void cbb_Nganh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // 1.
            string tamcbnganh = cbb_Nganh.SelectedItem.ToString();
            // 2.
            cbnganh = tamcbnganh.Substring(0, 3);
            // 3. 
            if (cbnganh[0] == 'C')
            {
                tbHe.Text = "Cao đẳng";
            }
            else
            {
                tbHe.Text = "Đại học";
            }
        }

        /* xử lý combobox nguyện vọng */
        private void comboBoxEx1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataSet dataset = FillDataset("select STT, D.Mabants, D.Madonvidt, D.Matruong, Khoi, Truong2, Khoi2, D.Manganh, SBD, Ho, Ten, Gioi_tinh, Ngay_sinh, Ten_khu_vuc, Ten_truong, DiemUT, DiemTC, DiemLT,"
            + "D.Matinh, D.Mahuyen, D.Doituong, D.Nhom_UT, D.Namtn, Lop_10, Lop_11, Lop_12, Dm1, Dm2, Dm3, D.Khuvuc, Nguyenvong, Dotxet, Ten_bants, Ten_don_vi_dt, Ten_huyen, Ten_tinh, Ten_nganh, Ten_doi_tuong, Mon_thi_1, Mon_thi_2, Mon_thi_3, Diem_san_dh, Diem_san_cd"
            + "from DHV D, BANTS B, DONVIDT DV, HUYEN H, TINH T, DOITUONG DT, KHOITHI K, NGANH N, KHUVUC KV, TRUONG TR"
            + "where (B.Mabants = D.Mabants) and (DV.Madonvidt = D.Madonvidt) and (DV.Mabants = B.Mabants) and (DV.Mahuyen = H.Mahuyen) and (T.Matinh = D.Matinh) and (H.Matinh = T.Matinh) " + " and (DT.Doituong = D.Doituong) and (K.Khoi = D.Makhoi) and (N.Manganh = D.Manganh) and (N.Khoi = K.Khoi) and (KV.Khuvuc = D.Khuvuc) and (D.Matruong = TR.Matruong) and Nguyenvong = '" + comboBoxEx1.SelectedItem.ToString() + "' order by STT asc");
            // gán dữ liệu vào bảng lấy về trong dataset bỏ vào gridview.
            this.dataGridView1.DataSource = dataset.Tables[0];
            // gán tổng thí sinh tìm được vào labelx1.
            labelx1.Text = "Tổng số thí sinh: " + (dataGridView1.Rows.Count - 1).ToString();
        }

        /* xử lý hàm tracuu() */
        private void tracuu()
        {
            // 1. 
            lop10 = dataGridView1.Rows[i].Cells["Lop_10"].Value.ToString();
            lop11 = dataGridView1.Rows[i].Cells["Lop_11"].Value.ToString();
            lop12 = dataGridView1.Rows[i].Cells["Lop_12"].Value.ToString();
            // khai báo kiểu chuỗi
            string lop10tinh = "", lop10ma = "";
            string lop11tinh = "", lop11ma = "";
            string lop12tinh = "", lop12ma = "";
            // cắt chuỗi.
            lop10tinh = lop10.Substring(0, 2);
            lop10ma = lop10.Substring(2, 3);

            lop11tinh = lop11.Substring(0, 2);
            lop11ma = lop11.Substring(2, 3);

            lop12tinh = lop12.Substring(0, 2);
            lop12ma = lop12.Substring(2, 3);

            // gán giá trị rỗng cho các biến tblLop10, tblLop11, tblLop12
            tbLop10.Text = "";
            tbLop11.Text = "";
            tbLop12.Text = "";

            // thực hiện câu lệnh kết nối csql
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;

            a = "select * from TRUONGPT where Matinh = '" + lop10tinh + "'and Truongpt ='" + lop10ma + "'";
            // mở câu lệnh kết nối
            obconn.Open();
            SqlCommand cmlop10 = new SqlCommand(a, obconn);
            // tạo Datareader gán vào biến drlop10.
            SqlDataReader drlop10 = cmlop10.ExecuteReader();
            while (drlop10.Read())
            {
                tbLop10.Text = drlop10["Ten_truong"].ToString();
            }
            // đóng kết nối.
            obconn.Close();


            a = "select * from TRUONGPT where Matinh = '" + lop11tinh + "'and Truongpt ='" + lop11ma + "'";
            // mở câu lệnh kết nối
            obconn.Open();
            SqlCommand cmlop11 = new SqlCommand(a, obconn);
            // tạo Datareader gán vào biến drlop10.
            SqlDataReader drlop11 = cmlop11.ExecuteReader();
            while (drlop11.Read())
            {
                tbLop11.Text = drlop11["Ten_truong"].ToString();
            }
            // đóng kết nối.
            obconn.Close();


            a = "select * from TRUONGPT where Matinh = '" + lop12tinh + "'and Truongpt ='" + lop12ma + "'";
            // mở câu lệnh kết nối
            obconn.Open();
            SqlCommand cmlop12 = new SqlCommand(a, obconn);
            // tạo Datareader gán vào biến drlop10.
            SqlDataReader drlop12 = cmlop12.ExecuteReader();
            while (drlop12.Read())
            {
                tbLop12.Text = drlop12["Ten_truong"].ToString();
            }
            // đóng kết nối.
            obconn.Close();

            // xét mã ngành là đại học hay cao đẳng.
            manganh = dataGridView1.Rows[i].Cells["Manganh"].Value.ToString();
            if (manganh[0] == 'C')
            {
                tbHe.Text = "Cao đẳng";
            }
            else
            {
                tbHe.Text = "Đại học";
            }
            tbTen.Text = dataGridView1.Rows[i].Cells["Ten"].Value.ToString();
            tbHo.Text = dataGridView1.Rows[i].Cells["Ho"].Value.ToString();
            tbGioi.Text = dataGridView1.Rows[i].Cells["Gioi_tinh"].Value.ToString();
            tbMon1.Text = dataGridView1.Rows[i].Cells["Dm1"].Value.ToString();
            tbMon2.Text = dataGridView1.Rows[i].Cells["Dm2"].Value.ToString();
            tbMon3.Text = dataGridView1.Rows[i].Cells["Dm3"].Value.ToString();
            tbDiemTC.Text = dataGridView1.Rows[i].Cells["DiemTC"].Value.ToString();
            tbDiemTron.Text = dataGridView1.Rows[i].Cells["DiemLT"].Value.ToString();
            tbNgaySinh.Text = dataGridView1.Rows[i].Cells["Ngay_sinh"].Value.ToString();
            tbNguyenVong.Text = dataGridView1.Rows[i].Cells["Nguyenvong"].Value.ToString();
            tbDotXet.Text = dataGridView1.Rows[i].Cells["Dotxet"].Value.ToString();
            tbSoPhieu.Text = dataGridView1.Rows[i].Cells["STT"].Value.ToString();
            tbSoBaoDanh.Text = dataGridView1.Rows[i].Cells["SBD"].Value.ToString();
            tbTotNghiep.Text = dataGridView1.Rows[i].Cells["Namtn"].Value.ToString();
            tbNhomUT.Text = dataGridView1.Rows[i].Cells["Nhom_UT"].Value.ToString();
            tbDoiTuongUT.Text = dataGridView1.Rows[i].Cells["Ten_doi_tuong"].Value.ToString();
            tbkhoi1.Text = dataGridView1.Rows[i].Cells["Khoi"].Value.ToString();
            tbkhoi.Text = dataGridView1.Rows[i].Cells["Khoi"].Value.ToString();
            tbTruong.Text = dataGridView1.Rows[i].Cells["Ten_truong"].Value.ToString();
            tbHoKhau.Text = dataGridView1.Rows[i].Cells["Ten_tinh"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["Ten_huyen"].Value.ToString();
            tbDiemUT.Text = dataGridView1.Rows[i].Cells["DiemUT"].Value.ToString();
        }

        // xử lý nút trở
        private void btxDau_Click_1(object sender, EventArgs e)
        {
            i = 0;
            tracuu();
        }

        // xử lý nút trở về trước
        private void btxTruoc_Click_1(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                tracuu();
            }
        }


        // xử lý nút trở
        private void btxSau_Click_1(object sender, EventArgs e)
        {
            if (i < dataGridView1.Rows.Count - 2)
            {
                i++;
                tracuu();
            }
        }


        // xử lý nút trở về cuối
        private void btxCuoi_Click_1(object sender, EventArgs e)
        {
            i = dataGridView1.Rows.Count - 2;
            tracuu();
        }

        // xử lý nút thêm thông tin
        private void btxThem_Click_1(object sender, EventArgs e)
        {
            frmThem fm = new frmThem();
            fm.ShowDialog();
        }


        // chỉnh sửa thông tin
        private void btxSua_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < cbbxBTS.Items.Count; i++)
            {
                string kytu = cbbxBTS.Items[i].ToString();
            }
            // xử lý combobox lớp 10
            for (int i = 0; i < cbb_Lop10.Items.Count; i++)
            {
                string kytu = cbb_Lop10.Items[i].ToString();
                if (tbLop10.Text == kytu.Substring(8, kytu.Length - 8))
                {
                    cbb_Lop10.SelectedIndex = i;
                }
            }

            // xử lý combobox lớp 11
            for (int i = 0; i < cbb_Lop11.Items.Count; i++)
            {
                string kytu = cbb_Lop11.Items[i].ToString();
                if (tbLop11.Text == kytu.Substring(8, kytu.Length - 8))
                {
                    cbb_Lop11.SelectedIndex = i;
                }
            }

            // xử lý combobox lớp 12
            for (int i = 0; i < cbb_Lop12.Items.Count; i++)
            {
                string kytu = cbb_Lop12.Items[i].ToString();
                if (tbLop12.Text == kytu.Substring(8, kytu.Length - 8))
                {
                    cbb_Lop12.SelectedIndex = i;
                }
            }

            // xử lý cho combobox trường đăng ký
            for (int i = 0; i < cbbTruongDK.Items.Count; i++)
            {
                string kytu = cbbTruongDK.Items[i].ToString();
                if (tbTruong.Text == kytu.Substring(6, kytu.Length - 6))
                {
                    cbbTruongDK.SelectedIndex = i;
                }
            }

            if (tbHe.Text == "Đại học")
            {
                for (int i = 0; i < cbb_Nganh.Items.Count; i++)
                {
                    string kytu = cbb_Nganh.Items[i].ToString();
                }
            }
            else
            {
                for (int i = 0; i < cbb_Nganh.Items.Count; i++)
                {
                    string kytu = cbb_Nganh.Items[i].ToString();
                }
            }

            sbdsua = tbSBD.Text;
            truongsua = tbTruong.Text;
            khoisua = tbkhoi.Text;

            // bật sáng combobox và buttons.
            cbbxBTS.Visible = true;
            cbbxDVDK.Visible = true;
            cbb_Lop10.Visible = true;
            cbb_Lop11.Visible = true;
            cbb_Lop12.Visible = true;
            cbbTinh1.Visible = true;
            cbbHuyen1.Visible = true;
            cbb_Nganh.Visible = true;
            cbbTruongDK.Visible = true;
            btxLuu.Visible = true;
            btxBo.Visible = true;

            // Chỉ đọc mà không được can thiệp.
            tbHo.ReadOnly = false;
            tbTen.ReadOnly = false;
            tbSoBaoDanh.ReadOnly = false;
            tbGioi.ReadOnly = false;
            tbMon1.ReadOnly = false;
            tbMon2.ReadOnly = false;
            tbMon3.ReadOnly = false;
            tbDiemTC.ReadOnly = false;
            tbDiemTron.ReadOnly = false;
            tbDiemUT.ReadOnly = false;
            tbNguyenVong.ReadOnly = false;
            tbDotXet.ReadOnly = false;
            tbkhoi1.ReadOnly = false;
            btxSua.Enabled = false;
            btxThem.Enabled = false;
            btxDau.Enabled = false;
            btxCuoi.Enabled = false;
            btxTruoc.Enabled = false;
            btxSau.Enabled = false;
        }


        // xử lý nút lưu
        private void btxLuu_Click_1(object sender, EventArgs e)
        {
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;

            a = "Update DHV set Ten = N'" + tbTen.Text + "', Ho = N'" + tbHo.Text + "',Matinh = '" + ma_t + "', Mahuyen = '" + ma_h + "',Gioi_tinh = '" + tbGioi.Text + "', SBD= '" + tbSoBaoDanh.Text + "'" + ",Mabants = '" + cbmabants + "', Madonvidt = '" + cbmadonvidt + "', Matruong = '" + cbmatruongdk + "', Khoi = '" + tbkhoi.Text + "', Khoi2 = '" + tbkhoi1.Text + "', Manganh = '" + cbnganh + "', Namtn = '" + tbTotNghiep.Text + "'" + ",Lop_10='" + cbmalop_10 + "', Lop_11='" + cbmalop_11 + "', Lop_12='" + cbmalop_12 + "'where STT = '" + tbSoPhieu.Text + "'";

            obconn.Open();

            SqlCommand cm1 = new SqlCommand(a, obconn);
            SqlDataReader dr1 = cm1.ExecuteReader();
            obconn.Close();

            // ẩn combobox
            cbbxBTS.Visible = false;
            cbbxDVDK.Visible = false;
            cbbTinh1.Visible = false;
            cbbHuyen1.Visible = false;
            tbLop10.Visible = false;
            tbLop11.Visible = false;
            tbLop12.Visible = false;
            cbb_Nganh.Visible = false;
            cbbTruongDK.Visible = false;

            // Hiện combobox và buttons
            btxBo.Enabled = true;
            btxThem.Enabled = true;
            btxLuu.Enabled = true;
            btxSua.Enabled = true;
            btxDau.Enabled = true;
            btxCuoi.Enabled = true;
            btxTruoc.Enabled = true;
            btxSau.Enabled = true;

            // Chỉ cho phép đọc.
            tbHo.ReadOnly = true;
            tbTen.ReadOnly = true;
            tbSoBaoDanh.ReadOnly = true;
            tbGioi.ReadOnly = true;
            tbMon1.ReadOnly = true;
            tbMon2.ReadOnly = true;
            tbMon3.ReadOnly = true;
            tbDiemTC.ReadOnly = true;
            tbDiemTron.ReadOnly = true;
            tbTotNghiep.ReadOnly = true;
            tbDiemUT.ReadOnly = true;
            tbNguyenVong.ReadOnly = true;
            tbDotXet.ReadOnly = true;
            tbkhoi1.ReadOnly = true;

            // gán chỉ số index cho combobox nguyện vọng
            comboBoxEx1.SelectedIndex = 2;
            comboBoxEx1.SelectedIndex = 0;
            tracuu();
        }


        // xử lý nút hủy bỏ thông tin
        private void btxBo_Click_1(object sender, EventArgs e)
        {
            // ẩn các combobox
            cbbxBTS.Visible = false;
            cbbxDVDK.Visible = false;
            cbbTinh1.Visible = false;
            cbbHuyen1.Visible = false;
            cbb_Lop10.Visible = false;
            cbb_Lop11.Visible = false;
            cbb_Lop12.Visible = false;
            cbb_Nganh.Visible = false;
            cbbTruongDK.Visible = false;

            // 
            btxBo.Enabled = false;
            btxLuu.Enabled = false;
            btxThem.Enabled = true;
            btxSua.Enabled = true;
            btxDau.Enabled = true;
            btxCuoi.Enabled = true;
            btxTruoc.Enabled = true;
            btxSau.Enabled = true;

            //
            tbHo.ReadOnly = true;
            tbTen.ReadOnly = true;
            tbSoBaoDanh.ReadOnly = true;
            tbGioi.ReadOnly = true;
            tbMon1.ReadOnly = true;
            tbMon2.ReadOnly = true;
            tbMon3.ReadOnly = true;
            tbDiemTC.ReadOnly = true;
            tbDiemTron.ReadOnly = true;
            tbTotNghiep.ReadOnly = true;
            tbDiemUT.ReadOnly = true;
            tbNguyenVong.ReadOnly = true;
            tbDotXet.ReadOnly = true;
            tbkhoi1.ReadOnly = true;

            //
            tracuu();
        }

        private void btTim_Click_1(object sender, EventArgs e)
        {
            int tam = i;
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if ((dataGridView1.Rows[i].Cells["SBD"].Value.ToString() == tbSBD.Text && dataGridView1.Rows[i].Cells["Khoi"].Value.ToString() == tbkhoi.Text && dataGridView1.Rows[i].Cells["Matruong"].Value.ToString() == tbTruong.Text))
                {
                    tracuu();
                    break;
                }
                else if (i == dataGridView1.Rows.Count - 2)
                {
                    tbDiemTC.Text = "";
                    tbDiemTron.Text = "";
                    tbDiemUT.Text = "";
                    tbDoiTuongUT.Text = "";
                    tbDotXet.Text = "";
                    tbGioi.Text = "";
                    tbHe.Text = "";
                    tbHo.Text = "";
                    tbHoKhau.Text = "";
                    tbkhoi1.Text = "";
                    tbKhuVuc.Text = "";
                    tbLop10.Text = "";
                    tbLop11.Text = "";
                    tbLop12.Text = "";
                    tbMon1.Text = "";
                    tbMon2.Text = "";
                    tbMon3.Text = "";
                    tbNgaySinh.Text = "";
                    tbNguyenVong.Text = "";
                    tbNhomUT.Text = "";
                    tbSoBaoDanh.Text = "";
                    tbSoPhieu.Text = "";
                    tbTen.Text = "";
                    tbTotNghiep.Text = "";
                    tbTruong.Text = "";
                    // Đưa ra thông báo.
                    DialogResult thongbao = MessageBox.Show("Không tìm thấy dữ liệu thí sinh, bạn muốn thêm dữ liệu vào ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (thongbao == DialogResult.Yes)
                    {
                        i = tam;
                        frmThem fm = new frmThem();
                        fm.ShowDialog();
                        break;
                    }
                    else
                    {
                        tbTruong.Text = "";
                        tbkhoi.Text = "";
                        tbSBD.Text = "";
                        i = tam;
                        tracuu();
                        break;
                    }
                }
            }
        }
        // Xử lý nút tìm.
        private void btTim_Click(object sender, EventArgs e)
        {
            int tam = i;
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if ((dataGridView1.Rows[i].Cells["SBD"].Value.ToString() == tbSBD.Text && dataGridView1.Rows[i].Cells["Khoi"].Value.ToString() == tbkhoi.Text && dataGridView1.Rows[i].Cells["Matruong"].Value.ToString() == tbTruong.Text))
                {
                    tracuu();
                    break;
                }
                else if (i == dataGridView1.Rows.Count - 2)
                {
                    tbDiemTC.Text = "";
                    tbDiemTron.Text = "";
                    tbDiemUT.Text = "";
                    tbDoiTuongUT.Text = "";
                    tbDotXet.Text = "";
                    tbGioi.Text = "";
                    tbHe.Text = "";
                    tbHo.Text = "";
                    tbHoKhau.Text = "";
                    tbkhoi1.Text = "";
                    tbKhuVuc.Text = "";
                    tbLop10.Text = "";
                    tbLop11.Text = "";
                    tbLop12.Text = "";
                    tbMon1.Text = "";
                    tbMon2.Text = "";
                    tbMon3.Text = "";
                    tbNgaySinh.Text = "";
                    tbNguyenVong.Text = "";
                    tbNhomUT.Text = "";
                    tbSoBaoDanh.Text = "";
                    tbSoPhieu.Text = "";
                    tbTen.Text = "";
                    tbTotNghiep.Text = "";
                    tbTruong.Text = "";
                    // Đưa ra thông báo.
                    DialogResult thongbao = MessageBox.Show("Không tìm thấy dữ liệu thí sinh, bạn muốn thêm dữ liệu vào ?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (thongbao == DialogResult.Yes)
                    {
                        i = tam;
                        frmThem fm = new frmThem();
                        fm.ShowDialog();
                        break;
                    }
                    else
                    {
                        tbTruong.Text = "";
                        tbkhoi.Text = "";
                        tbSBD.Text = "";
                        i = tam;
                        tracuu();
                        break;
                    }
                }
            }
        }

        /* xử lý nút trở */
        private void btxDau_Click(object sender, EventArgs e)
        {
           
        }

        /* xử lý nút trở về trước */
        private void btxTruoc_Click(object sender, EventArgs e)
        {
            
        }

        /* xử lý nút trở */
        private void btxSau_Click(object sender, EventArgs e)
        {
           
        }

        /* xử lý nút trở về cuối */
        private void btxCuoi_Click(object sender, EventArgs e)
        {
            
        }

        /* xử lý nút thêm thông tin */
        private void btxThem_Click(object sender, EventArgs e)
        {
            frmThem fm = new frmThem();
            fm.ShowDialog();
        }

        /* xử lý nút sửa thông tin */
        private void btxSua_Click(object sender, EventArgs e)
        {
        }

        /* xử lý nút lưu */
        private void btxLuu_Click(object sender, EventArgs e)
        {
            
        }

        /*xử lý nút xóa bỏ thông tin */
        private void btxBo_Click(object sender, EventArgs e)
        {
            
        }

        
        private void frmQuantri_Load(object sender, EventArgs e)
        {
            //Gán giá trị đầu tiên trên combobox ban tuyển sinh là 0
            comboBoxEx1.SelectedItem = -1;
            cbbxBTS.Visible = false; // ẩn combobox
            cbbxDVDK.Visible = false; // ẩn combobox đơn vị đăng kí dự thi.
            cbbTinh1.Visible = false; // ẩn combobox ẩn combobox tỉnh(tại dòng hộ khẩu).
            cbbHuyen1.Visible = false; // ẩn combobox huyện(tại dòng hộ khẩu).
            cbb_Lop10.Visible = false; // ẩn combobox lớp 10.
            cbb_Lop11.Visible = false; // ẩn combobox lớp 11.
            cbb_Lop12.Visible = false; // ẩn combobox lớp 12.
            cbb_Nganh.Visible = false; // ẩn combobox ngành đăng ký dự thi.
            cbbTruongDK.Visible = false; // ẩn combobox trường đăng ký dự thi.
            btxBo.Enabled = false; // ẩn button bỏ dữ liệu.
            btxThem.Enabled = true; // bật sáng button thêm dữ liệu.
            btxLuu.Enabled = false; // ẩn button lưu dữ liệu.
            btxSua.Enabled = true; // bật sáng button sửa dữ liệu.
            btxDau.Enabled = true; // bật sáng button lên đầu trang dữ liệu.
            btxSau.Enabled = true; // bật sáng button vể phía sau trang dữ liệu.
            btxTruoc.Enabled = true; // bật sáng button lên phía trước trang đó.
            btxCuoi.Enabled = true; // bật sáng button xuống cuối trang dữ liệu.

            /* BAN TUYỂN SINH */
            // 1. Kết nối dữ liệu, viết câu lệnh lấy về tất cả dữ liệu trong bảng BANTS
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            // 2. Câu lệnh dùng để thực thi lấy về toàn bộ dữ liệu trong bảng BANTS
            a = "select * from BANTS";
            // 3. Mở câu lệnh kết nối.
            obconn.Open();
            // 4. Sử dụng SqlCommand để thực thi các câu lệnh sql, tạo đối tương mới gán vào biến cmbants.
            SqlCommand cmbants = new SqlCommand(a, obconn);
            // 5. Tạo DataReader gán vào biến drbants
            SqlDataReader drbants = cmbants.ExecuteReader();
            // 6. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            while (drbants.Read())
            {
                // 7. Add cột Mabants và Ten_bants từ bảng BANTS trong cơ sở dữ liệu vào combobox tuyển sinh.
                cbbxBTS.Items.Add(drbants["Mabants"].ToString() + " | " + drbants["Ten_bants"].ToString());
            }
            // 8. Đóng kết nối
            obconn.Close();

            /* BẢNG TỈNH */
            // 1. Câu lệnh thực thi lấy về toàn bộ dữ liệu trong bảng TINH.
            a = "select * form TINH";
            // 2. Mở câu lệnh kết nối.
            obconn.Open();
            // 3. Sử dụng SqlCommand để thực thi các câu lệnh sql, tạo đối tượng mới gắn vào biến cm.
            SqlCommand cm = new SqlCommand(a, obconn);
            // 4. Tạo DataReader gán vào biến dr.
            //SqlDataReader dr = cm.ExecuteReader();
            // 5. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            /*
            while (dr.Read())
            {
                // 6. Add cột Matinh và cột Ten_tinh từ bảng TINH vào combobox tuyển sinh.
                cbbTinh1.Items.Add(dr["Matinh"].ToString() + " | " + dr["Ten_tinh"].ToString());
            }
            */
            // 7. Đóng kết nối
            obconn.Close();

            /* Bảng TRƯỜNG PHỔ THÔNG */
            // 1. câu lệnh thực thi lấy về toàn bộ dữ liệu trong bảng TRUONGPT.
            a = "select * from TRUONGPT";
            obconn.Open(); // mở câu lệnh kết nối.
            // 2. Sử dụng SqlCommand để thực thi các câu lệnh Sql, tạo đối tượng mới gắn vào biến cmt.
            SqlCommand cmt = new SqlCommand(a, obconn);
            // 3. Tạo DataReader gắn vào biến drt.
            SqlDataReader drt = cmt.ExecuteReader();
            // 4. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            while (drt.Read())
            {
                // 5. Add cột Truongpt, Ten_truong, Matinh để tránh trùng lặp trường(cột), gán vào combobox lớp 10, 11, 12.
                cbb_Lop10.Items.Add(drt["Matinh"].ToString() + drt["Truongpt"].ToString() + " | " + drt["Ten_truong"].ToString());
                cbb_Lop11.Items.Add(drt["Matinh"].ToString() + drt["Truongpt"].ToString() + " | " + drt["Ten_truong"].ToString());
                cbb_Lop12.Items.Add(drt["Matinh"].ToString() + drt["Truongpt"].ToString() + " | " + drt["Ten_truong"].ToString());
            }
            // 6. Đóng kết nối với bảng TRUONGPT.
            obconn.Close();

            /* BẢNG TRƯỜNG */
            // 1. Câu lệnh dùng để thực thi  lấy về toàn bộ dữ liệu trong bảng TRUONG.
            a = "select * from TRUONG";
            obconn.Open(); // Mở câu lệnh kết nối.
            // 2. Sử dụng SqlCommand để thực thi các câu lệnh sql, tạo đối tượng mới gán vào biến cmtruong.
            SqlCommand cmtruong = new SqlCommand(a, obconn);
            // 3. Tạo DataReader gán vào biến drtruong.
            SqlDataReader drtruong = cmtruong.ExecuteReader();
            // 4. Dùng vòng lặp while đọc từng dòng và xử lý dữ liệu.
            while (drtruong.Read())
            {
                // 5. Add cột Matruong và cột Ten_truong từ bảng TRUONG.
                cbbTruongDK.Items.Add(drtruong["Matruong"].ToString() + " | " + drtruong["Ten_truong"].ToString());
            }
            obconn.Close(); // Đóng kết nối dữ liệu với bảng TRUONG.
        }

        /* Hàm bắt lỗi Try Catch */
        DataSet FillDataset(string cautruyvan)
        {
            // 1
            DataSet dataset = new DataSet();
            // 2
            try
            {
                //3 
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cautruyvan, ketnoi);
                //4
                sqlDataAdapter.Fill(dataset); // Bỏ kết quả vào Dataset.
                //5
                sqlDataAdapter.Dispose();
            }
            // 6. bắt lỗi
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
            return dataset;
        }

        // xử lý Expandable 1
        private void expandablePanel1_Click(object sender, EventArgs e)
        {
            expandablePanel1.Visible = true;
        }
    }
}