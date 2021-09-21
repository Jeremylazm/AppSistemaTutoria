using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using CapaEntidades;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentaciones.Reporte
{
    public partial class ReporteTutoria : Form
    {
        public ReporteTutoria()
        {
            InitializeComponent();
        }

        //crear dos lista, una para el encabezado y otra para 
        //las filas

        public List<E_EncabezadoInforme> Encabezado = new List<E_EncabezadoInforme>();
        public List<E_FilaTabla> Filas = new List<E_FilaTabla>();
        private void ReporteTutoria_Load(object sender, EventArgs e)
        {
            //limpiar el datasource del informe
            reportViewer1.LocalReport.DataSources.Clear();

            // Establezcamos la lista como Datasource del informe

            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DatosEncabezado", Encabezado));
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DatosFila", Filas));
           
            this.reportViewer1.RefreshReport();
        }
    }
}
