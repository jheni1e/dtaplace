using dtaplace.Models;

namespace dtaplace.UseCases.GetRoles;

public record GetRolesResponse (
    IEnumerable<Role> Roles
);