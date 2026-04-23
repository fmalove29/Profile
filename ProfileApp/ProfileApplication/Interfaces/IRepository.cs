using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ProfileDomain.Models;
using ProfileApplication.DTO.response;
namespace ProfileApplication.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    public Task<T> GetByIdAsync(Guid Id);
    public Task<T> Add(T entity);

    public Task<T> Update(T entity);
    public Task<T> Delete(T entity);
    public Task<bool> SaveChangesAsync(Guid userId);

    public Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);

    public Task<Profile> GetByIdWithConditionAsync(string Id);

}
