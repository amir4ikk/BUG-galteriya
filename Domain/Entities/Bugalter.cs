using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;
public class Bugalter : BaseEntity
{
    public string Name { get; set; } = "";
    public string Company_Name { get; set; } = string.Empty;

    [ForeignKey(nameof(CompanyId))]
    public int CompanyId { get; set; }  
}
