using System.ComponentModel.DataAnnotations;
using Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Dto;

public class PaginatedList<T> : BasePaginatedListParameter
{
    public PaginatedList(List<T> items, int count, int pageNumber, int pageSize) : base(pageNumber, pageSize)
    {
        Items = items;
        TotalPages = (int) Math.Ceiling(count / (double) pageSize);
        TotalCount = count;
    }

    public List<T> Items { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;

    public static Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int count, int pageNumber,
        int pageSize)
    {
        return Task.FromResult(new PaginatedList<T>(source.ToList(), count, pageNumber, pageSize));
    }
}

public class BasePaginatedListParameter
{
    public BasePaginatedListParameter(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    [Range(1, 10000)] public int PageNumber { get; }
    [Range(1, 100)] public int PageSize { get; }
}

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(
        this IQueryable<TDestination> queryable, int count, int pageNumber, int pageSize) where TDestination : class
    {
        return PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), count, pageNumber, pageSize);
    }
}