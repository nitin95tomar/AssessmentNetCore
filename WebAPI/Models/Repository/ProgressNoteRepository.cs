using System;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models.Repository
{
    public class ProgressNoteRepository : IProgressNoteRepository
    {
        private readonly AppDbContext appDbContext;

        public ProgressNoteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ProgressNote> AddProgressNote(ProgressNote progressNote)
        {
            var result = await appDbContext.ProgressNotes.AddAsync(progressNote);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProgressNote(long id)
        {
            var result = await appDbContext.ProgressNotes.FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                appDbContext.ProgressNotes.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<ProgressNote?> GetProgressNote(long id)
        {
            return await appDbContext.ProgressNotes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProgressNote>> GetProgressNotes()
        {
            var result = await appDbContext.ProgressNotes.ToListAsync();
            return result;
        }

        public async Task<IEnumerable<ProgressNote>> GetProgressNotesByPatientId(long patientId)
        {
            IQueryable<ProgressNote> query = appDbContext.ProgressNotes;

            query.Where(p => p.PatientId == patientId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProgressNote>> GetProgressNotesByOrganizationId(long organizationId)
        {
            IQueryable<ProgressNote> query = appDbContext.ProgressNotes;

            query.Where(p => p.OrganizationId == organizationId);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<ProgressNote>> AddProgressNotes(IEnumerable<ProgressNote> progressNotes)
        {
            await appDbContext.ProgressNotes.AddRangeAsync(progressNotes);
            await appDbContext.SaveChangesAsync();
            return await appDbContext.ProgressNotes.ToListAsync<ProgressNote>();

        }
    }
}
