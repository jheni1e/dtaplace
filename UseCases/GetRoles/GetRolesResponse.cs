using dtaplace.Models;

namespace dtaplace.UseCases.GetRoles;

public record GetRolesResponse (
    List<Role> Roles
);