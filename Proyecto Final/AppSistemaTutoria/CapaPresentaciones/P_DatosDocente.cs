using System;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_DatosDocente : Form
    {
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        public P_DatosDocente()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LimpiarCajas()
        {
            txtCodigo.Clear();
            txtAPaterno.Clear();
            txtAMaterno.Clear();
            txtNombre.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCodigo.Focus();
        }

        private void LlenarComboBox()
        {
            cxtCategoria.SelectedIndex = 0;
            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;
            cxtEstado.SelectedIndex = 0;

            cxtEscuela.DataSource = N_EscuelaProfesional.MostrarRegistros();
            cxtEscuela.ValueMember = "CodEscuelaP";
            cxtEscuela.DisplayMember = "Nombre";
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            LlenarComboBox();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((txtCodigo.Text.Trim() != "") &&
                (txtAPaterno.Text.Trim() != "") &&
                (txtAMaterno.Text.Trim() != "") &&
                (txtNombre.Text.Trim() != "") &&
                (txtEmail.Text.Trim() != "") &&
                (txtDireccion.Text.Trim() != "") &&
                (txtTelefono.Text.Trim() != ""))
            {
                if (Program.Evento == 0)
                {
                    try
                    {
                        ObjEntidad.CodDocente = txtCodigo.Text;
                        ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                        ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                        ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                        ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
                        ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                        ObjEntidad.Telefono = txtTelefono.Text;
                        ObjEntidad.Categoria = cxtCategoria.SelectedItem.ToString();
                        ObjEntidad.Subcategoria = cxtSubcategoria.SelectedItem.ToString();
                        ObjEntidad.Regimen = cxtRegimen.SelectedItem.ToString();
                        ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
                        ObjEntidad.Estado = cxtEstado.SelectedItem.ToString();

                        ObjNegocio.InsertarRegistros(ObjEntidad);
                        MensajeConfirmacion("Registro insertado exitosamente");
                        Program.Evento = 0;
                        LimpiarCajas();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al insertar el registro " + ex);
                    }
                }
                else
                {
                    try
                    {
                        DialogResult Opcion;
                        Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (Opcion == DialogResult.OK)
                        {
                            ObjEntidad.CodDocente = txtCodigo.Text;
                            ObjEntidad.APaterno = txtAPaterno.Text.ToUpper();
                            ObjEntidad.AMaterno = txtAMaterno.Text.ToUpper();
                            ObjEntidad.Nombre = txtNombre.Text.ToUpper();
                            ObjEntidad.Email = txtEmail.Text + lblDominioEmail.Text;
                            ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                            ObjEntidad.Telefono = txtTelefono.Text;
                            ObjEntidad.Categoria = cxtCategoria.SelectedValue.ToString();
                            ObjEntidad.Subcategoria = cxtSubcategoria.SelectedValue.ToString();
                            ObjEntidad.Regimen = cxtRegimen.SelectedValue.ToString();
                            ObjEntidad.CodEscuelaP = cxtEscuela.SelectedValue.ToString();
                            ObjEntidad.Estado = cxtEstado.SelectedValue.ToString();

                            ObjNegocio.EditarRegistros(ObjEntidad);
                            MensajeConfirmacion("Registro editado exitosamente");
                            Program.Evento = 0;
                            LimpiarCajas();
                            Close();
                        }
                    }
                    catch (Exception)
                    {
                        MensajeError("Error al editar el registro");
                    }
                }
            }
            else
            {
                MensajeError("Debe llenar los campos");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEscuelas_Click(object sender, EventArgs e)
        {
            //P_Ciudades NuevoRegistro = new P_Ciudades();
            //NuevoRegistro.FormClosed += new FormClosedEventHandler(ActualizarDatos);
            //NuevoRegistro.ShowDialog();
            //NuevoRegistro.Dispose();
        }

        private void cxtCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cxtSubcategoria.Items.Clear();
            cxtRegimen.Items.Clear();
            cxtRegimen.Items.Add("TIEMPO COMPLETO");
            cxtRegimen.Items.Add("TIEMPO PARCIAL");

            if (cxtCategoria.SelectedItem.ToString() == "NOMBRADO")
            {
                
                cxtSubcategoria.Items.Add("PRINCIPAL");
                cxtSubcategoria.Items.Add("ASOCIADO");
                cxtSubcategoria.Items.Add("AUXILIAR");

                cxtRegimen.Enabled = true;
                cxtRegimen.Items.Insert(1, "DEDICACIÓN EXCLUSIVA");
            }
            else
            {
                cxtSubcategoria.Items.Add("A1");
                cxtSubcategoria.Items.Add("A2");
                cxtSubcategoria.Items.Add("A3");
                cxtSubcategoria.Items.Add("B1");
                cxtSubcategoria.Items.Add("B2");
                cxtSubcategoria.Items.Add("B3");
                
                cxtRegimen.Enabled = false;
            }

            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;
        }

        private void cxtSubcategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cxtCategoria.SelectedItem.ToString() == "CONTRATADO")
            {
                if (cxtSubcategoria.SelectedItem.ToString().EndsWith("1"))
                {
                    cxtRegimen.SelectedItem = "TIEMPO COMPLETO";
                }
                else
                {
                    cxtRegimen.SelectedItem = "TIEMPO PARCIAL";
                }
            }
        }
    }
}
