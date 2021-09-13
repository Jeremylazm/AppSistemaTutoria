using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System.Runtime.InteropServices;
using ImageMagick;

namespace CapaPresentaciones
{
    public partial class P_TablaTutores : Form
    {
        readonly E_Docente ObjEntidadDocente = new E_Docente();
        readonly N_Docente ObjNegocioDocente = new N_Docente();
        readonly E_Estudiante ObjEntidadEstudiante = new E_Estudiante();
        readonly N_Estudiante ObjNegocioEstudiante = new N_Estudiante();
        string CodEscuelaP = "IN";

        public P_TablaTutores()
        {
            InitializeComponent();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void AccionesTablaTutores()
        {
            // Tabla Tutores

            dgvTablaTutores.Columns[0].HeaderText = "Cod. Tutor";
            dgvTablaTutores.Columns[1].HeaderText = "Ap. Paterno";
            dgvTablaTutores.Columns[2].HeaderText = "Ap. Materno";
            dgvTablaTutores.Columns[3].HeaderText = "Nombres";
            dgvTablaTutores.Columns[4].HeaderText = "TotalTutorados";
        }

        public void AccionesTablaEstudiantesSinTutor()
        {
            // Tabla Estudiantes sin tutor
            dgvTablaEstudiantes.Columns[0].HeaderText = "Cod. Estudiante";
            dgvTablaEstudiantes.Columns[1].HeaderText = "Ap. Paterno";
            dgvTablaEstudiantes.Columns[2].HeaderText = "Ap. Materno";
            dgvTablaEstudiantes.Columns[3].HeaderText = "Nombres";
        }

        public void AccionesTablaTutorados()
        {
            // Tabla Tutorados
            dgvTablaEstudiantes.Columns[0].Visible = false;
            dgvTablaEstudiantes.Columns[1].Visible = false;
            dgvTablaEstudiantes.Columns[6].Visible = false;
            dgvTablaEstudiantes.Columns[7].Visible = false;
            dgvTablaEstudiantes.Columns[8].Visible = false;
            dgvTablaEstudiantes.Columns[9].Visible = false;
            dgvTablaEstudiantes.Columns[10].Visible = false;
            dgvTablaEstudiantes.Columns[11].Visible = false;
            dgvTablaEstudiantes.Columns[12].Visible = false;
            dgvTablaEstudiantes.Columns[13].Visible = false;
            dgvTablaEstudiantes.Columns[14].Visible = false;
            dgvTablaEstudiantes.Columns[15].Visible = false;
            dgvTablaEstudiantes.Columns[16].Visible = false;

            dgvTablaEstudiantes.Columns[2].HeaderText = "Cod. Estudiante";
            dgvTablaEstudiantes.Columns[3].HeaderText = "Ap. Paterno";
            dgvTablaEstudiantes.Columns[4].HeaderText = "Ap. Materno";
            dgvTablaEstudiantes.Columns[5].HeaderText = "Nombres";
        }

        public void MostrarRegistrosTutores()
        {
            try
            {
                dgvTablaTutores.DataSource = N_Docente.MostrarTutores(CodEscuelaP);
                AccionesTablaTutores();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void MostrarRegistrosEstudiantesSinTutor()
        {
            try
            {
                labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
                dgvTablaEstudiantes.DataSource = N_Estudiante.MostrarEstudiantesSinTutor(CodEscuelaP, Int32.Parse(textBoxTotalRegistros.Text));
                AccionesTablaEstudiantesSinTutor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void MostrarRegistrosTutorados()
        {
            try
            {
                labelEstudiantes.Text = "TUTORADOS";
                dgvTablaEstudiantes.DataSource = N_Docente.MostrarTutorados(textBoxSeleccionarTutor.Text);
                textBoxTotalRegistros.Text = dgvTablaEstudiantes.Rows.Count.ToString();
                AccionesTablaTutorados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BuscarRegistroTutor()
        {
            try
            {
                dgvTablaTutores.DataSource = N_Docente.BuscarTutor(CodEscuelaP, textBoxSeleccionarTutor.Text);
                AccionesTablaTutores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BuscarRegistrosEstudiantesSinTutor()
        {
            try
            {
                labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
                dgvTablaEstudiantes.DataSource = N_Estudiante.BuscarEstudiantesSinTutor(CodEscuelaP, textBoxBuscar.Text, Int32.Parse(textBoxTotalRegistros.Text));
                AccionesTablaEstudiantesSinTutor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BuscarRegistrosTutorados()
        {
            try
            {
                labelEstudiantes.Text = "TUTORADOS";
                dgvTablaEstudiantes.DataSource = N_Docente.BuscarTutorados(textBoxSeleccionarTutor.Text, textBoxBuscar.Text, Int32.Parse(textBoxTotalRegistros.Text));
                textBoxTotalRegistros.Text = dgvTablaEstudiantes.Rows.Count.ToString();
                AccionesTablaTutorados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportarDatos(DataGridView Datos)
        {
            string file = "";   //variable for the Excel File Location
            DataTable dt = new DataTable();   //container for our excel data
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog();  // Show the dialog.
            if (result == DialogResult.OK)   // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; //get the filename with the location of the file
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    int rowCount = excelRange.Rows.Count;  //get row count of excel data

                    int colCount = excelRange.Columns.Count; // get column count of excel data

                    //Get the first Column of excel file which is the Column Name                  

                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                        }
                        break;
                    }
                    //Get Row Data of Excel              
                    int rowCounter;  //This variable is used for row index number
                    for (int i = 2; i <= rowCount; i++) //Loop for available row of excel data
                    {
                        row = dt.NewRow();  //assign new row to DataTable
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) //Loop for available column of excel data
                        {
                            //check if cell is empty
                            if (excelRange.Cells[i, j] != null && excelRange.Cells[i, j].Value2 != null)
                            {
                                row[rowCounter] = excelRange.Cells[i, j].Value2.ToString();
                            }
                            else
                            {
                                row[i] = "";
                            }

                            rowCounter++;
                        }
                        dt.Rows.Add(row); //add row to DataTable
                    }

                    labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
                    textBoxTotalRegistros.Text = "10";
                    textBoxBuscar.Text = "";
                    dgvTablaEstudiantes.DataSource = dt; //assign DataTable as Datasource for DataGridview
                    AccionesTablaEstudiantesSinTutor();

                    //Close and Clean excel process
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Marshal.ReleaseComObject(excelRange);
                    Marshal.ReleaseComObject(excelWorksheet);
                    excelWorkbook.Close();
                    Marshal.ReleaseComObject(excelWorkbook);

                    //quit 
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void P_TablaDocentes_Load(object sender, EventArgs e)
        {
            MostrarRegistrosTutores();
            if (labelEstudiantes.Text == "ESTUDIANTES SIN TUTOR")
            {
                MostrarRegistrosEstudiantesSinTutor();
            }
            if (labelEstudiantes.Text == "TUTORADOS")
            {
                MostrarRegistrosTutorados();
            }
        }

        private void textBoxSeleccionarTutor_TextChanged(object sender, EventArgs e)
        {
            if (labelEstudiantes.Text == "TUTORADOS")
            {
                labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
                textBoxTotalRegistros.Text = "10";
                MostrarRegistrosEstudiantesSinTutor();
            }
            BuscarRegistroTutor();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (labelEstudiantes.Text == "ESTUDIANTES SIN TUTOR")
            {
                BuscarRegistrosEstudiantesSinTutor();
            }
            if (labelEstudiantes.Text == "TUTORADOS")
            {
                BuscarRegistrosTutorados();
            }
        }

        private void textBoxTotalRegistros_TextChanged(object sender, EventArgs e)
        {
            if (labelEstudiantes.Text == "ESTUDIANTES SIN TUTOR")
            {
                BuscarRegistrosEstudiantesSinTutor();
            }
            if (labelEstudiantes.Text == "TUTORADOS")
            {
                BuscarRegistrosTutorados();
            }
        }

        private void btnVerTutorados_Click(object sender, EventArgs e)
        {
            labelEstudiantes.Text = "TUTORADOS";
            textBoxBuscar.Text = "";
            BuscarRegistrosTutorados();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            labelEstudiantes.Text = "ESTUDIANTES SIN TUTOR";
            textBoxTotalRegistros.Text = "10";
            textBoxBuscar.Text = "";
            MostrarRegistrosEstudiantesSinTutor();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ImportarDatos(dgvTablaTutores);
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstudiantes.Text == "ESTUDIANTES SIN TUTOR" && dgvTablaEstudiantes.Rows.Count > 0)
                {
                    DialogResult Opcion;
                    string mensaje;
                    int tutorados= dgvTablaEstudiantes.Rows.Count;
                    if (tutorados == 1)
                    {
                        mensaje = "Se va asignar 1 nuevo tutorado.";
                    }
                    else
                    {
                        mensaje = "Se van asignar " + tutorados.ToString() + " nuevos tutorados.";
                    }
                    Opcion = MessageBox.Show(mensaje, "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (Opcion == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvTablaEstudiantes.Rows.Count; i++)
                        {
                            string CodEstudiante = dgvTablaEstudiantes.Rows[i].Cells[0].Value.ToString();
                            ObjNegocioEstudiante.AsignarTutor(CodEstudiante, textBoxSeleccionarTutor.Text);
                        }
                        MensajeConfirmacion("La operación se realizo con éxito.");
                    }
                }
                BuscarRegistroTutor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstudiantes.Text == "TUTORADOS" && dgvTablaEstudiantes.Rows.Count > 0)
                {
                    DialogResult Opcion;
                    string mensaje;
                    int tutorados = dgvTablaEstudiantes.Rows.Count;
                    if (tutorados == 1)
                    {
                        mensaje = "Se va eliminar 1 tutorado asignado.";
                    }
                    else
                    {
                        mensaje = "Se van eliminar " + tutorados.ToString() + " tutorados asignados.";
                    }
                    Opcion = MessageBox.Show(mensaje, "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (Opcion == DialogResult.OK)
                    {
                        for (int i = 0; i < dgvTablaEstudiantes.Rows.Count; i++)
                        {
                            string CodEstudiante = dgvTablaEstudiantes.Rows[i].Cells[2].Value.ToString();
                            ObjNegocioEstudiante.EliminarTutor(CodEstudiante);
                        }
                        MensajeConfirmacion("La operación se realizo con éxito.");
                    }
                }
                BuscarRegistroTutor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTablaTutores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTablaTutores.CurrentRow;
            textBoxSeleccionarTutor.Text = row.Cells[0].Value.ToString();
        }

        private void dgvTablaEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTablaEstudiantes.CurrentRow;
            textBoxBuscar.Text = row.Cells[2].Value.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
