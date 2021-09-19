using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        readonly N_Docente ObjNegocioDocente = new N_Docente();
        readonly E_Estudiante ObjEntidadEstudiante = new E_Estudiante();
        readonly N_Estudiante ObjNegocioEstudiante = new N_Estudiante();
        int Regs = 0;
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
                dgvTablaTutores.DataSource = N_Docente.MostrarTutores(E_InicioSesion.Usuario);
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
                labelTutorados.Visible = false;
                labelEstudiantes.Visible = true;
                btnEstudiantes.Visible = false;
                textBoxBuscar.Text = "";
                dgvTablaEstudiantes.DataSource = N_Estudiante.MostrarEstudiantesSinTutor(E_InicioSesion.Usuario);
                textBoxTotalRegistros.Text = dgvTablaEstudiantes.Rows.Count.ToString();
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
                labelEstudiantes.Visible = false;
                labelTutorados.Visible = true;
                btnEstudiantes.Visible = true;
                dgvTablaEstudiantes.DataSource = N_Docente.MostrarTutorados(textBoxSeleccionarTutor.Text);
                textBoxTotalRegistros.Text = dgvTablaEstudiantes.Rows.Count.ToString();
                textBoxBuscar.Text = "";
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
                dgvTablaTutores.DataSource = N_Docente.BuscarTutores(E_InicioSesion.Usuario, textBoxSeleccionarTutor.Text);
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
                labelTutorados.Visible = false;
                labelEstudiantes.Visible = true;
                btnEstudiantes.Visible = false;
                dgvTablaEstudiantes.DataSource = N_Estudiante.BuscarEstudiantesSinTutor(E_InicioSesion.Usuario, textBoxBuscar.Text, Regs);
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
                labelEstudiantes.Visible = false;
                labelTutorados.Visible = true;
                btnEstudiantes.Visible = true;
                dgvTablaEstudiantes.DataSource = N_Docente.BuscarTutorados(textBoxSeleccionarTutor.Text, textBoxBuscar.Text, Regs);
                AccionesTablaTutorados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ImportarDatos()
        {
            string file = "";
            DataTable dtaux = new DataTable(); // DataTable auxiliar
            DataTable dt = new DataTable(); 
            DataRow row;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)   // Check if Result == "OK".
            {
                file = openFileDialog1.FileName; 
                try
                {
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(file);
                    Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];
                    Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                    int rowCount = excelRange.Rows.Count; 
                    int colCount = excelRange.Columns.Count; 
                    for (int i = 1; i <= rowCount; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            dt.Columns.Add(excelRange.Cells[i, j].Value2.ToString());
                        }
                        break;
                    }
            
                    int rowCounter;  
                    for (int i = 2; i <= rowCount; i++) 
                    {
                        row = dt.NewRow(); 
                        rowCounter = 0;
                        for (int j = 1; j <= colCount; j++) 
                        {
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

                    int totalRegs = 0;
                    foreach (DataRow RowAux in dt.Rows)
                    {
                        string CodEstudiante_ = RowAux[0].ToString();
                        dtaux = N_Estudiante.BuscarRegistro(CodEstudiante_);
                        if (dtaux.Rows.Count == 0)
                        {
                            totalRegs += 1;
                        }
                    }

                    DialogResult Opcion;
                    string mensaje = "Se han encontrado " + totalRegs.ToString() + " registros nuevos\n ¿Desea agregar esta información a la base de datos?";
                    Opcion = MessageBox.Show(mensaje, "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (Opcion == DialogResult.OK)
                    {
                        foreach (DataRow Row in dt.Rows)
                        {
                            string CodEstudiante_ = Row[0].ToString();
                            dtaux = N_Estudiante.BuscarRegistro(CodEstudiante_);
                            if (dtaux.Rows.Count == 0)
                            {                               
                                string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
                                Image Img = Image.FromFile(fullImagePath);
                                byte[] Perfil = new byte[0];
                                using (MemoryStream MemoriaPerfil = new MemoryStream())
                                {
                                    Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                                    Perfil = MemoriaPerfil.ToArray();
                                }
                                
                                ObjEntidadEstudiante.Perfil = Perfil;
                                ObjEntidadEstudiante.CodEstudiante = Row[0].ToString();
                                ObjEntidadEstudiante.APaterno = Row[1].ToString();
                                ObjEntidadEstudiante.AMaterno = Row[2].ToString();
                                ObjEntidadEstudiante.Nombre = Row[3].ToString();
                                ObjEntidadEstudiante.Email = Row[4].ToString();
                                ObjEntidadEstudiante.Direccion = Row[5].ToString();
                                ObjEntidadEstudiante.Telefono = Row[6].ToString();
                                ObjEntidadEstudiante.CodEscuelaP = Row[7].ToString();
                                ObjEntidadEstudiante.PersonaReferencia = Row[8].ToString();
                                ObjEntidadEstudiante.TelefonoReferencia = Row[9].ToString();
                                ObjEntidadEstudiante.InformacionPersonal = "";
                                ObjNegocioEstudiante.InsertarRegistros(ObjEntidadEstudiante);
                            }
                        }
                        MensajeConfirmacion("La operación se realizo con éxito.");
                    }

                    MostrarRegistrosEstudiantesSinTutor();

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
            if (labelEstudiantes.Visible == true)
            {
                MostrarRegistrosEstudiantesSinTutor();
            }
            if (labelTutorados.Visible == true)
            {
                MostrarRegistrosTutorados();
            }
        }

        private void textBoxSeleccionarTutor_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBuscar.Text == "" && textBoxTotalRegistros.Text == "")
            {
                MostrarRegistrosEstudiantesSinTutor();
            }
            else
            {
                BuscarRegistrosEstudiantesSinTutor();
            }
            BuscarRegistroTutor();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (labelEstudiantes.Visible == true)
            {
                BuscarRegistrosEstudiantesSinTutor();
            }
            if (labelTutorados.Visible == true)
            {
                BuscarRegistrosTutorados();
            }
        }

        private void textBoxTotalRegistros_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTotalRegistros.Text == "") Regs = 0;
            else
            {
                Regs = Int32.Parse(textBoxTotalRegistros.Text);
            }
            if (labelEstudiantes.Visible == true)
            {
                BuscarRegistrosEstudiantesSinTutor();
            }
            if (labelTutorados.Visible == true)
            {
                BuscarRegistrosTutorados();
            }
        }

        private void btnVerTutorados_Click_1(object sender, EventArgs e)
        {
            if (textBoxSeleccionarTutor.Text == "")
            {
                MensajeError("No se ha seleccionado un tutor");
            }
            else
            {
                MostrarRegistrosTutorados();
            }
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            MostrarRegistrosEstudiantesSinTutor();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            ImportarDatos();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelEstudiantes.Visible == true && dgvTablaEstudiantes.Rows.Count > 0)
                {
                    DialogResult Opcion;
                    string mensaje;
                    if (textBoxSeleccionarTutor.Text == "")
                    {
                        MensajeError("No se ha seleccionado un tutor");
                    }
                    else
                    {
                        int tutorados = dgvTablaEstudiantes.Rows.Count;
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
                if (labelTutorados.Visible == true && dgvTablaEstudiantes.Rows.Count > 0)
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
            textBoxBuscar.Text = row.Cells[0].Value.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
