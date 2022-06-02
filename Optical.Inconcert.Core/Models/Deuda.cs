namespace Optical.Inconcert.Core.Models
{
    public class Deuda
    {
        public string? NumRecibo { get; set; }
        public decimal MontoDeuda { get; set; }
        public string? CodAbonado { get; set; }
        public DateTime FecVencimiento { get; set; }
        public DateTime FecEmision { get; set; }
        public string? DocCliente { get; set; }
        public string? NombreCliente { get; set; }
    }
}
