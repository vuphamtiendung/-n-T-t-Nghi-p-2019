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

namespace DoAnTotNghiep_QuanLyTuyenSinh_v0._4
{
    public partial class fmreportthongke_2 : DevExpress.XtraEditors.XtraForm
    {
        public fmreportthongke_2()
        {
            InitializeComponent();
        }

        private void fmreportthongke_2_Load(object sender, EventArgs e)
        {
            reportthongke2 rpt = new reportthongke2();
            crystalReportViewer1.ReportSource = rpt;


        }
    }
}