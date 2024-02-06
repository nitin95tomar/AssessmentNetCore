using System;
using WebUi.Swagger;

namespace WebUi.Services
{
	public interface IPatientService
	{
        public Task<List<Patient>> SearchPatients();

        public Task<Patient> CreatePatient(Patient patient);

        public Task UpdatePatient(long id, Patient patient);

        public Task DeletePatient(long id);

    }
}

