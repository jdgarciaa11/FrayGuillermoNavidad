using BonusTrack08.Models.Entities;
using System.Data.SqlClient;

namespace BonusTrack08.Models
{
    public class clsListadoCategorias
    {
        private static Conection.clsMiConexion myConection = new Conection.clsMiConexion();
        /// <summary>
        /// <head>public static List<clsCategoria> listadoCategoriCompleto()</head>
        /// <descripcion>funcion que devuelve un listado completo de plantas</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>List<clsPlanta></returns>
        public static List<clsCategoria> listadoCategoriaCompleto()
        {
            List<clsCategoria> lista = new List<clsCategoria>();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM categorias");
            SqlDataReader myReader;
            try
            {
                //Comando de mi clsMiConexion para abrir la conexion
                myConection.getConnection();
                //Asociar/existir la conexion que he abierto a la conexion q voy a abrir
                myCommand.Connection = myConection.connection;

                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        lista.Add(constructorCategoria(myReader));
                    }

                }
                myReader.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }
            finally 
            {
                myConection.closeConnection(ref myConection.connection);
            }
            return lista;
        }

        /// <summary>
        /// <head> public static clsCategoria constructorCategoria(SqlDataReader miLector)</head>
        /// <descripcion>funcion que construye una planta a partir de lo que lee del sql</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>clsCategoria</returns>
        public static clsCategoria constructorCategoria(SqlDataReader miLector)
        {
            clsCategoria oCategoria = new clsCategoria();
            oCategoria.id = (int)miLector["idCategoria"];
            oCategoria.nombre = (string)miLector["nombreCategoria"];
            return oCategoria;
        }
    }
}
