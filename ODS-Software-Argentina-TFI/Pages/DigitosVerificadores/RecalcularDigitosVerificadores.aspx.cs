﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.DigitosVerificadores
{
    public partial class RecalcularDigitosVerificadores : System.Web.UI.Page
    {
        BLL.Seguridad.DigitosVerificadoresBLL digitos = new BLL.Seguridad.DigitosVerificadoresBLL();
        public static string permiso = "digitosverificadores";
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (state.verificarpermisos(permiso, (int)Session["UsuarioID"]) == 1)
                {
                    if (Session["IdiomaID"] is null)
                    {
                        Session["IdiomaID"] = 0;
                        TraductorWeb.TraducirPagina((int)Session["IdiomaID"], this);
                    }
                    else
                    {
                        TraductorWeb.TraducirPagina((int)Session["IdiomaID"], this);
                    }

                }
                else
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");
          
        }

        protected void btnRecalcularDigitos_Click(object sender, EventArgs e)
        {
            digitos.RecalcularDigitos();
            (this.Master as Menu_operaciones).mostrarmodal("Digitos Recalculados correctamente", BE.ControlException.TipoEventoException.Info);

        }
    }
}