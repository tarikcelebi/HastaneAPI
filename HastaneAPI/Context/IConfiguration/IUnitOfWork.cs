using HastaneAPI.Context.Repositories.Abstract;

namespace HastaneAPI.Context.IConfiguration
{
    public interface IUnitOfWork
    {
        IHospitalRepository Hospitals { get; }

        Task ComplateAsync();

    }
}
