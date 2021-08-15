using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsFix.dsTutoriasTableAdapters;

namespace WinFormsFix
{
    public partial class FormTutorActualizarDatos : Form
    {
        // TableAdapter Docente:
        private DocenteTableAdapter taDocente = new DocenteTableAdapter();
        private dsTutorias.DocenteDataTable dtDocente = new dsTutorias.DocenteDataTable();

        public FormTutorActualizarDatos(string CodDocente)
        {
            InitializeComponent();
            labelMensaje.Text = "";
            FillPersonalData(CodDocente);
        }

        private void FillPersonalData(string CodDocente)
        {
            dtDocente = taDocente.GetDataByCodDocente(CodDocente);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dtDocente.Rows[0];
            labelCodigoDocente.Text = CodDocente;
            labelNombresDocente.Text = row.Nombres;
            labelApellidosDocente.Text = row.Apellidos;
            labelEPDocente.Text = "INGENIERIA INFORMÁTICA Y DE SISTEMAS";
            labelTipoContratoDocente.Text = row.TipoContrato;
            textBoxEmailDocente.Text = row.Email;
            textBoxDireccionDocente.Text = row.Dirección;
            textBoxCelularDocente.Text = row.Celular;
            if (row.TipoContrato == "NOMBRADO")
            {
                if (row.Categoria == "PR" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "PR" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "PRINCIPAL - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "DE")
                {
                    labelCatRegTipo.Text = "ASOCIADO - DEDICACIÓN EXCLUSIVA";
                }
                if (row.Categoria == "AS" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AS" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "ASOCIADO - TIEMPO PARCIAL";
                }
                if (row.Categoria == "AU" && row.Regimen == "TC")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO COMPLETO";
                }
                if (row.Categoria == "AU" && row.Regimen == "TP")
                {
                    labelCatRegTipo.Text = "AUXILIAR - TIEMPO PARCIAL";
                }
            }
            if (row.TipoContrato == "CONTRATADO")
            {
                labelCatRegTipo.Text = row.Tipo;
            }
        }

        private void buttonActualizarTutor_Click(object sender, EventArgs e)
        {
            labelMensaje.Text = "";
            dtDocente = taDocente.GetDataByCodDocente(labelCodigoDocente.Text);
            dsTutorias.DocenteRow row = (dsTutorias.DocenteRow)dtDocente.Rows[0];

            string Tipo = null;
            string Categoria = null;
            string Regimen = null;

            if (row.TipoContrato == "NOMBRADO")
            {
                Categoria = row.Categoria;
                Regimen = row.Regimen;
            }
            if (row.TipoContrato == "CONTRATADO")
            {
                Tipo = row.Tipo;
            }

            taDocente.Modificar(labelNombresDocente.Text,
                                labelApellidosDocente.Text,
                                "IN",
                                labelTipoContratoDocente.Text,
                                Categoria,
                                Regimen,
                                Tipo,
                                textBoxEmailDocente.Text,
                                textBoxDireccionDocente.Text,
                                textBoxCelularDocente.Text,
                                labelCodigoDocente.Text) ;

            labelMensaje.Text = "Se modificó el registro";
        }
    }
}
