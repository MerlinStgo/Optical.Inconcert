using Optical.Inconcert.Application.Params;
using Optical.Inconcert.Application.Wrapper;
using Optical.Inconcert.Core.Models;

namespace Optical.Inconcert.Application.Interfaces
{
    public interface IDeudaApplication
    {
        Task<IEnumerable<Deuda>> GetDeuda(ParamDeuda param);
    }
}
