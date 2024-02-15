using WebUi.Swagger;

namespace WebUi.Services
{
    public class ProgressNoteService: IProgressNoteService
    {
        private readonly swaggerClient client;

        public ProgressNoteService(HttpClient httpClient)
        {
            this.client = new swaggerClient("http://localhost:5215", httpClient);
        }

        public async Task<List<ProgressNote>> GetProgressNotes(long patientId)
        {
            var result = await client.GetProgressNotesByPatientIdAsync(patientId);
            return result.ToList();
        }

        public async Task<List<ProgressNote>> AddProgressNote(List<ProgressNote> progressNotes)
        {
            var result = await client.PostProgressNotesAsync(progressNotes);
            return result.ToList();
        }

    }
}

