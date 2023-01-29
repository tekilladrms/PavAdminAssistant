using Microsoft.EntityFrameworkCore;
using ShiftService.Domain.Entities;
using ShiftService.Domain.Exceptions;
using ShiftService.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShiftService.Persistence.Repositories
{
    internal class ShiftRepository : IShiftRepository
    {
        private readonly ApplicationDbContext _context;

        public ShiftRepository(ApplicationDbContext context) => _context = context;

        public async Task<Shift> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default)
        {

            Shift shift = await _context.Set<Shift>().FirstOrDefaultAsync(s => s.Date == date);

            if (shift is null) throw new NotFoundDomainException($"Record with date = {date} was not found");

            return shift;
        }

        public async Task<Shift> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            Shift shift = await _context.Set<Shift>().FirstOrDefaultAsync(s => s.Guid == id);

            if (shift is null) throw new NotFoundDomainException($"Record with id = {id} was not found");

            return shift;
        }

        public async Task<Shift> AddAsync(Shift entity, CancellationToken cancellationToken = default)
        {
            if (entity is null) throw new ArgumentIsNullDomainException($"parameter entity is null");

            await _context.AddAsync(entity);

            return await GetByIdAsync(entity.Guid);

        }

        public void Delete(Guid id, CancellationToken cancellationToken = default)
        {
            _context.Remove(GetByIdAsync(id));
        }

        public void Delete(Shift entity, CancellationToken cancellationToken = default)
        {
            if (entity is null) throw new ArgumentIsNullDomainException($"parameter entity is null");
            _context.Remove(entity);
        }

        public Shift Update(Shift entity, CancellationToken cancellationToken = default)
        {
            if (entity is null) throw new ArgumentIsNullDomainException($"parameter entity is null");
            _context.Update(entity);

            return GetByIdAsync(entity.Guid).Result;
        }
    }
}
