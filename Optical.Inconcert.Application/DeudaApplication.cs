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
            if (deudas != null)
            {
                var datosCliente = deudas.Servicios?.FirstOrDefault();

                if (datosCliente != null)
                {
                    response.Cliente = new Cliente()
                    {
                        CodigoAbonado = datosCliente.CodAbonado,
                        Documento = datosCliente.DocCliente,
                        Estado = datosCliente.EstadoCliente,
                        Nombre = datosCliente.NombreCliente
                    };

                    var lsIdServicios = deudas.Servicios.Select(o => o.IdServicio).Distinct();

                    var lsComprobante = new List<Comprobante>();
                    response.Servicios = new List<Servicio>();

                    foreach (var id in lsIdServicios)
                    {
                        var servicio = deudas.Servicios.First(x => x.IdServicio == id);
                        var lsRecibos = deudas.Recibos?.Where(x => x.IdServicio == servicio.IdServicio);

                        if(lsRecibos != null && lsRecibos.Any())
                        {
                            foreach (var item in lsRecibos)
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
                                IdServicio = servicio.IdServicio,
                                Comprobantes = lsComprobante
                            });

                            lsComprobante = new List<Comprobante>();
                        }
                        else
                        {
                            response.Servicios.Add(new Servicio
                            {
                                Estado = servicio.EstadoServicio,
                                FechaInicioContrato = servicio.FecIniContrato,
                                IdServicio = servicio.IdServicio,
                                Comprobantes = new List<Comprobante>()
                            }) ;
                        }
                    }
                }
            }
            return response;
        }
    }
}