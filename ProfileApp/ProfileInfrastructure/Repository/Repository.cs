using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProfileApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProfileInfrastructure.DataContext;
using ProfileDomain.Models;

namespace ProfileInfrastructure.Repository;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _entities;

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entities = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid Id)
        => await _entities.SingleOrDefaultAsync(s => s.Id == Id);

    public async Task<T> Add(T entity)
        => (await _entities.AddAsync(entity)).Entity;

    public Task<T> Delete(T entity)
        => Task.FromResult(_entities.Remove(entity).Entity);

    public Task<T> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.FromResult(entity);
    }
}
