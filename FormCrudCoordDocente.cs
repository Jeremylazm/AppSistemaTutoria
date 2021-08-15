using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsFix
{
    public partial class FormCrudCoordDocente : Form
    {
        public FormCrudCoordDocente()
        {
            InitializeComponent();
            labelMensaje.Text = "";
        }

        // Buscar:
        private void buttonBuscarDocente_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(txtCodigoDocente.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe";
                txtNombresDocente.Text = "";
                txtApellidosDocente.Text = "";
                comboBoxEPDocente.Text = "Seleccionar";
                comboBoxTipo.Text = "Seleccionar";
                comboBoxSubtipo.Items.Clear();
                comboBoxSubtipo.Text = "Seleccionar";
                txtEmailDocente.Text = "";
                txtDireccionDocente.Text = "";
                txtCelularDocente.Text = "";
            }
            else
            {
                dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dt.Rows[0];
                labelMensaje.Text = "Código docente: " + row.CodDocente.ToString();
                txtNombresDocente.Text = row.Nombres;
                txtApellidosDocente.Text = row.Apellidos;
                comboBoxEPDocente.Text = "INGENIERIA INFORMATICA Y DE SISTEMAS";
                txtEmailDocente.Text = row.Email;
                txtDireccionDocente.Text = row.Dirección;
                txtCelularDocente.Text = row.Celular;
                comboBoxTipo.Text = row.TipoContrato;
                if (comboBoxTipo.Text == "NOMBRADO")
                {
                    if (row.Categoria == "PR" && row.Regimen == "DE")
                    {
                        comboBoxSubtipo.Text = "PRINCIPAL - DEDICACIÓN EXCLUSIVA";
                    }
                    if (row.Categoria == "PR" && row.Regimen == "TC")
                    {
                        comboBoxSubtipo.Text = "PRINCIPAL - TIEMPO COMPLETO";
                    }
                    if (row.Categoria == "AS" && row.Regimen == "DE")
                    {
                        comboBoxSubtipo.Text = "ASOCIADO - DEDICACIÓN EXCLUSIVA";
                    }
                    if (row.Categoria == "AS" && row.Regimen == "TC")
                    {
                        comboBoxSubtipo.Text = "ASOCIADO - TIEMPO COMPLETO";
                    }
                    if (row.Categoria == "AS" && row.Regimen == "TP")
                    {
                        comboBoxSubtipo.Text = "ASOCIADO - TIEMPO PARCIAL";
                    }
                    if (row.Categoria == "AU" && row.Regimen == "TC")
                    {
                        comboBoxSubtipo.Text = "AUXILIAR - TIEMPO COMPLETO";
                    }
                    if (row.Categoria == "AU" && row.Regimen == "TP")
                    {
                        comboBoxSubtipo.Text = "AUXILIAR - TIEMPO PARCIAL";
                    }
                }
                if (comboBoxTipo.Text == "CONTRATADO")
                {
                    comboBoxSubtipo.Text = row.Tipo;
                }
                labelMensaje.Text = "";
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSubtipo.Items.Clear();
            comboBoxSubtipo.Text = "Seleccionar";
            if (comboBoxTipo.Text == "NOMBRADO")
            {
                comboBoxSubtipo.Items.Add("PRINCIPAL - DEDICACIÓN EXCLUSIVA");
                comboBoxSubtipo.Items.Add("PRINCIPAL - TIEMPO COMPLETO");
                comboBoxSubtipo.Items.Add("ASOCIADO - DEDICACIÓN EXCLUSIVA");
                comboBoxSubtipo.Items.Add("ASOCIADO - TIEMPO COMPLETO");
                comboBoxSubtipo.Items.Add("ASOCIADO - TIEMPO PARCIAL");
                comboBoxSubtipo.Items.Add("AUXILIAR - TIEMPO COMPLETO");
                comboBoxSubtipo.Items.Add("AUXILIAR - TIEMPO PARCIAL");
            }
            if (comboBoxTipo.Text == "CONTRATADO")
            {
                comboBoxSubtipo.Items.Add("A1");
                comboBoxSubtipo.Items.Add("A2");
                comboBoxSubtipo.Items.Add("A3");
                comboBoxSubtipo.Items.Add("B1");
                comboBoxSubtipo.Items.Add("B2");
                comboBoxSubtipo.Items.Add("B3");
            }
        }

        private string[] ObtenerValores()
        {
            // Combobox Escuela Profesional:
            string Cod_EP = "IN";
            // Combobox Tipo: Nombrado, Contratado
            int indice_tipo = comboBoxTipo.SelectedIndex;
            string tipo_contrato = (string)comboBoxTipo.Items[indice_tipo];
            string subtipo = comboBoxSubtipo.Text;
            string categoria = null, regimen = null;
            if (indice_tipo != -1)
            {
                if (tipo_contrato == "NOMBRADO")
                {
                    if (subtipo == "PRINCIPAL - DEDICACIÓN EXCLUSIVA")
                    {
                        categoria = "PR"; regimen = "DE";
                    }
                    if (subtipo == "PRINCIPAL - TIEMPO COMPLETO")
                    {
                        categoria = "PR"; regimen = "TC";
                    }
                    if (subtipo == "ASOCIADO - DEDICACIÓN EXCLUSIVA")
                    {
                        categoria = "AS"; regimen = "DE";
                    }
                    if (subtipo == "ASOCIADO - TIEMPO COMPLETO")
                    {
                        categoria = "AS"; regimen = "TC";
                    }
                    if (subtipo == "ASOCIADO - TIEMPO PARCIAL")
                    {
                        categoria = "AS"; regimen = "TP";
                    }
                    if (subtipo == "AUXILIAR - TIEMPO COMPLETO")
                    {
                        categoria = "AU"; regimen = "TC";
                    }
                    if (subtipo == "AUXILIAR - TIEMPO PARCIAL")
                    {
                        categoria = "AU"; regimen = "TP";
                    }
                    subtipo = null;
                }
            }

            string[] vals = new string[5] { Cod_EP, tipo_contrato, categoria, regimen, subtipo };
            return vals;
        }

        // Agregar:
        private void buttonAgregarDocente_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(txtCodigoDocente.Text);
            if (dt.Rows.Count != 0)
            {
                labelMensaje.Text = "El código ya existe.";
            }
            else
            {
                string[] vals = ObtenerValores();
                string Cod_EP = vals[0];
                string tipo_contrato = vals[1];
                string categoria = vals[2];
                string regimen = vals[3];
                string tipo = vals[4];
                ta.Insertar(txtCodigoDocente.Text.Trim(),
                            txtNombresDocente.Text.Trim().ToUpper(),
                            txtApellidosDocente.Text.Trim().ToUpper(), 
                            Cod_EP, 
                            tipo_contrato, 
                            categoria, 
                            regimen, 
                            tipo, 
                            txtEmailDocente.Text.Trim(), 
                            txtDireccionDocente.Text.Trim().ToUpper(), 
                            txtCelularDocente.Text.Trim());
                labelMensaje.Text = "Se agregó un nuevo registro.";

                // Si es tutor, crear un usuario para el docente
                dt = ta.GetTutoresByCodEP("IN");

                // Recorrer el data table
                foreach (dsTutorias.DocenteRow rowDocente in dt)
                {
                    if (rowDocente.CodDocente == txtCodigoDocente.Text)
                    {
                        dsTutoriasTableAdapters.UsuariosTableAdapter taUsuarios = new dsTutoriasTableAdapters.UsuariosTableAdapter();

                        string Usuario = txtCodigoDocente.Text + "@unsaac.edu.pe";
                        taUsuarios.Insertar(Usuario, txtCodigoDocente.Text, "TUTOR");
                    }
                }
            }
        }

        // Modificar:
        private void buttonModificarDocente_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(txtCodigoDocente.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe";
            }
            else
            {
                string[] vals = ObtenerValores();
                string Cod_EP = vals[0];
                string tipo_contrato = vals[1];
                string categoria = vals[2];
                string regimen = vals[3];
                string tipo = vals[4];
                ta.Modificar(txtNombresDocente.Text.Trim().ToUpper(), 
                             txtApellidosDocente.Text.Trim().ToUpper(), 
                             Cod_EP, 
                             tipo_contrato, 
                             categoria, 
                             regimen, 
                             tipo, 
                             txtEmailDocente.Text.Trim(), 
                             txtDireccionDocente.Text.Trim().ToUpper(), 
                             txtCelularDocente.Text.Trim().ToUpper(), 
                             txtCodigoDocente.Text.Trim());
                labelMensaje.Text = "Se modificó el registro.";
            }
        }

        // Eliminar:
        private void buttonEliminarDocente_Click(object sender, EventArgs e)
        {
            dsTutoriasTableAdapters.DocenteTableAdapter ta = new dsTutoriasTableAdapters.DocenteTableAdapter();
            dsTutorias.DocenteDataTable dt = ta.GetDataByCodDocente(txtCodigoDocente.Text);
            if (dt.Rows.Count == 0)
            {
                labelMensaje.Text = "El código no existe.";
            }
            else
            {
                ta.Eliminar(txtCodigoDocente.Text);
                labelMensaje.Text = "Se eliminó el registro.";

                // Eliminar usuario también
                dsTutoriasTableAdapters.UsuariosTableAdapter taUsuarios = new dsTutoriasTableAdapters.UsuariosTableAdapter();
                taUsuarios.Eliminar(txtCodigoDocente.Text + "@unsaac.edu.pe");
            }
        }

        private void comboBoxSubtipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
