﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Slices;
using ArchUnitNET.xUnit;

namespace CarFactory.Tests.Architecture;

public class SliceTests
{
    [Fact]
    public void SliceCountIsCorrect()
    {
        var slices = SliceIt();

        Assert.Equal(2, slices.GetObjects(ArchitectureDefinitions.Architecture).Count());
    }
    
    [Fact]
    public void CarsShouldNotDependedOnEmployees()
    {
        var slices = SliceIt();
        
        slices.Should().NotDependOnEachOther()
            .Check(ArchitectureDefinitions.Architecture);
    }

    private GivenSlices SliceIt()
    {
        var ruleCreator = new SliceRuleCreator();
        ruleCreator.SetSliceAssignment(new SliceAssignment(ComputeIdentifiersBySubDomain, "Slices using custom assignment"));
        return new GivenSlices(ruleCreator);
    }

    // this method can be more generic for sure
    private SliceIdentifier ComputeIdentifiersBySubDomain(IType t)
    {
        var cars = "CarFactory.Cars";
        var employees = "CarFactory.Employees";

        if (t.Namespace.FullName.StartsWith(cars))
        {
            return SliceIdentifier.Of(cars); 
        }
        
        if (t.Namespace.FullName.StartsWith(employees))
        {
            return SliceIdentifier.Of(employees); 
        }

        return SliceIdentifier.Ignore();
    }
}