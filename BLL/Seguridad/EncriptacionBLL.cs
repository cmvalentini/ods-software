using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
   public class EncriptacionBLL
    {
        BE.Seguridad.Encriptacion cryp = new BE.Seguridad.Encriptacion();
        public readonly string key = "MasterKey";

        public string Encriptar(string Texto)
        {

            byte[] keyArray;

            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Texto.ToString());

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();


            //se guarda la llave para que se le realice hashing
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key.ToString()));

            hashmd5.Clear();

            //Algoritmo 3DAS
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            //se empieza con la transformación de la cadena
            ICryptoTransform cTransform = tdes.CreateEncryptor();

            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();

            string result = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);

            return result;

        }

        public string cryptshort(string text)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashValue = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                foreach (byte b in hashValue)
                {
                    sb.Append($"{b:X2}");
                }
            }

            return sb.ToString();
        }


        public string Desencriptar(string TextoEncriptado) //string encriptado
        {
            byte[] keyArray;
            //convierte el texto en una secuencia de bytes
            byte[] Array_a_Descifrar = Convert.FromBase64String(TextoEncriptado);


            //se llama a las clases que tienen los algoritmos //de encriptación se le aplica hashing

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
            tdes.Clear();

            string Result = UTF8Encoding.UTF8.GetString(resultArray);

            return Result;
        }

        public BE.Seguridad.Encriptacion CrearPassword() //int longitud
        {
            cryp.Longitud = 8;
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < cryp.Longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            cryp.Result = res.ToString();
            return cryp;
        }

        public BE.Seguridad.Encriptacion CrearPassword(BE.Seguridad.Encriptacion crip) //int longitud
        {
            cryp.Longitud = 8;
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < cryp.Longitud--)
            {
                res.Append(caracteres[rnd.Next(caracteres.Length)]);
            }
            cryp.Result = res.ToString();
            crip.Result = cryp.Result;
            return crip;
        }

    }
}
