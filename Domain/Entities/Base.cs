using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Base : BaseWithOutId
{
    [Key] public long Id { get; set; }
}

public class BaseWithOutId
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}