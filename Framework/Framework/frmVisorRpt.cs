using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using CrystalDecisions.Windows.Forms;

namespace Framework
{
    public partial class frmVisorRpt : Form
    {

        public frmVisorRpt()
        {
            InitializeComponent();
        }

        public frmVisorRpt(DataTable dt, string reporte, string nombreReporte, string agencia, List<string> parametros, List<string> valores)
        {
            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ReportDocument rp = new ReportDocument();
            this.Text = nombreReporte;
            rp.Load(path + "\\Reportes\\" + reporte);
            rp.SetDataSource(dt);
            rp.SetParameterValue("Colegio", agencia);
            rp.SetParameterValue("LogoColegio", path + "\\Reportes\\LogoKolegio.bmp");
            if (parametros.Count > 0)
            {
                for (int i = 0; i < parametros.Count; i++)
                {
                    rp.SetParameterValue(parametros[i], valores[i]);
                }
            }
            crv.ReportSource = rp;
        }

        public frmVisorRpt(DataTable dt, string reporte)
        {
            InitializeComponent();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            ReportDocument rp = new ReportDocument();
            //this.Text = nombreReporte;
            rp.Load(path + "\\Reportes\\" + reporte);
            rp.SetDataSource(dt);
            //rp.SetParameterValue("Colegio", agencia);
            //rp.SetParameterValue("LogoColegio", path + "\\Reportes\\LogoKolegio.bmp");
            //if (parametros.Count > 0)
            //{
            //    for (int i = 0; i < parametros.Count; i++)
            //    {
            //        rp.SetParameterValue(parametros[i], valores[i]);
            //    }
            //}
            crv.ReportSource = rp;
        }
    }
}
