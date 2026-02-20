namespace CRUD.Domain;
public class UpdateClientRequest
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
}