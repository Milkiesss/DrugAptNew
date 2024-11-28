using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Application.UseCases.Commands.CountryCommands;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// обработчик команды CreateDrugStoreCommand
/// </summary>
/// <param name="drugStoreWriteRepository">репозиторий DrugStore для записи</param>
public class CreateDrugStoreCommandHandler(IDrugStoreWriteRepository drugStoreWriteRepository)
    : IRequestHandler<CreateDrugStoreCommand, DrugStore>
{
    public async Task<DrugStore> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = new DrugStore(request.DrugNetWork, request.Number, request.Address, request.PhoneNumber);
        await drugStoreWriteRepository.AddAsync(drugStore,cancellationToken);
        return drugStore;
    }
}
