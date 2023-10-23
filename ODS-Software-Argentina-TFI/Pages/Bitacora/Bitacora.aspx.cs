using ODS_Software_Argentina_TFI.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Bitacora
{
    public partial class Bitacora : System.Web.UI.Page
    {
        List<BE.Seguridad.BitacoraBE> listabitacora = new List<BE.Seguridad.BitacoraBE>();
        BLL.Seguridad.BitacoraBLL bitacoraBLL = new BLL.Seguridad.BitacoraBLL();
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
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
        }

   

        private void cargar_data(int v1, int v2)
        {
            try
            {


                string fechadesde =  CalendarC.GetFechaDesde();
                string fechahasta =  CalendarC.GetFechaHasta();
                string criticidad = CalendarC.GetCriticidad();
                string usuario = CalendarC.GetUsuario();
                string sqlusuario = "";
                string sqlcriticidad = "";

                switch (usuario)
                {
                    case "":
                        
                        break;
                    case "Todos":
                        sqlusuario = "select usuarioid from usuario";
                        break;
                    default:
                        sqlusuario = "select usuarioid from usuario where usuario like '" + usuario + "'";
                        break;
                }

                switch (criticidad)
                {
                    case "":
                     
                        break;
                    case "Todas":
                        sqlcriticidad = "select distinct criticidad from bitacora";
                        break;
                    default:
                        sqlcriticidad = "select criticidad from bitacora where criticidad = '"+criticidad+"'";
                        break;
                }
                
                //llenamos la bitacora con todo lo filtrado
                listabitacora = bitacoraBLL.ConsultarBitacora(fechadesde, fechahasta, sqlcriticidad, sqlusuario);

                dvgBitacora.DataSource = listabitacora;
                dvgBitacora.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
          
           
        }

        private int Count()
        {
            return 3;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dvgBitacora.PageIndex = e.NewPageIndex;
            cargar_data(1, 2);
        }

        protected void ConsultarBitacora_click(object sender, EventArgs e)
        {
            cargar_data(1,3);
            btnExport.Visible = true;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string Sortdir = GetSortDirection(e.SortExpression);
            string SortExp = e.SortExpression;
            BLL.Seguridad.BitacoraBLL bit = new BLL.Seguridad.BitacoraBLL();
            var list = bit.ListarBitacora();
            if (Sortdir == "ASC")
            {
                list = Sort<Bitacora>(list, SortExp, SortDirection.Ascending);
            }
            else
            {
                list = Sort<Bitacora>(list, SortExp, SortDirection.Descending);
            }
            dvgBitacora.DataSource = list;
            dvgBitacora.DataBind();

        }

        public List<BE.Seguridad.BitacoraBE> Sort<TKey>(List<BE.Seguridad.BitacoraBE> list, string sortBy, SortDirection direction)
        {
            PropertyInfo property = list.GetType().GetGenericArguments()[0].GetProperty(sortBy);
            if (direction == SortDirection.Ascending)
            {
                return list.OrderBy(e => property.GetValue(e, null)).ToList();
            }
            else
            {
                return list.OrderByDescending(e => property.GetValue(e, null)).ToList();
            }
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;
            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Pages/MenuPrincipal.aspx");
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            #region exportarxml
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            //recorre el header de la tabla
            foreach (TableCell column in dvgBitacora.HeaderRow.Cells)
            {
                dt.Columns.Add(column.Text);
            }

            //recorre las filas de la tabla
            foreach (GridViewRow row in dvgBitacora.Rows)
            {
                dt.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dt.Rows[row.RowIndex][i] = row.Cells[i].Text;
                }
            }

            //guardamos la tabla
            ds.Tables.Add(dt);
            // Specify the file path for the XML file
            string filePath = Server.MapPath("~/GridBitacora.xml");

            // Write the DataSet to an XML file
            ds.WriteXml(filePath);

            // Provide a download link for the generated XML file
            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=GridBitacora.xml");
            Response.TransmitFile(filePath);
            Response.End();
            #endregion
        }

        protected void btnexportxls_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/ms-excel";
                Response.AddHeader("content-disposition", "attachment; filename=Bitacora.xls");
                Response.Charset = "";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                dvgBitacora.RenderControl(htw);
                Response.Output.Write(sw.ToString());
                Response.End();
            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);

                throw;
            }
        
        }
    }
}