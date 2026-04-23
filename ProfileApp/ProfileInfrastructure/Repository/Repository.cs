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

    public async Task<T> Update(T entity)
    {
        var d = _context.Entry(entity);
        d.State = EntityState.Modified;
        return d.Entity;
    }

    public async Task<bool> SaveChangesAsync(Guid userId)
        => await _context.SaveChangesAsync(userId) > 0;

    public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate)
        => await _context.Set<T>().FirstOrDefaultAsync(predicate);


    public async Task<Profile> GetByIdWithConditionAsync(string Id)
        => await _context.Profiles
                .Include(p => p.Projects)
                .Include(p => p.Skills)
                .Include(p => p.Educations)
                .Include(p => p.Experiences)
                .Include(p => p.SocialLinks)
                .Include(p => p.Certifications)
                .FirstOrDefaultAsync(p => p.UserId == Id);

}
