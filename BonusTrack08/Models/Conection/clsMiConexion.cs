using System.Data.SqlClient;

namespace BonusTrack08.Models.Conection
{
    public class clsMiConexion
    {
        //Atributos
        public String server { get; set; }
        public String dataBase { get; set; }
        public String user { get; set; }
        public String pass { get; set; }
        public SqlConnection connection = new SqlConnection();

        //Constructores
        public clsMiConexion()
        {

            this.server = "jesusd.database.windows.net";
            this.dataBase = "jesusd";
            this.user = "administrador";
            this.pass = "#Mitesoro";

        }
        //Con parámetros por si quisiera cambiar las conexiones
        public clsMiConexion(String server, String database, String user, String pass)
        {
            this.server = server;
            this.dataBase = database;
            this.user = user;
            this.pass = pass;
        }
        //METODOS

        /// <summary>
        /// Método que abre una conexión con la base de datos
        /// </summary>
        /// <pre>Nada.</pre>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public SqlConnection getConnection()
        {

            try
            {
                this.connection.ConnectionString = $"server={server};database={dataBase};uid={user};pwd={pass};";
                this.connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }




        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar
        /// </param>
        public void closeConnection(ref SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
