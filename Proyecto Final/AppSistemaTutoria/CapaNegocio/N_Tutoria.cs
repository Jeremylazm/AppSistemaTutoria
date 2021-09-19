using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocios
{
    public class N_Tutoria
    {
        readonly D_Tutoria ObjTutoria = new D_Tutoria();

        public static DataTable MostrarRegistros()
        {
            return new D_Tutoria().MostrarRegistros();
        }

        public static DataTable BuscarRegistros(string Texto)
        {
            return new D_Tutoria().BuscarRegistros(Texto);
        }

        public static string InsertarRegistros(E_Tutoria Tutoria, DataTable FichaTutoria)
        {
            D_Tutoria ObjTutoria = new D_Tutoria();
            List<E_FichaTutoria> Ficha = new List<E_FichaTutoria>();
            foreach (DataRow Fila in FichaTutoria.Rows)
            {
                E_FichaTutoria ObjFichaTutoria = new E_FichaTutoria
                {
                    Fecha = Convert.ToDateTime(Fila["Cantidad"].ToString()),
                    Dimension = Fila["Descripcion"].ToString(),
                    Descripcion = Fila["Precio"].ToString(),
                    Referencia = Fila["Gravadas"].ToString(),
                    Observaciones = Fila["Totales"].ToString(),
                };
                Ficha.Add(ObjFichaTutoria);
            }
            return ObjTutoria.InsertarRegistro(Tutoria, Ficha);
        }

        public void EditarRegistros(E_Tutoria Tutoria)
        {
            ObjTutoria.ModificarRegistro(Tutoria);
        }

        public void EliminarRegistros(E_Tutoria Tutoria)
        {
            ObjTutoria.EliminarRegistro(Tutoria);
        }
    }
}
