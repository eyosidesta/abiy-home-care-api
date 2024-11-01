using data.email;
using Microsoft.EntityFrameworkCore;
using model.email;


namespace services.email 
{
    public class EmailServices {
        private readonly MyDbContext _context;
        public EmailServices(MyDbContext context) {
            _context = context;
        }
        public async Task<List<EmailModel>> GetAllEmailAsync() {
            return await _context.Emails.ToListAsync();
        }
        public async Task<EmailModel> GetEmailByIdAsync(int id) {
            var getEmail = await _context.Emails.FindAsync(id);
            if (getEmail == null) throw new KeyNotFoundException($"Email with Id {id} not found.");
            return getEmail;
        }
        public async Task<EmailModel> CreateEmailAsync(EmailModel email) {
            _context.Add(email);
            await _context.SaveChangesAsync();
            return email;
        }
        public async Task<EmailModel> UpdateEmailAsync(EmailModel email) {
            _context.Emails.Update(email);
            await _context.SaveChangesAsync();
            return email;
        }
        public async Task<bool> DeleteEmailAsync(int id) {
            var getEmail = await _context.Emails.FindAsync(id);
            if (getEmail == null) return false;
            _context.Emails.Remove(getEmail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}