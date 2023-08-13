using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PermisosComposite
{
  public abstract  class Component
    {
        string _nombre;
        public Component(string nombre)
        {
            _nombre = nombre;
        }

        public abstract void AgregarHijo(Component c);
        public abstract IList<Component> obtenerhijos();

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public abstract List<BE.Seguridad.Operacion> obtenerpatente { get; }




    }
}
