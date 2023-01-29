using SharedKernel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ShiftService.Domain.ValueObjects;

internal class ShiftWorkersList : ValueObject, IEnumerable<ShiftWorker>
{
    private List<ShiftWorker> _shiftWorkers { get; }
    public IReadOnlyCollection<ShiftWorker> ShiftWorkersCollection => _shiftWorkers;

    public ShiftWorkersList(IEnumerable<ShiftWorker> shiftWorkers) => _shiftWorkers = shiftWorkers.ToList();


    public static explicit operator ShiftWorkersList(string shiftWorkersList)
    {
        List<ShiftWorker> workers = shiftWorkersList.Split(';')
            .Select(w => (ShiftWorker)w).ToList();
        return new ShiftWorkersList(workers);
    }

    public static implicit operator string(ShiftWorkersList shiftWorkersList)
    {
        return string.Join(";", shiftWorkersList.Select(w => w.ToString()));
    }

    public IEnumerator<ShiftWorker> GetEnumerator()
    {
        return _shiftWorkers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return _shiftWorkers;
    }

    
}