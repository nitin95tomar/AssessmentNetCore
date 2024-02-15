using System;
using WebUi.Swagger;

namespace WebUi.Services
{
    public interface IProgressNoteService
    {
        public Task<List<ProgressNote>> GetProgressNotes(long patientId);

        public Task<List<ProgressNote>> AddProgressNote(List<ProgressNote> progressNotes);
    }
}

