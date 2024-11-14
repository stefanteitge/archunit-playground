using ArchUnitNET.Domain;
using ArchUnitNET.Fluent.Conditions;
using ArchUnitNET.xUnit;
using CarFactory.Core;
using static CarFactory.Tests.Architecture.ArchitectureDefinitions;

namespace CarFactory.Tests.Architecture;

public class ArchitectureTest
{
    [Fact]
    public void TypeWithPostfixCommandAreInCommandFolder()
    {
        AllCommandsByName.Should().ResideInNamespace(".*\\.Commands$", true)
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void TypesInDtosFolderHaveDtoSuffix()
    {
        AllDtosByNamepsace.Should().HaveNameEndingWith("Dto")
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void ControllersDontUseRepositories()
    {
        AllControllers.Should().NotDependOnAny(AllRepositories)
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void RepositoriesAlwaysDeriveFromInterface()
    {
        AllRepositoriesByName.Should().ImplementInterface(typeof(IRepository))
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void ImplementationsAreAlwaysInternal()
    {
        AllInternal.Should().BeInternal()
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void HandlerHaveHandleMethod()
    {
        AllHandlerByName.Should().FollowCustomCondition(new HasMethod("Handle"))
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    private class HasMethod(string methodName) : ICondition<IType>
    {
        public string Description => "Check for handle method";

        public IEnumerable<ConditionResult> Check(IEnumerable<IType> objects, ArchUnitNET.Domain.Architecture architecture)
        {
            return from obj in objects let pass = obj.Members.Any(m => m.Name.StartsWith($"{methodName}(")) select new ConditionResult(obj, pass);
        }

        public bool CheckEmpty()
        {
            return false;
        }
    }
}
