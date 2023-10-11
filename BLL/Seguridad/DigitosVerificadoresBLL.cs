using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Seguridad
{
    public class DigitosVerificadoresBLL
    {
        DAL.Seguridad.DigitosDAL digDAL = new DAL.Seguridad.DigitosDAL();
        BLL.Seguridad.EncriptacionBLL Encriptacion = new EncriptacionBLL();

        private readonly List<string> tablas = new List<string>()
        {
            "Usuario"
            ,"Bitacora"
            ,"Cliente"
            ,"Idioma"
            ,"Patente"
            ,"PerfilPatente"
            ,"PerfilUsuario"
            ,"usuariopatente"
            ,"Pedido"

        };

        //Este metodo es sumamente pesado, usar solo luego de operaciones transaccionales
        public List<Tuple<string, string>> ValidarIntegridadSistema()
        {
            try
            {
                List<Tuple<string, string>> listaErrores = new List<Tuple<string, string>>();

                foreach (string tabla in tablas)
                {
                    List<string> hashes = new List<string>();
                    //Evaluo primero los dvh, y finalmente el dvv
                    DataTable dtabla = digDAL.ObtenerTabla(tabla);

                    //Si la tabla tiene registros, tiene sentido el dvh y dvv, de lo contrario no calculo
                    if (dtabla != null)
                    {
                        foreach (DataRow fila in dtabla.Rows)
                        {
                            if (!EvaluarRegistro(fila)) 
                            {
                                //Reporto fila que da error
                                Tuple<string, string> tupla = new Tuple<string, string>(tabla, "ALERTA-> El ID " + fila.ItemArray[0] + " de la tabla " + tabla + " ha sido corrompido.");
                                listaErrores.Add(tupla);
                            }
                            //Sumo el dvh que ya tengo para poder calcular el dvv a futuro.
                            //si bien puede haber un error antes, puedo detectar archivos que se agregaron o borraron
                            string dvh = fila.ItemArray[fila.ItemArray.Length - 1].ToString();
                            hashes.Add(dvh);
                        }

                        //busco el dvv actual
                        string dvvAct = digDAL.ObtenerDVV(tabla);

                        //Evaluo dvv respectivo
                        string dvvRecalc = CalcularDVV(hashes);

                        if (!dvvAct.Equals(dvvRecalc))
                        {
                            //Reporto tabla que da error
                            Tuple<string, string> tupla = new Tuple<string, string>(tabla, "Se agrego/eliminó un registro de la tabla " + tabla + " por fuera del sistema.");
                            listaErrores.Add(tupla);
                        }
                    }
                }

                return listaErrores;
            }
            catch (Exception)
            {
                return null;
            }

        }

        //Este metodo es sumamente pesado y riegoso
        public bool RecalcularDigitos()
        {
            try
            {
                foreach (string tabla in tablas)
                {
                    List<string> hashes = new List<string>();

                    DataTable dtabla = digDAL.ObtenerTabla(tabla);

                    //Si la tabla tiene registros, tiene sentido el dvh y dvv, de lo contrario no calculo
                    if (dtabla != null)
                    {
                        foreach (DataRow fila in dtabla.Rows)
                        {
                            string hash = CalcularDVH(fila);
                            ActualizarDVH(tabla, int.Parse(fila.ItemArray[0].ToString()), hash);
                            hashes.Add(hash);
                        }

                        //Evaluo dvv respectivo
                        string dvv = CalcularDVV(hashes);

                        ActualizarDVV(tabla, dvv);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ActualizarDigitos(string tabla, int id = -99)
        {
            //Veo que la tabla existe
            if (tablas.Any(x => x.Equals(tabla)))
            {
                //Si id = -99, es muestra de que se borro un registro, por lo que buscarlo y actualizar dvh no sirve
                //Aca solo actualizo DVV
                if (id != -99)
                {
                    //Busco el registro completo en la tabla que se genero
                    DataRow reg = digDAL.BuscarRegistro(tabla, id);
                    if (id == 2356)
                    {
                        DataRow entra = reg;
                    }
                    if (reg != null)
                    {
                        string hash = CalcularDVH(reg);
                        ActualizarDVH(tabla, id, hash);
                        //Ya registre en su momento, ahora actualice el DVH
                        //Ahora actualizo el DVV
                        DataTable tabladata = digDAL.ObtenerTabla(tabla);
                        List<string> hashes = tabladata.AsEnumerable().Select(fila => fila.ItemArray[fila.ItemArray.Length - 1].ToString()).ToList();
                        string dvvNew = CalcularDVV(hashes);
                        ActualizarDVV(tabla, dvvNew);
                    }
                    else
                    {
                        //registro no existe
                    }
                }
                else
                {
                    //Ahora actualizo el DVV
                    DataTable tabladata = digDAL.ObtenerTabla(tabla);
                    List<string> hashes = tabladata.AsEnumerable().Select(fila => fila.ItemArray[fila.ItemArray.Length - 1].ToString()).ToList();
                    string dvvNew = CalcularDVV(hashes);
                    ActualizarDVV(tabla, dvvNew);
                }

            }
            else
            {
                //tabla no existe
            }
        }

        private void ActualizarDVV(string tabla, string dvv)
        {
            digDAL.ActualizarDVV(tabla, dvv);
        }

        private void ActualizarDVH(string tabla, int id, string hash)
        {
            digDAL.ActualizarDVH(tabla, id, hash);
        }

        private bool EvaluarRegistro(DataRow row)
        {
            //Concateno cada valor de la fila, incluso nulos como texto vacio
            string dvhOrig = row.ItemArray.Last().ToString();
            string dvhRecalc = CalcularDVH(row);

            //comparo los dvhs
            if (dvhRecalc.Equals(dvhOrig))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string CalcularDVH(DataRow row) //cambiar a string una vez que no hashee
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < row.ItemArray.Count() - 1; i++)
            {
                if (row.ItemArray[i] is byte[])
                {
                    //Si el tipo de dato es byte[], lo paso a texto base64
                    sb.Append(row.ItemArray[i] != null ? Convert.ToBase64String(row.ItemArray[i] as byte[]) : "");
                }
                else
                {
                    //Campo normal
                    sb.Append(row.ItemArray[i] != null ? row.ItemArray[i].ToString() : "");
                }
            }

            //obtengo el string
            string st = sb.ToString();

            //hasheo el string
            string hash = Encriptacion.Encriptar(st);

            return hash;
        }

        private string CalcularDVV(List<string> hashes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string hash in hashes)
            {
                sb.Append(hash);
            }

            string dvv = Encriptacion.cryptshort(sb.ToString());

            return dvv;
        }


        public bool RecalcularDigitosunatabla(string tabla)
        {
            try
            {
                    List<string> hashes = new List<string>();
                    DataTable dtabla = digDAL.ObtenerTabla(tabla);
                   //Si la tabla tiene registros, tiene sentido el dvh y dvv, de lo contrario no calculo
                    if (dtabla != null)
                    {
                        foreach (DataRow fila in dtabla.Rows)
                        {
                            string hash = CalcularDVH(fila);
                            ActualizarDVH(tabla, int.Parse(fila.ItemArray[0].ToString()), hash);
                            hashes.Add(hash);
                        }

                        string dvv = CalcularDVV(hashes);

                        ActualizarDVV(tabla, dvv);
                    }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
