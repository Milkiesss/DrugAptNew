using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// обработчик событие DeleteDrugStoreCommand
/// </summary>
/// <param name="drugStoreWriteRepository">репозиторий DrugStore для записи</param>
public class DeleteDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    : IRequestHandler<DeleteDrugStoreCommand, bool>
{
    public async Task<bool> Handle(DeleteDrugStoreCommand request, CancellationToken cancellationToken)
    {
        await drugStoreWriteRepository.DeleteAsync(request.Id,cancellationToken);
        return true;
    }
}