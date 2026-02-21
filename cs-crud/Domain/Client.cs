namespace CRUD.Domain
{
    public class Client(string id, string name, string email, DateTime birthDate, DateTime createdAt, DateTime updatedAt, bool isActive)
    {
        public string Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public string? Email { get; set; } = email;
        public DateTime BirthDate { get; set; } = birthDate;

        public DateTime CreatedAt { get; set; } = createdAt;

        public DateTime UpdatedAt { get; set; } = updatedAt;

        public bool IsActive { get; set; } = isActive;

        public string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }
}