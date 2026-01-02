namespace ContaAyto
{
    // Esta clase representa un movimiento bancario o contable
    public class Apunte
    {
        public int Id { get; set; }
        public string Concepto { get; set; } = string.Empty; // Inicializamos vacío para evitar nulos
        public decimal Importe { get; set; } // Positivo es ingreso, negativo es gasto
        public DateTime Fecha { get; set; }

        // Constructor para facilitar la creación
        public Apunte(int id, string concepto, decimal importe)
        {
            Id = id;
            Concepto = concepto;
            Importe = importe;
            Fecha = DateTime.Now;
        }
    }
}