namespace Optical.Inconcert.Application.DTOs
{
    public class DeudaDto
    {
        public Cliente? Cliente { get; set; }
        public List<Servicio>? Servicios { get; set; }
    }


    public class Servicio
    {
        public string? Estado { get; set; }
        public decimal IdServicio { get; set; }
        public DateTime? FechaInicioContrato { get; set; }
        public List<Comprobante>? Comprobantes { get; set; }
    }

    public class Cliente
    {
        public string? Documento { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }
        public string? CodigoAbonado { get; set; }
    }

    public class Comprobante
    {
        public string? NumeroRecibo { get; set; }
        public decimal? Importe { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
