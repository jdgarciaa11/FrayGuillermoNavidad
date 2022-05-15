using BonusTrack08.Models.Entities;

namespace BonusTrack08.Models.ViewModels
{
    public class clsIndexVM
    {
        #region Atributos Privados
        private List<clsCategoria> listadoCategoria;
        #endregion

        #region Propiedades Publicas
        public List<clsCategoria> ListadoCategoria
        {
            get
            {
                listadoCategoria = clsListadoCategorias.listadoCategoriaCompleto();
                return listadoCategoria;
            }
        }
        public List<clsPlanta> ListaPlantaCategoria { get; set; }
        public int IdCategoriaSeleccionada{ get; set; }
        #endregion

        #region Constructores
        public clsIndexVM(){
        }
        public clsIndexVM(int idCategoria)
        {
            ListaPlantaCategoria = clsListadoPlantas.listadoPlantaCategoria(idCategoria);
            IdCategoriaSeleccionada = idCategoria;
        }
        #endregion



    }
}
