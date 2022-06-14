namespace Optical.Inconcert.Core.Models
{
    public class Recibo
    {
        public string? NumRecibo { get; set; }
        public decimal MontoDeuda { get; set; }
        public DateTime FecVencimiento { get; set; }
        public DateTime FecEmision { get; set; }
        public decimal IdServicio { get; set; }
    }
}
