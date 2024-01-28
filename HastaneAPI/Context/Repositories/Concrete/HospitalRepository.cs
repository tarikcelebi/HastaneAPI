using HastaneAPI.Context.Repositories.Abstract;
using HastaneAPI.Entities;

namespace HastaneAPI.Context.Repositories.Concrete
{
    public class HospitalRepository : GenericRepository<Hospital>, IHospitalRepository
    {
        public AppDbContext dbContext;
        public ILogger logger;

        public HospitalRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public override async Task<IEnumerable<Hospital>> GetAll()
        {
            try
            {
                return dbset.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Hospital Repo GetAll Method error",typeof(HospitalRepository));
                return new List<Hospital>();
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                Hospital hospital = dbset.Where(x => x.ID == id).FirstOrDefault();

                if (hospital == null)
                    return false;


                dbset.Remove(hospital);
                return true;
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Hospital Repo GetAll Method error", typeof(HospitalRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Hospital entity)
        {
            try
            {
                Hospital existingHospital = dbset.Where(x => x.ID == entity.ID).FirstOrDefault();

                if (existingHospital == null)
                 return await Add(entity); 
             
                    existingHospital.HospitalName = entity.HospitalName;
                    existingHospital.Address = entity.Address;
                    existingHospital.Hastalar = entity.Hastalar;
                    return true;
                
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "Hospital Repo GetAll Method error", typeof(HospitalRepository));
                return false;
            }
        }


    }
}
