﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Familia
{
    public partial class AsignarPermisosFamilia : System.Web.UI.Page
    {
        BLL.PermisosComposite.ManejadorPerfilUsuarios mpu = new BLL.PermisosComposite.ManejadorPerfilUsuarios();
        List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>();
        List<BE.Permisos.Component> listaoperacionesperfil = new List<BE.Permisos.Component>();
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite();
        BE.Familia.Familia PerfilBE = new BE.Familia.Familia();
        List<BE.Familia.Familia> listafamilias = new List<BE.Familia.Familia>();
        BLL.Familia.FamiliaBLL familiaBLL = new BLL.Familia.FamiliaBLL();
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        public static string permiso = "AsignarPermisos";
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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
                    listafamilias = familiaBLL.GetFamilias(listafamilias);

                    ddlRolList.DataSource = listafamilias;
                    ddlRolList.DataTextField = "NombrePerfil";
                    ddlRolList.DataValueField = "NombrePerfil";
                    ddlRolList.DataBind();
                }
                else {
                    Response.Redirect("~/Pages/Login.aspx");

                }
               
            }
         
            //ordenarlistas();
        }

        protected void ddlRolList_SelectedIndexChanged(object sender, EventArgs e)
        {
      
            ordenarlistas();
        }

        private void ordenarlistas() {

            PerfilBE.NombrePerfil = ddlRolList.SelectedItem.Value;
            String rolSelected = ddlRolList.SelectedItem.ToString();
            String rolSelected1 = ddlRolList.SelectedIndex.ToString();

            listAssing.Items.Clear();
            listNotAssing.Items.Clear();
            listaoperacionesperfil.Clear();
            listaoperacionesperfil = mpu.MostrarListaOperaciones(PerfilBE);
            listaoperaciones.Clear();
            listaoperaciones = mpu.GetOperaciones();

            for (int i = 0; i < listaoperaciones.Count; i++)
            {
                for (int j = 0; j < listaoperacionesperfil.Count; j++)
                {
                    listaoperaciones = listaoperaciones.OrderBy(x => x.Nombre).ToList();
                    listaoperacionesperfil = listaoperacionesperfil.OrderBy(x => x.Nombre).ToList();
                   
                    if (listaoperaciones[i].Nombre == listaoperacionesperfil[j].Nombre)
                    {
                        listaoperaciones.Remove(listaoperaciones[i]);

                    }
                }
            }

            foreach (BE.Permisos.Component item in listaoperaciones)
            {
                listNotAssing.Items.Add(item.Nombre);
            }

            foreach (BE.Permisos.Component item in listaoperacionesperfil)
            {
                listAssing.Items.Add(item.Nombre);
            }

            
           
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                 string ope = listNotAssing.SelectedItem.Value;

                listAssing.Items.Add(ope);


                listNotAssing.Items.Remove(ope);
                
            }
            catch (Exception)
            {

                (this.Master as Menu_operaciones).mostrarmodal("Seleccione un elemento", BE.ControlException.TipoEventoException.Aviso);
            }

        }

        protected void btnDesasignar_Click(object sender, EventArgs e)
        {
            try
            {
                string ope = listAssing.SelectedItem.Value;

                listNotAssing.Items.Add(ope);


                listAssing.Items.Remove(ope);
                 
            }
            catch (Exception)
            {

                (this.Master as Menu_operaciones).mostrarmodal("Seleccione un elemento", BE.ControlException.TipoEventoException.Aviso);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                listaoperacionesperfil.Clear();

                for (int i = 0; i < listAssing.Items.Count; i++)
                {
                    BE.Permisos.Component componente = new BE.Permisos.Component(listAssing.Items[i].Value);
                    listaoperacionesperfil.Add(componente);


                }
                PerfilBE.NombrePerfil = ddlRolList.SelectedItem.Value;
                bool result = familiaBLL.SetFamilyOperations(PerfilBE,listaoperacionesperfil);
                if (result == true)
                {
                    (this.Master as Menu_operaciones).mostrarmodal("Operaciones guardadas con exito", BE.ControlException.TipoEventoException.Info);
                     
                    BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
                    
                    int usuarioid = (int)Session["UsuarioID"];
                    logbll.IngresarDatoBitacora("Asignación de Permisos ", "cambio de permisos en perfil " + PerfilBE.NombrePerfil + "", "Alta", usuarioid);

                    digBLL.RecalcularDigitosunatabla("Bitacora");
                    digBLL.RecalcularDigitosunatabla("PerfilPatente");

                }

            }
            catch (Exception)
            {

                (this.Master as Menu_operaciones).mostrarmodal("Ocurrió un Error", BE.ControlException.TipoEventoException.Error);
            }


        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");
        }
    }
}