using System;
using System.Collections.Generic;
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
                cargar_data(1, 5);

            }
        }

   

        private void cargar_data(int v1, int v2)
        {
            dvgBitacora = new GridView();
            listabitacora = bitacoraBLL.ListarBitacora();
            dvgBitacora.DataSource = listabitacora;
            dvgBitacora.DataBind();
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
            dvgBitacora.DataSource = bitacoraBLL.ListarBitacora();
            dvgBitacora.DataBind();
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
       
    }
}