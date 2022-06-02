using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Application.Wrapper;
using Optical.Inconcert.Core.Models;

namespace Optical.Inconcert.Application
{
    public class DeudaApplication : IDeudaApplication
    {
        private readonly IDeudaRepository _repository;

        public DeudaApplication(IDeudaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Deuda>> GetDeuda(ParamDeuda param)
        {
            var deudas = await _repository.GetDeudas(param);
            return deudas;
        }
    }
}
