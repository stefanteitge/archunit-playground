# archunit-playground

This is no runnable application. There are some rough types to illustrate concepts.

It uses https://github.com/TNG/ArchUnitNET to check for architecture violations in code.

To execute run `dotnet test` in project.

## Tests

Tests can be broken by changing the code it checks.

`ControllersDontUseRepositories` and `CarsShouldNotDependedOnEmployees` are broken by default.
