using Microsoft.AspNetCore.Mvc;
using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Application.Wrapper;
using Optical.Inconcert.Core.Models;
using Optical.Inconcert.Application.DTOs;

namespace Optical.Inconcert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeudasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeudasController> _logger;

        public DeudasController(IUnitOfWork unitOfWork, ILogger<DeudasController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        /// <summary>
        /// Lista deudas por servicio de un cliente
        /// </summary>
        /// <param name="codigoCliente"></param>
        /// <param name="documentoCliente"></param>
        /// <returns></returns>
        [HttpGet(Name = "GetDeudaWin")]
        [Produces("application/json", Type = typeof(ResponseBase<DeudaDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDeudaWin(string? codigoCliente, string? documentoCliente)
        {
            var response = new ResponseBase<DeudaDto>();
            try
            {
                response.Success = true;
                response.Data = await _unitOfWork.Deudas.GetDeuda(new ParamDeuda()
                {
                    IdEmpresa = (int)EEmpresa.WIN,
                    CodigoCliente = codigoCliente,
                    DocumentoCliente = documentoCliente
                });
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
                _logger.LogError(e, e.Message);
            }
            return Ok(response);
        }
    }
}
