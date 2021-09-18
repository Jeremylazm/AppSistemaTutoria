using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;
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
            ValidarPerfil();
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

        private void ValidarPerfil()
        {
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
            if (imgPerfil.Image == Image.FromFile(fullImagePath))
            {
                btnRestablecerPerfil.Visible = false;
            }
        }

        private void LlenarComboBox()
        {
            cxtCategoria.SelectedIndex = 0;
            cxtSubcategoria.SelectedIndex = 0;
            cxtRegimen.SelectedIndex = 0;

            if (E_InicioSesion.Acceso == "Administrador")
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarRegistros();
            }
            else
            {
                cxtEscuela.DataSource = N_EscuelaProfesional.MostrarRegistros(E_InicioSesion.Usuario);
                cxtEscuela.Enabled = false;
            }

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
                        byte[] Perfil = new byte[0];
                        using (MemoryStream MemoriaPerfil = new MemoryStream())
                        {
                            imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                            Perfil = MemoriaPerfil.ToArray();
                        }
                        ObjEntidad.Perfil = Perfil;
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
                        ObjEntidad.Horario = txtHorario.Text.ToUpper();

                        ObjNegocio.InsertarRegistros(ObjEntidad);
                        MensajeConfirmacion("Registro insertado exitosamente");
                        Program.Evento = 0;

                        N_InicioSesion InicioSesion = new N_InicioSesion();
                        string Contrasena = InicioSesion.RetornarContrasena(txtCodigo.Text);

                        // Enviar un correo con la contraseña para un nuevo usuario
                        try
                        {
                            SmtpClient clientDetails = new SmtpClient();
                            clientDetails.Port = 587;
                            clientDetails.Host = "smtp.gmail.com";
                            clientDetails.EnableSsl = true;
                            clientDetails.DeliveryMethod = SmtpDeliveryMethod.Network;
                            clientDetails.UseDefaultCredentials = false;
                            clientDetails.Credentials = new NetworkCredential("denisomarcuyottito@gmail.com", "Tutoriasunsaac5");

                            MailMessage mailDetails = new MailMessage();
                            mailDetails.From = new MailAddress("denisomarcuyottito@gmail.com");
                            mailDetails.To.Add(ObjEntidad.Email);
                            mailDetails.Subject = "Contraseña del Sistema de Tutoría UNSAAC";
                            mailDetails.IsBodyHtml = true;
                            mailDetails.Body = "Tu contraseña es " + Contrasena;
                            clientDetails.Send(mailDetails);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

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
                            byte[] Perfil = new byte[0];
                            using (MemoryStream MemoriaPerfil = new MemoryStream())
                            {
                                imgPerfil.Image.Save(MemoriaPerfil, ImageFormat.Bmp);
                                Perfil = MemoriaPerfil.ToArray();
                            }
                            ObjEntidad.Perfil = Perfil;
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
                            ObjEntidad.Horario = txtHorario.Text.ToUpper();

                            ObjNegocio.EditarRegistros(ObjEntidad);
                            MensajeConfirmacion("Registro editado exitosamente");
                            Program.Evento = 0;
                            LimpiarCajas();
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro " + ex);
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
            Program.Evento = 0;
            Close();
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

        private void btnSubirPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Archivo = new OpenFileDialog();
                Archivo.Filter = "Archivos de Imagen | *.jpg; *.jpeg; *.png; *.gif; *.tif"; 
                Archivo.Title = "Subir Perfil";

                if (Archivo.ShowDialog() == DialogResult.OK)
                {
                    imgPerfil.Image = HacerImagenCircular(Image.FromFile(Archivo.FileName));
                }
            }
            catch (Exception)
            {
                MensajeError("Error al subir perfil");
            }
        }

        private void btnRestablecerPerfil_Click(object sender, EventArgs e)
        {
            string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Docente.png");
            imgPerfil.Image = Image.FromFile(fullImagePath);
        }
    }
}
