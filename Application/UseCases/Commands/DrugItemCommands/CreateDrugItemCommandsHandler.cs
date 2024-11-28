using DrugsApt.Application.Interfaces.Repositories.DrugItemRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugItemCommands;
/// <summary>
/// обработчик команды CreateDrugItemCommands
/// </summary>
/// <param name="drugItemWriteRepository">репозиторий DrugItem для записи</param>
/// <param name="drugStoreReadRepository">репозиторий DrugStore для чтений</param>
/// <param name="drugReadRepository">репозиторий Drug для чтений</param>
public class CreateDrugItemCommandsHandler(
    IDrugItemWriteRepository drugItemWriteRepository,
    IDrugStoreReadRepository drugStoreReadRepository,
    IDrugReadRepository drugReadRepository)
    : IRequestHandler<CreateDrugItemCommands, DrugItem>
{
    public async Task<DrugItem> Handle(CreateDrugItemCommands request, CancellationToken cancellationToken)
    {
        var drug = await drugReadRepository.GetByIdAsync(request.DrugId,cancellationToken);
        var druStore = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId,cancellationToken);
        if(drug is null && druStore is null)
            throw new NullReferenceException();
        var drugItem = new DrugItem(drug.Id, drug, druStore.Id, druStore, request.Price, request.Amount);
        await drugItemWriteRepository.AddAsync(drugItem,cancellationToken);
        return drugItem;
    }
}