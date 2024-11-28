using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Application.UseCases.Commands.CountryCommands;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// обработчик команда UpdateDrugStoreCommand
/// </summary>
/// <param name="drugStoreWriteRepository">репозиторий DrugStore для записи</param>
/// <param name="drugStoreReadRepository">репозиторий DrugStore для чтения</param>
public class UpdateDrugStoreCommandHandler(
    IDrugStoreWriteRepository drugStoreWriteRepository,
    IDrugStoreReadRepository drugStoreReadRepository)
    : IRequestHandler<UpdateDrugStoreCommand, DrugStore>
{
   public async Task<DrugStore> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
   {
       var drugStoreExist = await drugStoreReadRepository.GetByIdAsync(request.Id);
       if (drugStoreExist is null)
           throw new NullReferenceException();
       
       var drugStore = new DrugStore(request.DrugNetWork, request.Number, request.Address, request.PhoneNumber)
       {
           Id = request.Id
       };
       await drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
       return drugStore;
   }
}