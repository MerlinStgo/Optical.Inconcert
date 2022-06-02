using Microsoft.AspNetCore.Mvc;
using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Application.Wrapper;
using Optical.Inconcert.Core.Models;

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

        [HttpGet(Name = "GetDeudaWin")]
        public async Task<IActionResult> GetDeudaWin(string? codigoCliente, string? documentoCliente)
        {
            var response = new ResponseBase<IEnumerable<Deuda>>();
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
