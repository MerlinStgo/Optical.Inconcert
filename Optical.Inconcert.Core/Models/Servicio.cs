namespace Optical.Inconcert.Core.Models
{
    public class Servicio
    {
        public decimal IdServicio { get; set; }
        public string? CodAbonado { get; set; }
        public string? DocCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? EstadoCliente { get; set; }
        public string? EstadoServicio { get; set; }
        public DateTime? FecIniContrato { get; set; }
    }
}
