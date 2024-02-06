using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext appDbContext;

        public PatientRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            var result = await appDbContext.Patients.AddAsync(patient);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeletePatient(long id)
        {
            var result = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                appDbContext.Patients.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Patient?> GetPatient(long id)
        {
            return await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var result = await appDbContext.Patients.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<Patient>> Search(string name)
        {
            IQueryable<Patient> query = appDbContext.Patients;

            if (!string.IsNullOrEmpty(name))
            {
                query.Where(p => p.FirstName.Contains(name) || p.LastName.Contains(name));
            }

            return await query.ToListAsync();
        }

        public async Task<Patient?> UpdatePatient(long id, Patient patient)
        {
            var result = await appDbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                result.FirstName = patient.FirstName;
                result.LastName = patient.LastName;
                result.Address = patient.Address;
                result.City = patient.City;
                result.OrganizationId = patient.OrganizationId;
                result.State = patient.State;
                result.IsDeleted = patient.IsDeleted;
                result.UpdatedAt = DateTime.Now;
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;

        }
    }
}


