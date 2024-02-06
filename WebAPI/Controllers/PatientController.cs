using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]

    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        /// <summary>
        /// Gets the List of Patients
        /// </summary>
        /// <returns>List of Patients</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            try
            {
                return Ok(await patientRepository.GetPatients());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Returns a patiend for a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(long id)
        {
            try
            {
                var result = await patientRepository.GetPatient(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // </snippet_GetByID>

        //[HttpGet("{search}")]
        //public async Task<ActionResult<IEnumerable<Patient>>> Search(string name)
        //{
        //    try
        //    {
        //        var result = await patientRepository.Search(name);

        //        if (result.Any())
        //            return Ok(result);

        //        return NotFound();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");

        //    }
        //}


        // PUT: Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Update>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPatient(long id, Patient patient)
        {
            try
            {
                if (id != patient.Id)
                    return BadRequest();

                var patientToUpdate = await patientRepository.GetPatient(id);

                if (patientToUpdate == null)
                    return NotFound($"Employee with Id = {id} not found");

                var result = await patientRepository.UpdatePatient(id, patient);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating patient record");
            }
        }
        // </snippet_Update>

        // POST: Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            try
            {
                if (patient == null)
                    return BadRequest();
                var createdPatient = await patientRepository.AddPatient(patient);

                return CreatedAtAction(nameof(GetPatient), new { id = createdPatient.Id }, createdPatient);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new patient record");
            }
        }
        // </snippet_Create>

        // DELETE: Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(long id)
        {
            try
            {
                var patientToDelete = await patientRepository.GetPatient(id);

                if (patientToDelete == null)
                    return NotFound($"Employee with id - {id} not found");

                await patientRepository.DeletePatient(id);

                return Ok($"Employee with id - {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting patient record");
            }
        }
    }
}
