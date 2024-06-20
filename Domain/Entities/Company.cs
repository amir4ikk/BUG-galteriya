namespace Domain.Entities;
public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Employees_Count { get; set; }
    public string Creator_Name { get; set; } = string.Empty;
}
