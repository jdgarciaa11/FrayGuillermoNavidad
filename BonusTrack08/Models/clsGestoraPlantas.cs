using BonusTrack08.Models.Conection;
using BonusTrack08.Models.Entities;
using System.Data.SqlClient;

namespace BonusTrack08.Models
{
    public class clsGestoraPlantas
    {
        private static clsMiConexion miConexion = new clsMiConexion();
        /// <summary>
        /// <head>public static int editarPlanta(clsPlanta oPlanta)</head>
        /// <descripcion>funcion que </descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>List<clsPlanta></returns>
        public static int editarPlanta(clsPlanta oPlanta)
        {
            int columnasAfectadas = 0;
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", oPlanta.id);
            comando.Parameters.AddWithValue("@precio", oPlanta.precio);
            comando.CommandText = "UPDATE plantas SET precio = @precio Where IdPlanta = @id";
            try
            {
                miConexion.getConnection();
                comando.Connection = miConexion.connection;
                columnasAfectadas = comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally 
            {
                miConexion.closeConnection(ref miConexion.connection);
            }
            return columnasAfectadas;
        }
    }
}
