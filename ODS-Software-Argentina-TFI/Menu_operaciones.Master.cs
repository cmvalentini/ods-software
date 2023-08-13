using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI
{
    public partial class Menu_operaciones : System.Web.UI.MasterPage
    {
        IList<BLL.PermisosComposite.Component> listaoperaciones;
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite("MenuPrincipal");

        protected void Page_Load(object sender, EventArgs e)
        {
            traerpermisos();
          
        }

        private void traerpermisos() {
            listaoperaciones = Composite.devolerinstanciapermisos();
            this.MapeoComponentes(listaoperaciones);

        }

        private void MapeoComponentes(IList<BLL.PermisosComposite.Component> listaoperaciones)
        {

            foreach (var i in listaoperaciones) //hacer aca el composite
            {
                string var = i.Nombre.ToString();
                switch (var)
                {
                    case "hacerbackup":
                        btnhacerbackup.Visible = true;
                        break;
                }

            }



        }

    }
}