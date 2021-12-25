using PortFolio.Application.Common.Mappers;
using PortFolio.Domain;

namespace PortFolio.Application.Models;

public class UserModel : IMapFrom<User>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}