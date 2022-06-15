using Dapper;
using Microsoft.Extensions.Configuration;
using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Core.Models;
using System.Data;

namespace Optical.Inconcert.Infrastructure.Repositories
{
    public class DeudaRepository : IDeudaRepository
    {
        private readonly ConnectionFactory _connectionFactory;

        public DeudaRepository(IConfiguration configuration)
        {
            _connectionFactory = new ConnectionFactory(configuration);
        }

        public async Task<Deuda> GetDeudas(ParamDeuda param)
        {
            var sql = "INCONCERT.LISTAR_SERVICIO_RECIBOS_POR_CLIENTE";

            var p = new DynamicParameters();
            p.Add("@PEI_ID_EMPRESA", param.IdEmpresa, DbType.Int32);
            p.Add("@PEV_COD_CLIENTE", param.CodigoCliente, DbType.String);
            p.Add("@PEV_NRO_DOCUMENTO", param.DocumentoCliente, DbType.String);

            using (var cn = _connectionFactory.GetConnectionECOM)
            {
                await cn.OpenAsync();
                var result = await cn.QueryMultipleAsync(sql, p, commandType: CommandType.StoredProcedure);
                
                var lsServicios = result.Read<Servicio>().ToList();
                var lsRecibos = result.Read<Recibo>().ToList();

                return new Deuda()
                {
                    Servicios = lsServicios,
                    Recibos = lsRecibos
                };
            }
        }
    }
}
