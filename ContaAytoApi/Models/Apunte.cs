namespace ContaAytoApi
{
    public class Apunte
    {
        public int Id { get; set; }
        public string Concepto { get; set; } = string.Empty;
        public decimal Importe { get; set; }
        public DateTime Fecha { get; set; }

        // Un constructor vacío a veces es necesario para la serialización automática
        public Apunte() { }
    }
}