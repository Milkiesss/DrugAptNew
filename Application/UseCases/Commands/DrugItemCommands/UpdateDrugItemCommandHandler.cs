using DrugsApt.Application.Interfaces.Repositories.DrugItemRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugItemCommands;
/// <summary>
/// обработчик команды UpdateDrugItemCommands
/// </summary>
/// <param name="drugItemWriteRepository">репозиторий DrugItem для записи</param>
/// <param name="drugReadRepository">репотозирий Drug для чтений</param>
/// <param name="drugStoreReadRepository">репозиторий DrugStore для чтений</param>
/// <param name="drugItemReadRepository">репозиторий DrugItem для чтений</param>
public class UpdateDrugItemCommandHandler(
    IDrugItemWriteRepository drugItemWriteRepository,
    IDrugReadRepository drugReadRepository,
    IDrugStoreReadRepository drugStoreReadRepository,
    IDrugItemReadRepository drugItemReadRepository)
    : IRequestHandler<UpdateDrugItemCommands, DrugItem>
{
    public async Task<DrugItem> Handle(UpdateDrugItemCommands request, CancellationToken cancellationToken)
    {
        var drugItemExist = await drugItemReadRepository.GetByIdAsync(request.Id,cancellationToken);
        if (drugItemExist is null)
            throw new NullReferenceException();
        
        var drug = await drugReadRepository.GetByIdAsync(request.DrugId,cancellationToken);
        var druStore = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId,cancellationToken);
        
        if(drug is null && druStore is null)
            throw new NullReferenceException();
        
        var drugItem = new DrugItem(drug.Id, drug, druStore.Id, druStore, request.Price, request.Amount)
        {
            Id = request.Id,
        };
        await drugItemWriteRepository.AddAsync(drugItem,cancellationToken);
        return drugItem;
    }
}