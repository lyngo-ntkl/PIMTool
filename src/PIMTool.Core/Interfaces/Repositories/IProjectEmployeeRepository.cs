using PIMTool.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Core.Interfaces.Repositories
{
    public interface IProjectEmployeeRepository
    {
        Task AddAsync(ProjectEmployee projectEmployee);
        Task AddRangeAsync(IEnumerable<ProjectEmployee> entities);
        Task<IEnumerable<ProjectEmployee>> GetAsync(Expression<Func<ProjectEmployee, bool>>? filter = null, string includeProperties = "", Func<IQueryable<ProjectEmployee>, IOrderedQueryable<ProjectEmployee>>? orderBy = null);
        Task SaveChangesAsync();
    }
}
