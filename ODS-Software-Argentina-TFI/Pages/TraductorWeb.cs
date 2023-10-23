using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages
{
    public class TraductorWeb
    {
        public static void TraducirPagina(int idiomaid,System.Web.UI.Page pagina)
        {

            try
            {
                if (pagina.HasControls())
                {
                    //busco controles
                    List<WebControl> controles = BuscarControles(pagina);
                    List<string> nombresControles = new List<string>();
                    foreach (var control in controles)
                    {
                        if (control is GridView gridview)
                        {
                            //Saco columnas de gridview
                            List<TemplateField> columnas = (control as GridView).Columns.Cast<TemplateField>().ToList();
                            nombresControles.AddRange(columnas.Select(c => c.HeaderText));
                        }
                        else
                        {
                            nombresControles.Add(control.ID);
                        }
                    }
                    

                    BLL.IdiomaBLL idibll = new BLL.IdiomaBLL();
                    Dictionary<string, string> dict = idibll.GetIdioma(idiomaid, nombresControles);
                    
                    string val = "";
                    int i = 0;

                    if (dict.Count > 0)
                    {
                        foreach (var control in controles)
                        {
                            i++;
                            //Aca hay 2 posibilidades, o tiene Text, o es algun campo especial como una columna
                            if (control is GridView)
                            {
                                //Grdviews
                                List<BoundField> columnas = (control as GridView).Columns.Cast<BoundField>().ToList();
                                foreach (var col in columnas)
                                {
                                    if (dict.TryGetValue(col.DataField, out val))
                                    {
                                        col.HeaderText = val;
                                    }
                                }
                            }
                            else
                            {
                                //Labels, TextBox, Buttons, etc.
                                if (dict.TryGetValue(control.ID, out val))
                                {
                                    PropertyInfo proptxt = control.GetType().GetProperty("Text");
                                    if (proptxt != null)
                                    {
                                        if (proptxt.CanRead && proptxt.CanWrite)
                                        {
                                            proptxt.SetValue(control, val);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static List<WebControl> BuscarControles(Control parent)
        {
            List<WebControl> webControls = new List<WebControl>();

            foreach (Control control in parent.Controls)
            {
                if (control is WebControl webControl)
                {
                    webControls.Add(webControl);
                }

                if (control.HasControls())
                {
                    webControls.AddRange(BuscarControles(control));
                }
            }

            return webControls;
        }


    }
}