namespace Application.Common.Models;

public record BaseFilterQueryResult<T>
(
    IQueryable<T> Data,
    int Count
);