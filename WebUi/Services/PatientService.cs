using WebUi.Swagger;

namespace WebUi.Services
{
    public class PatientService: IPatientService
    {
        private readonly swaggerClient client;

        public PatientService(HttpClient httpClient)
        {
            this.client = new swaggerClient("http://localhost:5215", httpClient);
        }

        public async Task<List<Patient>> SearchPatients()
        {
            var result = await client.GetPatientsAsync();
            return result.ToList();
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            var result = await client.PostPatientAsync(patient);
            return result;
        }

        public async Task UpdatePatient(long id, Patient patient)
        {
            await client.PutPatientAsync(id, patient);
        }

        public async Task DeletePatient(long id)
        {
            await client.DeletePatientAsync(id);
        }
    }
}

