namespace BonusTrack08.Models.Entities
{
    public class clsPlanta
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String detalles { get; set; }
        public int idCategoria { get; set; }
        public Double precio { get; set; }

        public clsPlanta(int id, string nombre, string detalles, int idCategoria, double precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.detalles = detalles;
            this.idCategoria = idCategoria;
            this.precio = precio;
        }

        public clsPlanta()
        {
        }
    }
}
