namespace SistemaVentas.Model
{
    public class Producto : BaseModelDeleted
    {
        public int pkProducto { get; set; }
        public string cProducto { get; set; }
        public int fkModelo { get; set; }
        public Modelo Modelo { get; set; }

    }
}
