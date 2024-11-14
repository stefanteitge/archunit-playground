using ArchUnitNET.Fluent.Syntax.Elements.Types;
using ArchUnitNET.Fluent.Syntax.Elements.Types.Classes;
using ArchUnitNET.Loader;
using CarFactory.Cars.Domain;
using CarFactory.Core;
using Microsoft.AspNetCore.Mvc;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace CarFactory.Tests.Architecture;

public sealed class ArchitectureDefinitions
{
    private ArchitectureDefinitions()
    {
    }
    
    public static readonly ArchUnitNET.Domain.Architecture Architecture
        = new ArchLoader().LoadAssemblies(typeof(Car).Assembly).Build();
    
    public static readonly GivenTypesConjunction AllCommandsByName
        = Types().That().HaveNameEndingWith("Command");
    
    public static readonly GivenTypesConjunction AllHandlerByName
        = Types().That().HaveNameEndingWith("Handler");
    
    public static readonly GivenTypesConjunction AllDtosByNamepsace
        = Types().That().ResideInNamespace(".*\\.Dtos$", true);

    public static readonly GivenClassesConjunction AllControllers
        = Classes().That().AreAssignableTo(typeof(ControllerBase));
    
    public static readonly GivenTypesConjunction AllRepositories
        = Types().That().AreAssignableTo(typeof(IRepository));
    
    public static readonly GivenClassesConjunction AllRepositoriesByName
        = Classes().That().HaveNameEndingWith("Repository");
    
    public static readonly GivenTypesConjunction AllInternal =
        Types().That().ResideInNamespace(".*\\.Impl$", true);
}