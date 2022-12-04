using System.ComponentModel.DataAnnotations;

namespace Presentation.Dto;

public class BaseResponseDto
{
    public BaseResponseDto(long id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    [Required] public long Id { get; }
    [Required] public DateTime CreatedAt { get; }
    [Required] public DateTime UpdatedAt { get; }
}