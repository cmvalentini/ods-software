using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PermisosComposite
{
  public abstract  class Component
    {
        
        public abstract List<BE.Permisos.Component> obtenerhijos(List<BE.Permisos.Component> listaoperaciones,BE.Usuario usuario);

        public abstract List<BE.Seguridad.Operacion> obtenerpatente { get; }

    }
}
