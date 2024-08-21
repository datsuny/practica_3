namespace API.Entitites
{
    public class Producto
    {
        public int CodigoCompra { get; set; }
        public string? Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }

    }
}
