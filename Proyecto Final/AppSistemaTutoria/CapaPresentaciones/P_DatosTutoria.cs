using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;
using CapaNegocios;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CapaPresentaciones
{
    public partial class P_DatosTutoria : Form
    {
        readonly E_FichaTutoria ObjEntidad = new E_FichaTutoria();
        readonly E_Tutoria ObjEntidadTutoria = new E_Tutoria();
        public bool Test { get; set; }

        public P_DatosTutoria()
        {
            Test = false;
            InitializeComponent();
        }
        public P_DatosTutoria(bool pTest)
        {
            Test = pTest;
        }

        private void MensajeConfirmacion(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Tutoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        public string AgregarOModificar(string CodigoTutoria, string Dimension, string Referencia, string Descripcion,
                                 string Observaciones, DateTimePicker Fecha)
        {
            string Mensaje = "";

            if ((CodigoTutoria.Trim() != "") &&
                (Dimension.Trim() != "") &&
                (Referencia.Trim() != "") &&
                (Descripcion.Trim() != "") &&
                (Observaciones.Trim() != ""))
                
            {
                Regex PatronCodigo = new Regex(@"\A[0-9]{6}\Z");
                Regex PatronTelefono = new Regex(@"\A[0-9]{9}\Z");
                Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");

                if (Program.Evento == 0)
                {
                    try
                    {

                        if (!PatronCodigo.IsMatch(CodigoTutoria))
                        {
                            Mensaje = "El código deber ser de 6 caracteres numéricos";
                            if (Test == false)
                                MensajeError(Mensaje);
                            return Mensaje;
                        }
                        else
                        {
                            ObjEntidad.CodTutoria = CodigoTutoria;
                            ObjEntidad.Dimension = Dimension;
                            ObjEntidad.Referencia = Referencia;
                            ObjEntidad.Descripcion = Descripcion;
                            ObjEntidad.Observaciones = Observaciones;
                            //ObjEntidad.Fecha = Fecha;

                        }
                    }
                    catch (Exception)
                    {
                        if (Test == false)
                            MensajeError("Error al insertar el registro ");
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
                            

                            if (!PatronCodigo.IsMatch(CodigoTutoria))
                            {
                                Mensaje = "El código deber ser de 6 caracteres numéricos";
                                if (Test == false)
                                    MensajeError(Mensaje);
                                return Mensaje;
                            }
                            else
                            {
                                ObjEntidad.CodTutoria = CodigoTutoria;
                                ObjEntidad.Dimension = Dimension;
                                ObjEntidad.Referencia = Referencia;
                                ObjEntidad.Descripcion = Descripcion;
                                ObjEntidad.Observaciones = Observaciones;
                                //ObjEntidad.Fecha = Convert.ToDateTime(String);

                                
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro" + ex);
                    }
                }
            }
            else
            {
                if (CodigoTutoria.Trim() == "")
                {
                    Mensaje = "Debe llenar el código";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (Dimension.Trim() == "")
                {
                    Mensaje = "Debe llenar el campo Tutoria";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (Referencia.Trim() == "")
                {
                    Mensaje = "Debe llenar el apellido materno";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Descripcion.Trim() == "")
                {
                    Mensaje = "Debe llenar el nombre";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                if (Observaciones.Trim() == "")
                {
                    Mensaje = "Debe llenar la dirección";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
            }

            return Mensaje;
        }
        public string AgregarOModificarTutoria(string CodigoTutoria, string CodDocente, string CodEstudiante)
        {
            string Mensaje = "";

            if ((CodigoTutoria.Trim() != "") &&
                (CodDocente.Trim() != "") &&
                (CodEstudiante.Trim() != ""))

            {
                Regex PatronCodigo = new Regex(@"\A[0-9]\Z");
                Regex PatronTelefono = new Regex(@"\A[0-9]\Z");
                Regex PatronTelefonoReferencia = new Regex(@"\A([0-9]{9}\Z)|(^$)");
                ObjEntidadTutoria.CodTutoria = CodigoTutoria;
                ObjEntidadTutoria.CodDocente = CodDocente;
                ObjEntidadTutoria.CodEstudiante = CodEstudiante;
                /*
                if (Program.Evento == 0)
                {
                    try
                    {
                        
                        if (!PatronCodigo.IsMatch(CodigoTutoria))
                        {
                            Mensaje = "El código deber ser de 6 caracteres numéricos";
                            if (Test == false)
                                MensajeError(Mensaje);
                            return Mensaje;
                        }
                        else
                        {
                            ObjEntidadTutoria.CodTutoria = CodigoTutoria;
                            ObjEntidadTutoria.CodDocente = CodDocente;
                            ObjEntidadTutoria.CodEstudiante = CodEstudiante;
                            
                        }
                    }
                    catch (Exception)
                    {
                        if (Test == false)
                            MensajeError("Error al insertar el registro ");
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


                            if (!PatronCodigo.IsMatch(CodigoTutoria))
                            {
                                Mensaje = "El código deber ser de 6 caracteres numéricos";
                                if (Test == false)
                                    MensajeError(Mensaje);
                                return Mensaje;
                            }
                            else
                            {
                                ObjEntidadTutoria.CodTutoria = CodigoTutoria;
                                ObjEntidadTutoria.CodDocente = CodDocente;
                                ObjEntidadTutoria.CodEstudiante = CodEstudiante;


                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MensajeError("Error al editar el registro" + ex);
                    }
                }*/
            }
            else
            {
                if (CodigoTutoria.Trim() == "")
                {
                    Mensaje = "Debe llenar el código";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (CodDocente.Trim() == "")
                {
                    Mensaje = "Debe llenar el campo Cod Docente";
                    if (Test == false)
                        MensajeError(Mensaje);
                }

                if (CodEstudiante.Trim() == "")
                {
                    Mensaje = "Debe llenar el Cod Estudante";
                    if (Test == false)
                        MensajeError(Mensaje);
                }
                
            }

            return Mensaje;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //AgregarOModificar(txtCodTutoria, cxtDimension, txtReferencia, txtDescripcion, txtObservaciones, dateTimeFechaFichaT);
            AgregarOModificarTutoria(txtCodTutoria.Text, txtCodigoEstudiante.Text, txtCodigoDocente.Text);
        }
    }
}
