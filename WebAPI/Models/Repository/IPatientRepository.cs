using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Models.Repository
{
	public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> Search(string name);
        public Task<IEnumerable<Patient>> GetPatients();
        public Task<Patient?> GetPatient(long id);
        public Task<Patient?> UpdatePatient(long id, Patient patient);
        public Task<Patient> AddPatient(Patient patient);
        public Task DeletePatient(long id);
    }
}

