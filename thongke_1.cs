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
    public partial class thongke_1 : DevExpress.XtraEditors.XtraForm
    {
        public thongke_1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        // Xử lý code khi Form thống kê thí sinh theo khối được load lần đầu tiên.
        private void thongke_1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLTuyenSinh_2DataSet1.NGANH' table. You can move, or remove it, as needed.
            this.nGANHTableAdapter.Fill(this.qLTuyenSinh_2DataSet1.NGANH);
            // TODO: This line of code loads data into the 'qLTuyenSinh_2DataSet1.DHV' table. You can move, or remove it, as needed.
            this.dHVTableAdapter.Fill(this.qLTuyenSinh_2DataSet1.DHV);
            rdNV.Checked = true;
            rdHe.Checked = true;
        }

        //người dùng thực hiện thống kê
        private void btxThucHien_Click(object sender, EventArgs e)
        {
            string he = "";
            string nv = "";
            // nếu nút radio nguyện vọng được chọn thì gán giá trị cho biến nv bằng rỗng.
            if (rdNV.Checked == true)
            {
                nv = "";
            }
            // nút radio nguyện vọng 1 được chọn thì gán giá trị cho biến nv
            // bằng chuỗi where Nguyenvong = '1'
            else if (rdNV.Checked == true)
            {
                nv = "where Nguyenvong = '1'";
            }
            // nút radio nguyện vọng 2 được chọn thì gán giá trị cho biến nv 
            // bằng chuỗi where Nguyenvong = '2'
            else if (rdNV2.Checked == true)
            {
                nv = "where Nguyenvong = '2'";
            }
            // nếu nút radio nguyện vọng 3 được chọn thì gán giá trị cho biến nv
            // bằng chuỗi where Nguyenvong = '3'
            else if (rdNV3.Checked == true)
            {
                nv = "where Nguyenvong = '3'";
            }
            // nếu một trong 3 nút radio nguyện vọng được chọn thì xét tiếp trường hợp 2
            if (rdNV1.Checked == true || rdNV2.Checked == true || rdNV3.Checked == true)
            {
                // nếu nút radio cả hai được chọn thì gán giá trị biến he bằng rỗng
                if (rdHe.Checked == true)
                {
                    he = "";
                }
                // nếu nút radio đại học được chọn, thì gán giá trị biến he bằng những biến mã ngành có một kí tự tính từ bên trái bằng kí tự C.
                else if (rdDaihoc.Checked == true)
                {
                    he = "and left(Manganh, 1)<>'C'";
                }
                // Nếu nút radio cao đẳng được chọn, thì gán biến he bằng biến mã ngành có một kí tự tính từ trái bằng kí tự C.
                else if (rdCaoDang.Checked == true) 
                {
                    he = "and left(Manganh, 1)='C'";
                }
            }
            // người dùng chọn duy nhất môt radio nguyện vọng
            else if (rdNV.Checked == true)
            {
                if (rdHe.Checked == true)
                {
                    he = "";
                }
                else if (rdDaihoc.Checked == true)
                {
                    he = "where left(Manganh, 1)<>'C'";
                }
                else if (rdCaoDang.Checked == true)
                {
                    he = "where left(Manganh, 1)='C'";
                }
            }
            // Truy vấn lồng
            // dùng distinct để loại trừ những dữ liệu bị trùng.
            string a = "select distinct (a.Manganh), n.Ten_nganh, A00, B00, C00, D01, D02, D03, D04, D05, D06,(A00+B00+C00+D01+D02+D03+D04+D05+D06) as tong from NGANH";
            a += "select a.Manganh, sum (a.AA00) as A00, sum (a.BB00) as B00, sum (a.CC00) as C00, sum (a.DD01) as D01, sum (a.DD02) as D02,";
            a += "sum (a.DD03) as D03, sum (a.DD04) as D04, sum (a.DD05) as D05, sum (a.DD06) as D06 from NGANH";

            a += "(select Manganh, case when khoi2 = 'A00' then 1 else 0 end as AA00,";
            a += "case when khoi2 = 'A00' then 1 else 0 end as AA00,";
            a += "case when khoi2 = 'D01' then 1 else 0 end as DD01, case when khoi2 = 'B00' then 1 else 0 end as BB00,";
            a += "case when khoi2 = 'C00' then 1 else 0 end as CC00, Case when khoi2 = 'D02' then 1 else 0 end as DD02,";
            a += "case when khoi2 = 'D03' then 1 else 0 end as DD03, case when khoi2 = 'D04' then 1 else 0 end as DD04,";
            a += "case when khoi2 = 'D05' then 1 else 0 end as DD05, case when khoi2 = 'D06' then 1 else 0 end as DD06";

            a += "from DHV" + nv + he + "as a group by a.Manganh) a inner join NGANH n on n.Manganh = a.Manganh order by Manganh asc";
            // thực hiện viết chuỗi kết nối.
            // Initial Security, đây là chỉ định cách kết nối tới cơ sở dữ liệu. 
            // Trên máy của chúng ta thường để Windows Authentication cho nên tham số Integrated Security mang giá trị True như trên khi kết nối.
            string ketnoi = "Data Source = DESKTOP-5PSSEM5\\SQLEXPRESS; Initial Catalog = QLTuyenSinh_2; Integrated Security = true";
            // Tạo câu lệnh kết nối
            SqlConnection obconn = new SqlConnection();
            obconn.ConnectionString = ketnoi;
            // Sử dụng SqlDataAdapter để kết nối lấy và ghi dữ liệu.
            SqlDataAdapter da = new SqlDataAdapter(a, obconn);
            DataSet ds = new DataSet(); // khởi tạo biến ds để chứa dữ liệu.
            da.Fill(ds);
            // Lấy bảng đầu tiên có trong dataset gán vào cho data GridviewX1
            this.dataGridViewX1.DataSource = ds.Tables[0];
            // tạo độ rộng cho cột thứ 2 trong dataGridview.
            dataGridViewX1.Columns[1].Width = 200;
            // tạo độ rộng cho các cột còn lại.
            for(int i = 2; i < dataGridViewX1.Columns.Count; i++)
            {
                dataGridViewX1.Columns[i].Width = 40;
            }
            // dữ liệu lấy về trong dataset được ghi xuống 1 file xml.
            ds.WriteXml("reportthongke.xml", XmlWriteMode.WriteSchema);

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // xử lý nút in
        private void btxIn_Click(object sender, EventArgs e)
        {
            frmreportthongke_1 fmrp = new frmreportthongke_1();
            fmrp.ShowDialog();
        }
    }
}