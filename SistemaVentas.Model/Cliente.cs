namespace SistemaVentas.Model
{
    public class Cliente : BaseModelDeleted
    {
        public int pkCliente { get; set; }
        public string cNombre { get; set; }
    }
}
