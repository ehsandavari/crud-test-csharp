namespace Application.Common.Models;

public record BaseVirtualModel
(
    long Id = default
) : BaseVirtualModelWithOutId;

public record BaseVirtualModelWithOutId
(
    DateTime CreatedAt = default,
    DateTime UpdatedAt = default
);