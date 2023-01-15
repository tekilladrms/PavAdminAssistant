using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeService.Application.ValidationMethods;

public class CheckMethods
{
    public static bool IsValid<TEntity, TValue>(TValue value) where TEntity : IValidable<TValue>
    {
        if (!TEntity.IsValid(value)) return false;
        return true;
    }

    public static bool IsGuid(string guid)
    {
        return Regex.IsMatch(guid, @"[({]?[a-fA-F0-9]{8}[-]?([a-fA-F0-9]{4}[-]?){3}[a-fA-F0-9]{12}[})]?");
    }
}
