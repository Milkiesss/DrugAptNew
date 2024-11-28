using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.DrugStoreRepositories;
using DrugsApt.Application.Interfaces.Repositories.FavoriteDrugRepositories;
using DrugsApt.Application.Interfaces.Repositories.ProfileRepositories;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands.FavoriteDrugCommands;
/// <summary>
/// обработчик команды CreateFavoriteDrugCommands
/// </summary>
/// <param name="favoriteDrugWriteRepository">репозиторий FavoriteDrug для записи</param>
/// <param name="drugStoreReadRepository">репозиторий DrugStoreдля чтения</param>
/// <param name="drugReadRepository">репозиторий Drug для чтения</param>
/// <param name="profileReadRepository">репозиторий Profile для чтения</param>
public class CreateFavoriteDrugCommandHandler(
    IFavoriteDrugWriteRepository favoriteDrugWriteRepository, 
    IDrugStoreReadRepository drugStoreReadRepository, 
    IDrugReadRepository drugReadRepository, 
    IProfileReadRepository profileReadRepository)
    : IRequestHandler<CreateFavoriteDrugCommands, FavoriteDrug>
{
   public async Task<FavoriteDrug> Handle(CreateFavoriteDrugCommands request, CancellationToken cancellationToken)
    {
        var ProfileExist = await profileReadRepository.GetByIdAsync(request.ProfileId,cancellationToken);
        if (ProfileExist is null)
            throw new NullReferenceException("Profile not found");
        
        var drugExist = await drugReadRepository.GetByIdAsync(request.DrugId,cancellationToken);
        if(drugExist is null)
            throw new NullReferenceException("Drug not found");
        
        var drugStoreExist = await drugStoreReadRepository.GetByIdAsync(request.DrugStoreId,cancellationToken);


        var favoriteDrug = new FavoriteDrug(
            ProfileExist.Id, 
            ProfileExist, 
            drugExist.Id, 
            drugStoreExist.Id,
            drugExist,
            drugStoreExist);
        await favoriteDrugWriteRepository.AddAsync(favoriteDrug);
        return favoriteDrug;
    }
}