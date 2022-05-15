using BonusTrack08.Models.Entities;
using System.Data.SqlClient;

namespace BonusTrack08.Models
{
    public class clsListadoPlantas
    {
        private static Conection.clsMiConexion myConection = new Conection.clsMiConexion();
        /// <summary>
        /// <head>public static List<clsPlanta> listadoPlantaCompleto</head>
        /// <descripcion>funcion que devuelve un listado completo de plantas</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>List<clsPlanta></returns>
        public static List<clsPlanta> listadoPlantaCompleto()
        {
            List<clsPlanta> lista = new List<clsPlanta>();
            SqlCommand myCommand = new SqlCommand("SELECT * FROM plantas");
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
                        lista.Add(constructorPlanta(myReader));
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
        /// <head>public static List<clsPlanta> listadoPlantaCategoria()</head>
        /// <descripcion>funcion que devuelve un listado porCategoria de plantas</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>List<clsPlanta></returns>
        public static List<clsPlanta> listadoPlantaCategoria(int idCategoria)
        {
            List<clsPlanta> lista = new List<clsPlanta>();
            foreach (clsPlanta planta in listadoPlantaCompleto()) 
            {
                if (planta.idCategoria == idCategoria) 
                { 
                    lista.Add((clsPlanta)planta);
                }
            }
            return lista;
        }

        public static clsPlanta getPlanta(int idPlanta)
        {
            SqlCommand myCommand = new SqlCommand();
            myCommand.Parameters.AddWithValue("@idPlanta", idPlanta);
            myCommand.CommandText = "SELECT * FROM plantas WHERE IdPlanta = @idPlanta";

            SqlDataReader myReader;

            clsPlanta oPlanta = null;

            try
            {
                //Comando de mi clsMiConexion para abrir la conexion
                myConection.getConnection();
                //Asociar/existir la conexion que he abierto a la conexion q voy a abrir
                myCommand.Connection = myConection.connection;

                myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    myReader.Read();
                    oPlanta = constructorPlanta(myReader);
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
            return oPlanta;

        }

        /// <summary>
        /// <head> public static clsPlanta constructorPlanta(SqlDataReader miLector)</head>
        /// <descripcion>funcion que construye una planta a partir de lo que lee del sql</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>clsPlanta</returns>
        public static clsPlanta constructorPlanta(SqlDataReader miLector)
        {
            clsPlanta oPlanta = new clsPlanta();

            oPlanta.id = (int)miLector["idPlanta"];
            oPlanta.nombre = (string)miLector["nombrePlanta"];
            oPlanta.detalles = (string)miLector["descripcion"];
            oPlanta.idCategoria = (int)miLector["idCategoria"];
            //Si sospechamos que el campo puede ser Null en la BBDD
            if (miLector["precio"] != System.DBNull.Value)
            {
                oPlanta.precio = (double)miLector["precio"];
            }
            return oPlanta;
        }
    }
}
