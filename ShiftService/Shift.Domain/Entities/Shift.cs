using SharedKernel.Primitives;
using ShiftService.Domain.Enums;
using ShiftService.Domain.Exceptions;
using ShiftService.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace ShiftService.Domain.Entities;

public class Shift : AggregateRoot
{
    public DateOnly Date { get; private set; }
    public ShiftTime ShiftTime { get; private set; }

    private ShiftWorkersList _shiftWorkers;

    public IReadOnlyCollection<ShiftWorker> ShiftWorkers => _shiftWorkers.ShiftWorkersCollection;

    public ShiftStatus ShiftStatus { get; private set; } = ShiftStatus.None;

    // for Ef
    private Shift() {}

    private Shift(DateTime startShift, List<ShiftWorker> shiftWorkers)
    {
        ShiftTime = new ShiftTime(startShift, DateTime.MinValue);
        Date = DateOnly.FromDateTime(startShift);
        _shiftWorkers = new ShiftWorkersList(shiftWorkers);
        ChangeShiftStatus(ShiftStatus.InProcess);
    }
    private Shift(DateTime startShift, DateTime endShift, List<ShiftWorker> shiftWorkers)
    {
        ShiftTime = new ShiftTime(startShift, endShift);
        _shiftWorkers = new ShiftWorkersList(shiftWorkers);
        ChangeShiftStatus(ShiftStatus.InProcess);
    }

    public static Shift Create(DateTime startShift, List<ShiftWorker> shiftWorkers)
    {
        return new Shift(startShift, shiftWorkers);
    }

    public static Shift Create(DateTime startShift, DateTime endShift, List<ShiftWorker> shiftWorkers)
    {
        return new Shift(startShift, endShift, shiftWorkers);
    }

    public void AddShiftWorkerToCollection(ShiftWorker worker)
    {
        if (worker is null) throw new ArgumentIsNullDomainException($"{nameof(worker)} is null");
        List<ShiftWorker> shiftWorkers = new(ShiftWorkers);
        shiftWorkers.Add(worker);
        _shiftWorkers = new ShiftWorkersList(shiftWorkers);

    }

    public void RemoveShiftWorkerFromCollection(ShiftWorker worker)
    {
        if (worker is null) throw new ArgumentIsNullDomainException($"{nameof(worker)} is null");
        List<ShiftWorker> shiftWorkers = new(ShiftWorkers);
        shiftWorkers.Remove(worker);
        _shiftWorkers = new ShiftWorkersList(shiftWorkers);
    }

    private void ChangeShiftStatus(ShiftStatus shiftStatus)
    {
        ShiftStatus = shiftStatus;
    }

    public void CloseShift()
    {
        if (ShiftTime.End == DateTime.MinValue)
            ShiftTime = new ShiftTime(ShiftTime.Start, DateTime.Now);

        ChangeShiftStatus(ShiftStatus.Closed);
    }
}
