namespace SistemaVentas.Model
{
    using System.Collections.Generic;

    public class Modelo
    {
        public int pkModelo { get; set; }
        public string cModelo { get; set; }
        public int fkMarca { get; set; }
        public Marca Marca { get; set; }
    }
}
