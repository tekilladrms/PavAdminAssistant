using SharedKernel.Repositories;
using ShiftService.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShiftService.Domain.Repositories;

public interface IShiftRepository : IRepository<Shift>
{
    public Task<Shift> GetByDateAsync(DateOnly date, CancellationToken cancellationToken);
}
