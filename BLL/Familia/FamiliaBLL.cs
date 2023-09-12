using BE.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Familia
{
    public class FamiliaBLL
    {
        DAL.Permisos.FamiliaDal familiaDal = new DAL.Permisos.FamiliaDal();
         bool result;
        public List<BE.Familia.Familia> GetFamilias(List<BE.Familia.Familia> listafamilias)
        {

            listafamilias = familiaDal.GetFamilias(listafamilias);

            return listafamilias;
        
        }

        public BE.Familia.Familia GetbyID(BE.Familia.Familia familybe)
        {
            familybe = familiaDal.GetbyID(familybe);
            return familybe;
        }

        public BE.Familia.Familia CreateFamily(BE.Familia.Familia familybe)
        {
            familybe = familiaDal.CreateFamily(familybe);
            return familybe;
        }

        public BE.Familia.Familia ModifyFamily(BE.Familia.Familia familybe)
        {
            familybe = familiaDal.ModifyFamily(familybe);
            return familybe;

        }

        public BE.Familia.Familia DeleteFamily(BE.Familia.Familia familybe)
        {
            familybe = familiaDal.DeleteFamily(familybe);
            return familybe;


        }

        public bool SetFamilyOperations(BE.Familia.Familia perfilbe, List<Component> listaoperacionesperfil)
        {
            result = familiaDal.SetFamilyOperations(perfilbe, listaoperacionesperfil);
            return result;

        }
    }
}
