﻿using AutoMapper;
using Hotels.DataAccess.Contracts;
using Hotels.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Hotels.Models.Models.Response;
using Hotels.Models.Models.QueryResponse;
using AutoMapper.QueryableExtensions;
using Hotels.Models;
using Hotels.Models.Exceptions;

namespace Hotels.DataAccess.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public GenericRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
    {
        var entity = _mapper.Map<T>(source);

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TResult>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetAsync(id);

        if (entity is null)
            throw new NotFoundException(typeof(T).Name, id);

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> Exists(int id)
    {
        var entity = await GetAsync(id);
        return entity is not null;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<PagedResult<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
    {
        var totalSize = await _context.Set<T>().CountAsync();
        var items = await _context.Set<T>()
            .Skip(queryParameters.StartIndex)
            .Take(queryParameters.PageSize)
            .ProjectTo<TResult>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResult<TResult>
        {
            Items = items,
            PageNumber = queryParameters.PageNumber,
            RecordNumber = queryParameters.PageSize,
            TotalCount = totalSize
        };
    }

    public async Task<IEnumerable<TResult>> GetAllAsync<TResult>()
    {
        return await _context.Set<T>()
            .ProjectTo<TResult>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<T> GetAsync(int? id)
    {
        if (id is null)
            return null;

        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<TResult> GetAsync<TResult>(int? id)
    {
        var result = await _context.Set<T>().FindAsync(id);

        if (result is null)
            throw new NotFoundException(typeof(T).Name, id.HasValue ? id : "No Key Provided");

        return _mapper.Map<TResult>(result);
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync<TSource>(int id, TSource source) where TSource : IBase
    {
        if (id != source.Id)
            throw new BadRequestException("Invalid Id used in request");

        var entity = await GetAsync(id);

        if (entity is null)
            throw new NotFoundException(typeof(T).Name, id);

        _mapper.Map(source, entity);
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}
