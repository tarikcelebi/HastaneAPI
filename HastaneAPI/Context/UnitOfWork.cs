using HastaneAPI.Context.IConfiguration;
using HastaneAPI.Context.Repositories.Abstract;
using HastaneAPI.Context.Repositories.Concrete;

namespace HastaneAPI.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext dbContext;
        private ILogger logger;

        public IHospitalRepository Hospitals { get; private set; }

        public UnitOfWork(AppDbContext dbContext, ILoggerFactory loggerFactory)
        {
            this.dbContext = dbContext;
            this.logger = loggerFactory.CreateLogger("ApplicationLogs");
            Hospitals = new HospitalRepository(dbContext, logger);

            
        }

        public async Task ComplateAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
