using BE.Familia;
using BE.Permisos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Permisos
{
    public class FamiliaDal
    {
        DataTable dt = new DataTable();
        Conexion con = Conexion.GetInstance();
        GenericRepository<BE.Familia.Familia> GenericRepository = new GenericRepository<BE.Familia.Familia>();

        public List<Familia> GetFamilias(List<Familia> listafamilias)
        {
            string sql = "select PerfilUsuarioID,NombrePerfil,DescPerfil from PerfilUsuario order by NombrePerfil asc";
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    BE.Familia.Familia familia = new Familia();

                    familia.FamiliaID = Convert.ToInt32(item[0].ToString());
                    familia.NombrePerfil = Convert.ToString(item[1].ToString());
                    familia.DescPerfil = Convert.ToString(item[2].ToString());


                    listafamilias.Add(familia);
                }

            }
            return listafamilias;
        }

        public Familia DeleteFamily(Familia familybe)
        {
            string sql = "delete PerfilUsuario where perfilusuarioid = " + familybe.FamiliaID + ";"+
                "delete PerfilPatente where perfilusuarioid =" + familybe.FamiliaID +"";

            familybe.Result = con.Ejecutar(sql);
            // dv.RecalcularDVH();

            return familybe;


        }

        public bool SetFamilyOperations(BE.Familia.Familia perfilbe,List<Component> listaoperacionesperfil)
        {
            try
            {
                string primersql = "delete PerfilPatente where PerfilUsuarioID = "+
              "(select PerfilUsuarioID from PerfilUsuario where NombrePerfil = '"+ perfilbe.NombrePerfil +"' );";
                con.Ejecutar(primersql);
                con.Desconectar();

                con.Conectar();
                int FamiliaID = 500;
                string segundosql = "select PerfilUsuarioID from PerfilUsuario where NombrePerfil = '"+perfilbe.NombrePerfil+"' ";
                dt = con.Ejecutarreader(segundosql);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                     
                        FamiliaID = Convert.ToInt32(item[0].ToString());
                    }

                }   


                string sql;
                foreach (BE.Permisos.Component item in listaoperacionesperfil)
                {

                    sql = "INSERT INTO PerfilPatente (PatenteID,PerfilUsuarioID)" +
                          " select PatenteID," + FamiliaID +" as perfilid from Patente where Descripcion = '" + item.Nombre + "'";
                           
                    con.Ejecutar(sql);

                }


                con.Desconectar();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public Familia ModifyFamily(Familia familybe)
        {
            string sql = "update PerfilUsuario set NombrePerfil = '"+familybe.NombrePerfil+"', DescPerfil= "+
                "'"+familybe.DescPerfil+ "' where PerfilUsuarioID =" +familybe.FamiliaID +";";
            familybe.Result = con.Ejecutar(sql);
            // dv.RecalcularDVH();

            return familybe;
        }

        public Familia CreateFamily(Familia familybe)
        {
            string sql = "insert into PerfilUsuario(NombrePerfil,DescPerfil) values('"+familybe.NombrePerfil+"',"+
            "'" + familybe.DescPerfil + "')";

            familybe.Result = con.Ejecutar(sql);
            // dv.RecalcularDVH();


            return familybe;
        }

        public Familia GetbyID(Familia familybe)
        {
            string columna = "NombrePerfil,DescPerfil";
            string tabla = "PerfilUsuario pu";
            string condicion = "pu.PerfilUsuarioID in (" + familybe.FamiliaID + ")";
            dt = GenericRepository.GetAllbyID(columna, tabla, condicion);


            foreach (DataRow item in dt.Rows)
            {
                familybe.NombrePerfil = item[0].ToString();
                familybe.DescPerfil = item[1].ToString(); 
            }

            return familybe;
        }
    }
}
