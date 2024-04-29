using FluentAssertions;
using NetArchTest.Rules;

namespace ArquitectureTests;

public class LayerTests
{
    private const string DomainNamespace = "Domain";
    private const string ApplicationNamespace = "Application";
    private const string InfrastructureNamespace = "Infrastructure";
    private const string WebNamespace = "Web.Api";

    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(Domain.DomainAssembly).Assembly;
        var otherProjects = new[]
        {
            ApplicationNamespace, 
            InfrastructureNamespace, 
            WebNamespace,
        };

        //Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        //Arrange
        var assembly = typeof(Application.ApplicationAssembly).Assembly;
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            WebNamespace,
        };

        //Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();

        //
        testResult.IsSuccessful.Should().BeTrue();
    }
}
