using ProjectsManagement.Models;

namespace ProjectsManagement.Providers;

public interface IJwtProvider
{
    string Generate(Person person);
}
