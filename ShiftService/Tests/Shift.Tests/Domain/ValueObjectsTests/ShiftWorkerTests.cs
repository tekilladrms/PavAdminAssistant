using ShiftService.Domain.ValueObjects;
using System;
using System.Text.Json;

namespace Shift.Tests.Domain.ValueObjectsTests;

public class ShiftWorkerTests
{
    

    [Fact]
    public void ExplicitOperator_ShouldReturnShiftWorkerInstance()
    {
        // arrange

        Guid employeeId = Guid.NewGuid();
        Guid jobTitleId = Guid.NewGuid();

        ShiftWorker worker = new ShiftWorker(employeeId, jobTitleId, new ShiftTime(DateTime.Now, DateTime.Now.AddHours(1)));

        var result = worker.ToString();

        // act

        var workerResult = (ShiftWorker)result;

        // assert

        Assert.IsType<ShiftWorker>(workerResult);
    }
}
