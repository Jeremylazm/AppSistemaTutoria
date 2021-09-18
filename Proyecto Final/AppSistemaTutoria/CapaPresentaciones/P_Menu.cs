using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentaciones
{
    public partial class P_Menu : Form
    {
        public string Acceso = "";

        public P_Menu()
        {
            InitializeComponent();
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

        private void CargarDatosUsuario()
        {
            if (E_InicioSesion.Perfil == null)
            {
                string fullImagePath = "";
                if ((E_InicioSesion.Acceso == "Director de Escuela") || (E_InicioSesion.Acceso == "Administrador"))
                    fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil.png");
                
                if (E_InicioSesion.Acceso == "Docente")
                    fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");

                if (E_InicioSesion.Acceso == "Estudiante")
                    fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");

                imgPerfil.Image = Image.FromFile(fullImagePath);
            }
            else
            {
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
            }
            lblDatos.Text = E_InicioSesion.Datos;
            lblAcceso.Text = E_InicioSesion.Acceso;
            lblUsuario.Text = E_InicioSesion.Usuario;
        }

        private void ActualizarDatos(object sender, FormClosedEventArgs e)
        {
            CargarDatosUsuario();
        }

        private void ActualizarPerfil(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void GestionarAcceso()
        {
            if ((Acceso == "Director de Escuela") || (Acceso == "Administrador"))
            {
                btnTutorias.Visible = true;
                btnTutorados.Visible = true;
                btnDocentes.Visible = true;
                btnTutores.Visible = true;
                btnEstudiantes.Visible = true;
                btnInformeTutorias.Visible = true;
                btnMiTutor.Visible = false;
            }
            else if (Acceso == "Docente")
            {
                btnTutorias.Visible = true;
                btnTutorados.Visible = true;
                btnDocentes.Visible = false;
                btnTutores.Visible = false;
                btnEstudiantes.Visible = false;
                btnInformeTutorias.Visible = false;
                btnMiTutor.Visible = false;
            }
            else if (Acceso == "Estudiante")
            {
                btnTutorias.Visible = false;
                btnTutorados.Visible = false;
                btnDocentes.Visible = false;
                btnTutores.Visible = false;
                btnEstudiantes.Visible = false;
                btnInformeTutorias.Visible = false;
                btnMiTutor.Visible = true;
                separador.Visible = false;
            }
            else
            {
                if (MessageBox.Show("Acceso inválido", "Sistema de Tutoría", MessageBoxButtons.OK) == DialogResult.OK)
                    Application.Exit();
            }
        }

        private const int TamañoGrid = 10;
        private const int AreaMouse = 132;
        private const int BotonIzquierdo = 17;
        private Rectangle RectanguloGrid;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            var Region = new Region(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            RectanguloGrid = new Rectangle(ClientRectangle.Width - TamañoGrid, ClientRectangle.Height - TamañoGrid, TamañoGrid, TamañoGrid);
            Region.Exclude(RectanguloGrid);
            pnPrincipal.Region = Region;
            Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case AreaMouse:
                    base.WndProc(ref m);

                    var ReferenciaPunto = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));

                    if (!RectanguloGrid.Contains(ReferenciaPunto))
                        break;

                    m.Result = new IntPtr(BotonIzquierdo);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush Solido = new SolidBrush(Color.FromArgb(232, 158, 31));
            e.Graphics.FillRectangle(Solido, RectanguloGrid);

            base.OnPaint(e);

            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, RectanguloGrid);
        }

        int Lx, Ly;
        int Sw, Sh;

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            Size = new Size(Sw, Sh);
            Location = new Point(Lx, Ly);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            Lx = Location.X;
            Ly = Location.Y;
            Sw = Size.Width;
            Sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir de la aplicación?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            if (lblAcceso.Text == "Estudiante")
            {
                P_EditarPerfilEstudiante Editar = new P_EditarPerfilEstudiante
                {
                    Usuario = E_InicioSesion.Usuario,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                Editar.btnGuardar.Click += new EventHandler(ActualizarPerfil);

                pnContenedor.Controls.Add(Editar);
                pnContenedor.Tag = Editar;
                Editar.Show();
                Editar.BringToFront();
            }
            else if(lblAcceso.Text == "Docente")
            {
                P_EditarPerfilDocente Editar = new P_EditarPerfilDocente
                {
                    Usuario = E_InicioSesion.Usuario,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                Editar.btnGuardar.Click += new EventHandler(ActualizarPerfil);

                pnContenedor.Controls.Add(Editar);
                pnContenedor.Tag = Editar;
                Editar.Show();
                Editar.BringToFront();
            }
            else
            {
                P_EditarPerfilDirector Editar = new P_EditarPerfilDirector
                {
                    Usuario = E_InicioSesion.Usuario,
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };
                Editar.btnGuardar.Click += new EventHandler(ActualizarPerfil);

                pnContenedor.Controls.Add(Editar);
                pnContenedor.Tag = Editar;
                Editar.Show();
                Editar.BringToFront();
            }
        }

        private void btnTutorias_Click(object sender, EventArgs e)
        {
            AbrirFormularios<P_TablaTutorias>();
        }

        private void btnTutorados_Click(object sender, EventArgs e)
        {
            AbrirFormularios<P_TablaTutorados>();
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
            AbrirFormularios<P_TablaDocentes>();
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirFormularios<P_TablaEstudiantes>();
        }

        /*
        private void btnInformeTutorias_Click(object sender, EventArgs e)
        {
            //AbrirFormularios<P_InformeTutorias>();
        }
        */

        private void btnTutores_Click(object sender, EventArgs e)
        {
            AbrirFormularios<P_TablaTutores>();
        }

        private void btnMiTutor_Click(object sender, EventArgs e)
        {
            P_InformacionTutor Editar = new P_InformacionTutor(E_InicioSesion.Usuario);
            Editar.Show();
        }

        private void P_Menu_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
            GestionarAcceso();
        }

        private void AbrirFormularios<FormularioAbrir>() where FormularioAbrir : Form, new()
        {
            Form Formularios = pnContenedor.Controls.OfType<FormularioAbrir>().FirstOrDefault();

            if (Formularios == null)
            {
                Formularios = new FormularioAbrir
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                pnContenedor.Controls.Add(Formularios);
                pnContenedor.Tag = Formularios;
                Formularios.Show();
                Formularios.BringToFront();
            }
            else
            {
                Formularios.BringToFront();
            }
        }
    }
}
