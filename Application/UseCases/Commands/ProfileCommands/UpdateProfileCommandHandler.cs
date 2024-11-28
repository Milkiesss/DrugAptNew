using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// обработчик команды UpdateProfileCommand
/// </summary>
/// <param name="profileReadRepository">репозиторий Profile для чтения</param>
/// <param name="profileWriteRepository">репозиторий Profile для записи</param>
public class UpdateProfileCommandHandler(
    IProfileReadRepository profileReadRepository,
    IProfileWriteRepository profileWriteRepository)
    : IRequestHandler<UpdateProfileCommand, Profile>
{
    public async Task<Profile> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
       var profileExist = await profileReadRepository.GetByIdAsync(request.Id,cancellationToken);
       if (profileExist is null)
           throw new NullReferenceException();
       var profile = new Profile(request.ExternalId, request.Email)
       {
           Id = request.Id,
       };
       await profileWriteRepository.AddAsync(profile, cancellationToken);
       
       return profile;
    }
}