namespace Trab_API.Models
{
    public class Producto
    {
        public int ID_Producto{ get; set; }

        public string Nombre { get; set; } = null!;

        private string Descripcion { get; set; } = null!;

        private decimal Precio { get; set; } 
    }
}
