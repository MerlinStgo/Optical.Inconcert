using Optical.Inconcert.Application.Params;

namespace Optical.Inconcert.Application.Interfaces
{
    public interface IDeudaApplication
    {
        Task<DTOs.DeudaDto> GetDeuda(ParamDeuda param);
    }
}
