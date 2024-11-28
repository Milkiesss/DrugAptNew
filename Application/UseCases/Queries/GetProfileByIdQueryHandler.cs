using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Queries;
/// <summary>
/// обработчик запроса GetProfileByIdQuery
/// </summary>
/// <param name="profileReadRepository">репозиторий Profile для чтения</param>
public class GetProfileByIdQueryHandler(IProfileReadRepository profileReadRepository)
    : IRequestHandler<GetProfileByIdQuery, Profile>
{
    public async Task<Profile> Handle(GetProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var responce = await profileReadRepository.GetByIdAsync(request.Id,cancellationToken);
        return responce;
    }
}