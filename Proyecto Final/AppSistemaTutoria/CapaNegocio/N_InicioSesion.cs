using CapaDatos;

namespace CapaNegocios
{
    public class N_InicioSesion
    {
        readonly D_InicioSesion ObjInicioSesion = new D_InicioSesion();

        public bool IniciarSesion(string Usuario, string Contraseña)
        {
            return ObjInicioSesion.IniciarSesion(Usuario, Contraseña);
        }
    }
}
