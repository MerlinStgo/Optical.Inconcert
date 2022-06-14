using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Core.Models;

namespace Optical.Inconcert.Application.Interfaces
{
    public interface IDeudaRepository
    {
        Task<Deuda> GetDeudas(ParamDeuda param);
    }
}
