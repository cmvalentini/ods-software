using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PermisosComposite
{
    public class Leaf : Component
    {
        private List<Component> _hijos = new List<Component>();
   

        public override List<BE.Seguridad.Operacion> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }




        public IList<Component> obtenerhijos(IList<Component> Hijos)
        {
            throw new NotImplementedException();
        }

        public override List<BE.Permisos.Component> obtenerhijos(List<BE.Permisos.Component> listaoperaciones, BE.Usuario usuario)
        {
            throw new NotImplementedException();
        }

        
    }
}
