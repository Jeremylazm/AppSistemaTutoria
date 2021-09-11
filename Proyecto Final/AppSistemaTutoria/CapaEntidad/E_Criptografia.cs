using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; //Libreria necesaria

namespace CapaEntidades
{
    public class E_Criptografia
    {
        //Metodos estaticos
        #region Encriptacion RSA
        public static string EncriptarRSA(string Mensaje, string Clave)
        {
            //NOTA: El mensaje debe tener como máximo 117 caracteres
            try
            {
                //Política de Seguridad del Contenido (CSP)
                CspParameters CSApars = new CspParameters();
                CSApars.KeyContainerName = Clave; //Definir clave
                                                  //Definir instacia RSA
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(CSApars);
                //Convertir mensaje en bytes
                byte[] Msg = Encoding.UTF8.GetBytes(Mensaje);
                //Encriptar mensaje
                byte[] MsgEncriptado = RSA.Encrypt(Msg, false);
                //Convertir bytes en cadena y retornar
                return Convert.ToBase64String(MsgEncriptado);
            }
            catch (Exception e)
            {
                Console.WriteLine("El mensaje debe tener 117 caracteres como máximo: " + e);
                return null;
            }
        }
        public static string DesencriptarRSA(string MensajeEncriptado, string Clave)
        {
            try
            {
                //Política de Seguridad del Contenido (CSP)
                CspParameters CSApars = new CspParameters();
                CSApars.KeyContainerName = Clave;//Definir clave
                //Definir instacia RSA
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(CSApars);
                //Converitir mensaje en bytes
                byte[] MsgDesencriptado = Convert.FromBase64String(MensajeEncriptado);
                //Desencriptar mensaje
                byte[] Msg = RSA.Decrypt(MsgDesencriptado, false);
                //Convertir bytes en cadena y retornar
                return Encoding.UTF8.GetString(Msg);
            }
            catch (Exception e)
            {
                Console.WriteLine("Clave incorrecta" + e);
                return null;
            }
        }
        #endregion

        #region Cifrado MD5
        public static string CifradoMD5(string Contraseña) //Método de clase
        {
            //Guardar contraseña en bytes en un arreglo
            byte[] ContraseñaBytes = new UTF8Encoding().GetBytes(Contraseña);
            //Aplicar MD5 para generar hash
            byte[] Hash = System.Security.Cryptography.MD5.Create().ComputeHash(ContraseñaBytes);
            //Representación en string
            string ContraseñaCifrada = BitConverter.ToString(Hash)
               .Replace("-", "") //Sin guiones
               .ToLower(); //En minusculas
            return ContraseñaCifrada;
        }
        #endregion
    }
}
