using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace DoAnTotNghiep_QuanLyTuyenSinh_v0._4
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        // thực hiện viết chuỗi kết nối.
        // Initial Security, đây là chỉ định cách kết nối tới cơ sở dữ liệu. 
        // Trên máy của chúng ta thường để Windows Authentication cho nên tham số Integrated Security mang giá trị True như trên khi kết nối.
        string ketnoi = "Data Source = DESKTOP-5PSSEM5\\SQLEXPRESS; Initial Catalog = QLTuyenSinh_2; Integrated Security = true";
        // Đối tượng kết nối.
        SqlConnection conn = null;
        //Lấy từng dòng dữ liệu trong bảng. 
        //Dùng SqlDataAdapter
        DataSet FillDataset(string cautruyvan)
        {
            DataSet dataset = new DataSet();
            //Sử dụng Try-Catch để bắt lỗi
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cautruyvan, ketnoi);
                sqlDataAdapter.Fill(dataset);
                sqlDataAdapter.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return dataset;
        }

        // Xử lý Groupbox trong suốt
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            this.groupBox1.BackColor = Color.Transparent;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTuyenSinh_2DataSet.USERS' table. You can move, or remove it, as needed.
            this.uSERSTableAdapter.Fill(this.qLTuyenSinh_2DataSet.USERS);

        }

        // xử lý buttons đăng nhập
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            /*thực thi câu lệnh truy vấn lấy về tất cả dữ liệu trong bảng users bỏ vào dataset*/
            DataSet dataset = FillDataset("Select * From USERS");
            //Lấy về dữ liệu bẳng users trong dataset bỏ vào DataGridview1.
            this.dataGridView1.DataSource = dataset.Tables[0];
            /* Dùng vòng lặp for duyệt tất cả các dòng dữ liệu có chứa trong dataGridview1 */
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (txtNguoidung.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() && dataGridView1.Rows[i].Cells[2].Value.ToString() == txtPassword.Text && dataGridView1.Rows[i].Cells[3].Value.ToString() == "0")
                {

                    //Khởi tạo biến để gọi Form chương trình
                    frmChuongtrinh ct = new frmChuongtrinh();
                    this.Hide();
                    ct.ShowDialog();
                    //Trả về giá trị rỗng cho textbox User và Pass.
                    txtNguoidung.Text = " ";
                    txtPassword.Text = " ";
                }
                //Ngược lại
                else if (txtNguoidung.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() && dataGridView1.Rows[i].Cells[2].Value.ToString() == txtPassword.Text && dataGridView1.Rows[i].Cells[3].Value.ToString() == "1")
                {
                    // Khởi tạo biến để gọi Form chương trình
                    frmQuantri ct = new frmQuantri();
                    this.Hide();
                    //Hiển thị Form chương trình lên màn hình.
                    ct.ShowDialog();
                    this.Show();
                    //Trả về giá trị rỗng cho textbox người dùng & mật khẩu.
                    txtNguoidung.Text = " ";
                    txtPassword.Text = " ";
                }
            }
        }
        // xử lý nút thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
