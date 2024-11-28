using DrugsApt.Application.Interfaces.Repositories.DrugItemRepositories;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugItemCommands;
/// <summary>
/// обрабочик команды DeleteDrugItemCommand
/// </summary>
/// <param name="drugItemWriteRepository">репозиторий DrugItem для записи</param>
public class DeleteDrugItemCommandHandler(IDrugItemWriteRepository drugItemWriteRepository)
    : IRequestHandler<DeleteDrugItemCommand, bool>
{
    public async Task<bool> Handle(DeleteDrugItemCommand request, CancellationToken cancellationToken)
    {
        await drugItemWriteRepository.DeleteAsync(request.Id,cancellationToken);
        return true;
    }
}