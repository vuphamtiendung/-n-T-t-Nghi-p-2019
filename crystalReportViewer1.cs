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
    public partial class crystalReportViewer1 : DevExpress.XtraEditors.XtraForm
    {
        private static reportthongke_1 ReportSource;

        public crystalReportViewer1()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            reportthongke_1 rpt = new reportthongke_1();
            crystalReportViewer2.ReportSource = rpt;

        }
    }
}