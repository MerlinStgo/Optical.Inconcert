using Optical.Inconcert.Application.DTOs;
using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Application.Params;

namespace Optical.Inconcert.Application
{
    public class DeudaApplication : IDeudaApplication
    {
        private readonly IDeudaRepository _repository;

        public DeudaApplication(IDeudaRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeudaDto> GetDeuda(ParamDeuda param)
        {
            var response = new DeudaDto();

            var deudas = await _repository.GetDeudas(param);
            if (deudas.Any())
            {
                var cliente = deudas.First();
                response.Cliente = new Cliente()
                {
                    CodigoAbonado = cliente.CodAbonado,
                    Documento = cliente.DocCliente,
                    Estado = cliente.EstadoCliente,
                    Nombre = cliente.NombreCliente
                };

                var lsIdServicios = deudas.Select(o => o.IdContrato).Distinct();

                var lsComprobante = new List<Comprobante>();
                response.Servicios = new List<Servicio>();

                foreach (var id in lsIdServicios)
                {
                    var servicio = deudas.First(x => x.IdContrato == id);
                    var comprobantesServicio = deudas.Where(x => x.IdContrato == servicio.IdContrato);

                    foreach (var item in comprobantesServicio)
                    {
                        lsComprobante.Add(new Comprobante()
                        {
                            FechaEmision = item.FecEmision,
                            FechaVencimiento = item.FecVencimiento,
                            Importe = item.MontoDeuda,
                            NumeroRecibo = item.NumRecibo
                        });
                    }

                    response.Servicios.Add(new Servicio
                    {
                        Estado = servicio.EstadoServicio,
                        FechaInicioContrato = servicio.FecIniContrato,
                        IdServicio = servicio.IdContrato,
                        Comprobantes = lsComprobante
                    });
                }

            }

            return response;
        }
    }
}
;