using dtaplace.Models;

namespace dtaplace.UseCases.GetRoles;

public record GetRolesResponse (
    ICollection<Role> Roles
);