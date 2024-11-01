
namespace model.email
{
    public class EmailModel
    {
        public long Id {get; set;}
        public required string Name { get; set; }
        public required string Email { get; set; }

        public required string Phone { get; set; }

        public required string Subject { get; set; }
        public required string Description { get; set; }
    
    }
}