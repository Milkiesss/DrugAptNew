using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.UseCases.Commands.DrugCommands;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands;
/// <summary>
/// обработчик команды DeleteDrugCommand
/// </summary>
/// <param name="drugWriteRepository">репозиторий Drug Для чтения</param>
public class DeleteDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    : IRequestHandler<DeleteDrugCommand, bool>
{

    public async Task<bool> Handle(DeleteDrugCommand request, CancellationToken cancellationToken)
    {
        await drugWriteRepository.DeleteAsync(request.Id,cancellationToken);
        return true;
    }
}