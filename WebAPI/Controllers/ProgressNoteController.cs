using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgressNoteController : ControllerBase
    {
        private readonly IProgressNoteRepository progressNoteRepository;

        public ProgressNoteController(IProgressNoteRepository progressNoteRepository)
        {
            this.progressNoteRepository = progressNoteRepository;
        }

        // GET: Patients
        [HttpGet]
        public async Task<ActionResult> GetProgressNotes()
        {
            try
            {
                return Ok(await progressNoteRepository.GetProgressNotes());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("organization/{id}")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetProgressNotesByOrganizationId(long id)
        {
            try
            {
                return Ok(await progressNoteRepository.GetProgressNotesByOrganizationId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("patient/{id}")]
        public async Task<ActionResult<IEnumerable<ProgressNote>>> GetProgressNotesByPatientId(long id)
        {
            try
            {
                return Ok(await progressNoteRepository.GetProgressNotesByPatientId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // POST: Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // <snippet_Create>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProgressNote>>> PostProgressNotes(IEnumerable<ProgressNote> progressNotes)
        {
            try
            {
                if (progressNotes == null)
                    return BadRequest();

                var createdProgressNotes = await progressNoteRepository.AddProgressNotes(progressNotes);

                return CreatedAtAction(nameof(GetProgressNotes), null, createdProgressNotes);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new patient record");
            }
        }
        // </snippet_Create>

        // DELETE: Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProgressNote(long id)
        {
            try
            {
                var progressNoteToDelete = await progressNoteRepository.GetProgressNote(id);

                if (progressNoteToDelete == null)
                    return NotFound($"Note with id - {id} not found");

                await progressNoteRepository.DeleteProgressNote(id);

                return Ok($"Note with id - {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting progress record");
            }
        }
    }
}

