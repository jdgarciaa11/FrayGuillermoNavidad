namespace BonusTrack08.Models.Entities
{
    public class clsCategoria
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public clsCategoria(int id , string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public clsCategoria()
        {
        }
    }
}
