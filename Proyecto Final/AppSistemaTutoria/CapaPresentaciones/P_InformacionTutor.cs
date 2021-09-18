using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_InformacionTutor : Form
    {
        public string Usuario = "";
        public P_InformacionTutor( string pUsuario)
        {
            InitializeComponent();
            Usuario = pUsuario;
            CargarDatosTutor();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void CargarDatosTutor()
        {
            SqlConnection Conexion = new SqlConnection(@"Data Source = localhost\SQLEXPRESS; DataBase = db_a7878d_BDSistemaTutoria; Integrated Security = true");
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT D.APaterno, D.AMaterno, D.Nombre, D.Email, D.Direccion, D.Telefono, " +
                "D.CodEscuelaP, D.Horario FROM((TEstudiante E INNER JOIN TTutoria T " +
                "ON E.CodEstudiante = T.CodEstudiante) INNER JOIN TDocente D ON T.CodDocente = D.CodDocente) WHERE E.CodEstudiante = @CodEstudiante", Conexion);

                cmd.Parameters.AddWithValue("@CodEstudiante", Usuario);
                Conexion.Open();
                SqlDataReader Registro = cmd.ExecuteReader();
                if (Registro.Read())
                {
                    txtDocente.Text = Registro["APaterno"].ToString() + " " + Registro["AMaterno"].ToString() + 
                        " " + Registro["Nombre"].ToString();
                    txtEmail.Text = Registro["Email"].ToString();
                    txtDireccion.Text = Registro["Direccion"].ToString();
                    txtTelefono.Text = Registro["Telefono"].ToString();
                    txtEscProfesional.Text = Registro["CodEscuelaP"].ToString();
                    txtHorario.Text = Registro["Horario"].ToString();
                }
                Conexion.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEscProfesional_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
