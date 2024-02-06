using System;
namespace WebAPI.Models.Repository
{
	public interface IProgressNoteRepository
	{
        public Task<IEnumerable<ProgressNote>> GetProgressNotesByPatientId(long patientId);
        public Task<IEnumerable<ProgressNote>> GetProgressNotesByOrganizationId(long organizationId);
        public Task<IEnumerable<ProgressNote>> GetProgressNotes();
        public Task<ProgressNote?> GetProgressNote(long id);
        public Task<ProgressNote> AddProgressNote(ProgressNote progressNote);
        public Task<IEnumerable<ProgressNote>> AddProgressNotes(IEnumerable<ProgressNote> progressNotes);
        public Task DeleteProgressNote(long id);
    }
}

