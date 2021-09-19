using System;
using System.Drawing;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System.IO;
using System.Drawing.Drawing2D;

namespace CapaPresentaciones
{
    public partial class P_TablaTutorados : Form
    {
        readonly E_Estudiante ObjEntidad = new E_Estudiante();
        readonly N_Estudiante ObjNegocio = new N_Estudiante();

        public P_TablaTutorados()
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

        public void AccionesTabla()
        {
            dgvTabla.Columns[0].Visible = false;
            dgvTabla.Columns[3].Visible = false;
            dgvTabla.Columns[4].Visible = false;
            dgvTabla.Columns[5].Visible = false;
            dgvTabla.Columns[10].Visible = false;
            dgvTabla.Columns[15].Visible = false;
            dgvTabla.Columns[16].Visible = false;

            dgvTabla.Columns[1].HeaderText = "";
            dgvTabla.Columns[2].HeaderText = "Cod. Estudiante";
            dgvTabla.Columns[6].HeaderText = "Estudiante";
            dgvTabla.Columns[7].HeaderText = "Email";
            dgvTabla.Columns[8].HeaderText = "Dirección";
            dgvTabla.Columns[9].HeaderText = "Teléfono";
            dgvTabla.Columns[11].HeaderText = "Escuela Profesional";
            dgvTabla.Columns[12].HeaderText = "Persona de Ref.";
            dgvTabla.Columns[13].HeaderText = "Teléfono de Ref.";
            dgvTabla.Columns[14].HeaderText = "Información Personal";
        }

        public void MostrarRegistros()
        {
            dgvTabla.DataSource = N_Docente.MostrarTutorados(E_InicioSesion.Usuario);
            AccionesTabla();
        }

        public void BuscarRegistros()
        {
            dgvTabla.DataSource = N_Docente.BuscarTutorados(E_InicioSesion.Usuario, txtBuscar.Text, 1000000);
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            MostrarRegistros();
        }

        public Image HacerImagenCircular(Image img)
        {
            int x = img.Width / 2;
            int y = img.Height / 2;
            int r = Math.Min(x, y);

            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            return tmp;
        }

        private void P_TablaTutorados_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarRegistros();
        }

        private void dgvTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTabla.Columns[e.ColumnIndex].HeaderText == "")
            {
                byte[] bits = new byte[0];
                bits = (byte[])e.Value;
                MemoryStream ms = new MemoryStream(bits);
                Image imgSave = Image.FromStream(ms);
                e.Value = HacerImagenCircular(imgSave);
            }
        }
    }
}
