﻿using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Syntax.Elements.Types;
using ArchUnitNET.Fluent.Syntax.Elements.Types.Classes;
using ArchUnitNET.Loader;
using CarFactory.Cars.Domain;
using CarFactory.Core;
using Microsoft.AspNetCore.Mvc;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace CarFactory.Tests.Architecture;

public class ArchitectureDefinitions
{
    private ArchitectureDefinitions()
    {
    }
    
    public static readonly ArchUnitNET.Domain.Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(Car).Assembly).Build();
    
    public static readonly GivenTypesConjunction AllCommands = Types().That().HaveNameEndingWith("Command");

    public static readonly GivenClassesConjunction AllControllers =
        Classes().That().AreAssignableTo(typeof(ControllerBase));
    
    public static readonly GivenTypesConjunction AllRepositories =
        Types().That().AreAssignableTo(typeof(IRepository));
    
    public static readonly GivenTypesConjunction AllInternal =
        Types().That().ResideInNamespace(".*\\.Impl$", true);
}