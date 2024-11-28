using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// обработчик команды CreateProfileCommand
/// </summary>
/// <param name="profileWriteRepository">репозиторий Profile для записи</param>
public class CreateProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    : IRequestHandler<CreateProfileCommand, Profile>
{
    public async  Task<Profile> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var profile = new Profile(request.ExternalId, request.Email);
        await profileWriteRepository.AddAsync(profile,cancellationToken);
        return profile;
    }
}