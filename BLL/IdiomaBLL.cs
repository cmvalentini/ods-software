using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IdiomaBLL
    {
        public string GetTraduccionMensaje(int ididioma, string clave)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string filename = "";

            switch (ididioma)
            {
                case 0:
                    filename = "esp-lang";
                    break;
                case 1:
                    filename = "eng-lang";
                    break;
            }

            string resourceName = assembly.GetManifestResourceNames()
                                            .Single(str => str.Contains(filename));

            try
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    ResourceReader res = new ResourceReader(stream);
                    string trad = res.Cast<DictionaryEntry>()
                                                        .Where(d => d.Key.Equals(clave))
                                                        .Select(d => d.Value)
                                                        .FirstOrDefault().ToString();

                    return trad;
                }
            }
            catch (Exception)
            {
                return "ERR-TRAD";
            }

        }

        public Dictionary<string, string> GetIdioma(int ididioma, List<string> claves)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string filename = "";
            string idiomaname = "";
            switch (ididioma)
            {
                case 0:
                    filename = "esp-lang";
                    idiomaname = "Español";
                    break;
                case 1:
                    filename = "eng-lang";
                    idiomaname = "English";
                    break;
            }

            string resourceName = assembly.GetManifestResourceNames()
                                            .Single(str => str.Contains(filename));


            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                ResourceReader res = new ResourceReader(stream);
                Dictionary<string, string> dict = res.Cast<DictionaryEntry>()
                                                    .Where(d => claves.Contains(d.Key))
                                                    .ToDictionary(r => r.Key.ToString(),
                                                                  r => r.Value.ToString());

                return dict;
            }
        }

        //public Idioma ActualizarIdioma(int ididioma)
        //{
        //    string idtext = "";

        //    switch (ididioma)
        //    {
        //        case 0:
        //            idtext = "Español";
        //            break;
        //        case 1:
        //            idtext = "English";
        //            break;
        //    }

        //    Idioma idio = new Idioma(ididioma, idtext);
        //    Sesion.ObtenerInstancia().idioma = idio;

        //    return idio;
        //}


    }
}
