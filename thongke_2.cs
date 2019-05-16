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
    public partial class thongke_2 : DevExpress.XtraEditors.XtraForm
    {
        public thongke_2()
        {
            InitializeComponent();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }


        // mặc định khi chạy hệ thống lần đầu tiên, bật các nút radiobutton.
        private void thongke_2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTuyenSinh_2DataSet1.DHV' table. You can move, or remove it, as needed.
            this.dHVTableAdapter.Fill(this.qLTuyenSinh_2DataSet1.DHV);
            rdCNTT.Checked = true;
            rdKhoi.Checked = true;
            rdHe.Checked = true;
            rdSTT.Checked = true;
        }

        // Xử lý nút thống kê
        private void btxThucHien_Click(object sender, EventArgs e)
        {
            // khai báo biến ngành, khối, sắp xếp kiểu chuỗi, gán giá trị ban đầu bằng rỗng.
            string nganh = "", khoi = "", sapxep = "";
            // kiểm tra điều kiện, nếu các nút radio Đại học được chọn thì xét tiếp điều kiện  cho các nút radio trong group ngành.
            if (rdDaiHoc.Checked == true)
            {
                if (rdCNTT.Checked == true)
                {
                    nganh = "and D.Manganh = '102'";
                }
                else if (rdCNKTXD.Checked == true)
                {
                    nganh = "and D.Manganh = '103'";
                }
                else if (rdCNSTH.Checked == true)
                {
                    nganh = "and D.Manganh = '300'";
                }
                else if (rdQTKD.Checked == true)
                {
                    nganh = "and D.Manganh = '401'";
                }
                else if (rdQTBV.Checked == true)
                {
                    nganh = "and D.Manganh = '402'";
                }
                else if (rdKT.Checked == true)
                {
                    nganh = "and D.Manganh = '404'";
                }
                else if (rdTCNH.Checked == true)
                {
                    nganh = "and D.Manganh = '403'";
                }
                else if (rdDL.Checked == true)
                {
                    nganh = "and D.Manganh = '501'";
                }
                else if (rdTA.Checked == true)
                {
                    nganh = "and D.Manganh = '701'";
                }
                else if (rdTN.Checked == true)
                {
                    nganh = "and D.Manganh = '705'";
                }

            }
            // kiểm tra nếu nút radio Cao Đẳng được chọn với aaa là số mã ngành
            else if (rdCaoDang.Checked == true)
            {
                if (rdCNTT.Checked == true)
                {
                    nganh = "and D.Manganh = 'C65'";
                }
                else if (rdCNSTH.Checked == true)
                {
                    nganh = "and D.Manganh = 'C70'";
                }
                else if (rdQTKD.Checked == true)
                {
                    nganh = "and D.Manganh = '69'";
                }
                else if (rdKT.Checked == true)
                {
                    nganh = "and D.Manganh = '74'";
                }
                else if (rdTCNH.Checked == true)
                {
                    nganh = "and D.Manganh = '73'";
                }
                else if (rdDL.Checked == true)
                {
                    nganh = "and D.Manganh = 'C66'";
                }
                else if (rdTA.Checked == true)
                {
                    nganh = "and D.Manganh = '71'";
                }
                else if (rdTN.Checked == true)
                {
                    nganh = "and D.Manganh = '72'";
                }
                else if (rdQTBV.Checked == true)
                {
                    nganh = "and D.Manganh = 'aaa'";
                }
                else if (rdCNKTXD.Checked == true)
                {
                    nganh = "and D.Manganh = 'aaa'";
                }
            }
            // kiểm tra điều kiện, nếu nút radio hệ được chọn, thì xét tiếp điều kiện cho các nút radio trong group ngành.
            else if (rdHe.Checked == true)
            {
                if (rdCNTT.Checked == true)
                {
                    nganh = "and (D.Manganh = '102' or D.Manganh = 'C65')";
                }
                else if (rdCNKTXD.Checked == true)
                {
                    nganh = "and D.Manganh = '103'";
                }
                else if (rdCNSTH.Checked == true)
                {
                    nganh = "and (D.Manganh = '300' or D.Manganh = 'C70')";
                }
                else if (rdQTKD.Checked == true)
                {
                    nganh = "and (D.Manganh = '401' or D.Manganh = 'C69')";
                }
                else if (rdQTBV.Checked == true)
                {
                    nganh = "and D.Manganh = '402'";
                }
                else if (rdKT.Checked == true)
                {
                    nganh = "and (D.Manganh = '404' or D.Manganh = 'C74'";
                }
                else if (rdTCNH.Checked == true)
                {
                    nganh = "and (D.Manganh = '403' or D.Manganh = 'C73'";
                }
                else if (rdDL.Checked == true)
                {
                    nganh = "and (D.Manganh = '501' or D.Manganh  = 'C66'";
                }
                else if (rdTA.Checked == true)
                {
                    nganh = "and (D.Manganh = '701' or D.Manganh = 'C71'";
                }
                else if (rdTN.Checked == true)
                {
                    nganh = "and (D.Manganh ='705' or D.Manganh = 'C72'";
                }
            }
            // Kiểm tra điều kiện , nếu nút Radio khối được chọn thì gán biến khối bằng chuỗi rỗng.
            if(rdKhoi.Checked == true)
            {
                khoi = "";
            }
            // nếu nút radio khối A được chọn thì gán giá biến khoi bằng chuỗi: and makhoi='A'.
            else if(rdKA.Checked == true)
            {
                khoi = "and Makhoi = 'A'";
            }
            // Nếu nút B được chọn, thì gán biến khoi bằng chuỗi: and makhoi = 'B'
            else if(rdKB.Checked == true)
            {
                khoi = "and Makhoi = 'B'";
            }
            else if(rdKC.Checked == true)
            {
                khoi = "and Makhoi = 'C'";
            }
            else if(rdKD1.Checked == true)
            {
                khoi = "and Makhoi = 'D1'";
            }
            else if(rdKD2.Checked == true)
            {
                khoi = "and Makhoi = 'D2'";
            }
            else if(rdKD3.Checked ==  true)
            {
                khoi = "and Makhoi = 'D3'";
            }
            else if(rdKD4.Checked ==  true)
            {
                khoi = "and Makhoi = 'D4'";
            }
            else if(rdKD5.Checked == true)
            {
                khoi = "and Makhoi = 'D5'";
            }
            else if(rdKD6.Checked == true)
            {
                khoi = "and Makhoi = 'D6'";
            }
            // Kiểm tra nút radio số thứ tự được chọn thì gán biến sắp xếp bằng chuỗi truy vấn dữ liệu để sắp xếp số thứ tự tăng dần.
            if(rdSTT.Checked == true)
            {
                sapxep = "order by STT asc";
            }
            // tương tự với số báo danh
            else if(rdSBD.Checked == true)
            {
                sapxep = "order by SBD asc";
            }
            else if(rdTen.Checked == true)
            {
                sapxep = "order by Ten asc";
            }
            else if(rdsxNganh.Checked == true)
            {
                sapxep = "order by D.Manganh asc";
            }
            else if(rdDiem.Checked == true)
            {
                sapxep = "order by DiemLT asc";
            }
            // kết nối data
            string ketnoi = "Data Source = DESKTOP-5PSSEM5\\SQLEXPRESS; Initial Catalog = QLTuyenSinh_2; Integrated Security = true";
            // tạo câu lệnh kết nối
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            // thực hiên truy vấn cơ sở dữ liệu.
            string a = "select STT, Matruong, D.Makhoi, SBD, D.Manganh, N.Ten_nganh, Ho, Ten, Gioi_tinh, Ngay_sinh, Matinh, Mahuyen, Dm1, Dm2, Dm3. DiemTC, DiemLT, NguyenVong" + "from DHV D, NGANH N where D.Manganh = N.Manganh and D.Makhoi = N.khoi" + nganh + khoi + sapxep + "";
            // sử dụng SqlDataAdapter để kết nối và lấy dữ liệu.
            SqlDataAdapter da = new SqlDataAdapter(a, obconn);
            DataSet data = new DataSet();
            da.Fill(data);
            this.dataGridView1.DataSource = data.Tables[0];
            dataGridView1.Columns[0].Width = 45;
            dataGridView1.Columns[1].Width = 55;
            dataGridView1.Columns[2].Width = 55;
            dataGridView1.Columns[3].Width = 55;
            dataGridView1.Columns[4].Width = 55;
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[6].Width = 130;
            dataGridView1.Columns[7].Width = 55;
            dataGridView1.Columns[8].Width = 60;
            dataGridView1.Columns[9].Width = 70;
            dataGridView1.Columns[10].Width = 55;
            dataGridView1.Columns[11].Width = 55;
            dataGridView1.Columns[12].Width = 45;
            dataGridView1.Columns[13].Width = 45;
            dataGridView1.Columns[14].Width = 45;
            dataGridView1.Columns[15].Width = 55;
            dataGridView1.Columns[16].Width = 55;
            dataGridView1.Columns[17].Width = 70;
            label1.Text = "Tổng thí sinh: " + (dataGridView1.Rows.Count - 1).ToString();
            // Dữ liệu lấy về trong Dataset được ghi xuống 1 file xml
            data.WriteXml("Reportthongke2.xml", XmlWriteMode.WriteSchema);

        }

        private void btxIn_Click(object sender, EventArgs e)
        {
            fmreportthongke_2 fmrp = new fmreportthongke_2();
            fmrp.ShowDialog();
        }
    }
}