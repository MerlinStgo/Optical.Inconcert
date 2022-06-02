using Optical.Inconcert.Application.Interfaces;

namespace Optical.Inconcert.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDeudaApplication Deudas { get; }

        public UnitOfWork(IDeudaApplication deudaApplication)
        {
            Deudas = deudaApplication;
        }
    }
}