using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PermisosComposite
{
   public  class Composite : Component
    {
        DAL.Permisos.ManejadorPerfilUsuariosDAL mpudal = new DAL.Permisos.ManejadorPerfilUsuariosDAL();
        public override List<BE.Seguridad.Operacion> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public override List<BE.Permisos.Component> obtenerhijos(List<BE.Permisos.Component> hijos,BE.Usuario usuario)
        {
            hijos = mpudal.obtenerhijos(hijos, usuario);
            return hijos;
        }

    }
}
