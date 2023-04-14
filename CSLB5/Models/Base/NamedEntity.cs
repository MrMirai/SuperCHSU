using System.ComponentModel.DataAnnotations;

namespace CSLB5.Models.Base;

public abstract class NamedEntity : Entity
{
    [Required]
    public string Name { get; set; }
}