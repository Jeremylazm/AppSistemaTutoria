using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;

namespace CapaPresentaciones
{
    public partial class P_EditarPerfilDocente : Form
    {
        // Instanciar la capa entidad y negocio de docente
        readonly E_Docente ObjEntidad = new E_Docente();
        readonly N_Docente ObjNegocio = new N_Docente();

        // Inicializar atributos constantes (no modificables por el docente)
        public string Usuario = "";
        private string APaterno = "";
        private string AMaterno = "";
        private string Nombre = "";
        private string CodEscuelaP = "";

        // Contructor de la interfaz para editar el perfil de docente
        public P_EditarPerfilDocente()
        {
            InitializeComponent();
        }

        // Metodo para cargar los datos del docente
        private void CargarDatosUsuario()
        {
            // Buscar sus datos del docente con su usuario
            DataTable Datos = N_Docente.BuscarRegistro(Usuario);

            // Obtener la primera fila con los datos
            object[] Fila = Datos.Rows[0].ItemArray;

            // Verificar si el campo de perfil es nulo
            if (E_InicioSesion.Perfil == null)
            {
                // Asignar una imagen por defecto para docente
                string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
                imgPerfil.Image = Image.FromFile(fullImagePath);
            }
            else
            {
                // Cargar el perfil del docente de la base de datos
                byte[] Perfil = new byte[0];
                Perfil = E_InicioSesion.Perfil;
                MemoryStream MemoriaPerfil = new MemoryStream(Perfil);
                imgPerfil.Image = HacerImagenCircular(Bitmap.FromStream(MemoriaPerfil));
            }

            // Cargar los otros datos del docente
            txtCodigo.Text = Fila[2].ToString();
            APaterno = Fila[3].ToString();
            AMaterno = Fila[4].ToString();
            Nombre = Fila[5].ToString();
            txtDocente.Text = Fila[6].ToString();
            txtEmail.Text = Fila[7].ToString();
            txtDireccion.Text = Fila[8].ToString();
            txtTelefono.Text = Fila[9].ToString();
            txtCategoria.Text = Fila[10].ToString();
            txtSubcategoria.Text = Fila[11].ToString();
            txtRegimen.Text = Fila[12].ToString();
            CodEscuelaP = Fila[13].ToString();
            txtEscuelaP.Text = Fila[14].ToString();
            txtHorario.Text = Fila[15].ToString();
        }

        // Metodo para mostrar un mensaje de confirmacion
        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Metodo para mostrar un mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Metodo para hacer una imagen circular
        public Image HacerImagenCircular(Image img)
        {
            // Determinar el centro de la imagen
            int x = img.Width / 2;
            int y = img.Height / 2;

            // Determinar el radio de la imagen
            int r = Math.Min(x, y);

            // Generar el espacio donde estara la imagen (cuadrado)
            Bitmap tmp = null;
            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                // Mover la imagen al centro
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);

                // Generar un circulo con los atributos determinados
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);

                // Cortar el espacio en forma circular
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);

                // Dibujar la imagen circular
                Bitmap bmp = new Bitmap(img);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            // Retornar la imagen circular
            return tmp;
        }

        #region Eventos
        // Evento al hacer click en el boton "Subir Perfil" para subir una imagen
        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            // Verificar si no hay problemas al cargar una imgen
            try
            {
                // Abrir una ventana para seleccionar una imagen
                OpenFileDialog Archivo = new OpenFileDialog();
                Archivo.Filter = "Archivos de Imagen | *.jpg; *.jpeg; *.png; *.gif; *.tif";
                Archivo.Title = "Subir Perfil";

                // Verificar si ya se eligio una imagen
                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    // Cargar imagen en el formulario
                    imgPerfil.Image = HacerImagenCircular(Image.FromFile(Archivo.FileName));
                }
            }
            catch (Exception)
            {
                // Mostrar mensaje de error
                MensajeError("Error al subir perfil");
            }
        }

        // Evento al hacer click en el boton "Restablecer Perfil" para restablecer el perfil a una imagen por defecto
        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            // Cargar imagen por defecto en el formulario
            imgPerfil.Image = Image.FromFile("C:/Users/Jeremylazm/Desktop/Documentos/AppSistemaTutoria/CapaPresentaciones/Iconos/Perfil Estudiante.png");
        }

        // Evento al cargar el formulario para cargar los datos del docente
        private void P_EditarPerfilDocente_Load(object sender, EventArgs e)
        {
            // Cargar los datos del docente
            CargarDatosUsuario();
        }

        // Evento al hacer click en el boton "Guardar" para moficar los datos del docente
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Mostrar mensaje para saber si realmente se desea editar los datos
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Realmente desea editar el registro?", "Sistema de Tutoría", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Si el docente, quiere cambiar sus datos
            if (Opcion == DialogResult.OK)
            {
                // Asignar campo por campo, los datos editados en el objeto entidad del docente
                byte[] Perfil = new byte[0];
                using (MemoryStream MemoriaPerfil = new MemoryStream())
                {
                    imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                    Perfil = MemoriaPerfil.ToArray();
                }
                E_InicioSesion.Perfil = Perfil;
                ObjEntidad.Perfil = Perfil;
                ObjEntidad.CodDocente = txtCodigo.Text;
                ObjEntidad.APaterno = APaterno;
                ObjEntidad.AMaterno = AMaterno;
                ObjEntidad.Nombre = Nombre;
                ObjEntidad.Email = txtEmail.Text;
                ObjEntidad.Direccion = txtDireccion.Text.ToUpper();
                ObjEntidad.Telefono = txtTelefono.Text;
                ObjEntidad.Categoria = txtCategoria.Text;
                ObjEntidad.Subcategoria = txtSubcategoria.Text;
                ObjEntidad.Regimen = txtRegimen.Text;
                ObjEntidad.CodEscuelaP = CodEscuelaP;
                ObjEntidad.Horario = txtHorario.Text;

                // Editar el registro en la base de datos con sus datos
                ObjNegocio.EditarRegistros(ObjEntidad);

                // Mostrar mensaje de confirmacion dando entender que se edito sus datos del docente
                MensajeConfirmacion("Registro editado exitosamente");
            }
        }

        // Evento al hacer click en el icono de "Cerrar" para cerrar el formulario
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Evento al hacer click en el boton "Cambiar Contraseña" para cambiar su contraseña
        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            // Instanciar el formulario de cambiar contraseña con el codigo del docente y su email
            P_CambiarContraseña NuevaContraseña = new P_CambiarContraseña
            {
                Usuario = E_InicioSesion.Usuario,
                Correo = txtEmail.Text
            };

            // Mostrar el formulario
            NuevaContraseña.ShowDialog();

            // Eliminar recursos que hubieron en el formulario
            NuevaContraseña.Dispose();
        }
        #endregion
    }
}
