using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// обработчик команды DeleteProfileCommand
/// </summary>
/// <param name="profileWriteRepository">репозиторий Profile для записи</param>
public class DeleteProfileCommandHandler(IProfileWriteRepository profileWriteRepository)
    : IRequestHandler<DeleteProfileCommand, bool>
{
    public async Task<bool> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
    {
        await profileWriteRepository.DeleteAsync(request.Id,cancellationToken);
        return true;
    }
}