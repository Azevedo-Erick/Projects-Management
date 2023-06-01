namespace ProjectsManagement.Authentication;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(int id);
}
