using ArchUnitNET.xUnit;

namespace CarFactory.Tests.Architecture;

public class UnitTest1
{
    [Fact]
    public void CommandsAreInNamespace()
    {
        ArchitectureDefinitions.AllCommands.Should().ResideInNamespace(".*\\.Commands$", true)
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void ControllersDontUseRepositories()
    {
        ArchitectureDefinitions.AllControllers.Should().NotDependOnAny(ArchitectureDefinitions.AllRepositories)
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
    
    [Fact]
    public void ImplementationsAreAlwaysPrivate()
    {
        ArchitectureDefinitions.AllInternal.Should().BeInternal()
            .WithoutRequiringPositiveResults()
            .Check(ArchitectureDefinitions.Architecture);
    }
}