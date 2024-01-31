namespace MultiprojectWithDb.DTOs
{
    public class NoteUpdateDTO
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime? Updated { get; set; }
        public byte[] Picture { get; set; }
    }
}
