﻿using Microsoft.EntityFrameworkCore;
using ParkingSystem.Domain.Entities;
using ParkingSystem.Domain.Interfaces;
using ParkingSystem.Domain.Pagination;
using ParkingSystem.Infrastructure.Context;

namespace ParkingSystem.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await _context.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<PagedResult<Category>> GetCategories(int pageSize, int currentPage)
    {
        var categoriesQuery = _context.Categories.OrderBy(c => c.Id);
        var totalCount = await categoriesQuery.CountAsync();

        var items = await categoriesQuery
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.PriceTable)
                .Include(p => p.Spots)
                .ToListAsync();

        return new PagedResult<Category>
        {
            Items = items,
            CurrentPage = currentPage,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}
