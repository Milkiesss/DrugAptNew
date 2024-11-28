using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.UseCases.Commands.DrugCommands;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands;
/// <summary>
/// обработчик команды UpdateDrugCommand
/// </summary>
/// <param name="drugWriteRepository">репозиторий Drug для записи</param>
/// <param name="drugReadRepository">репозиторий Drug для чтения</param>
public class UpdateDrugCommandHandler(
    IDrugWriteRepository drugWriteRepository,
    IDrugReadRepository drugReadRepository)
    : IRequestHandler<UpdateDrugCommand, Drug>
{
    public async Task<Drug> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drugExist = await drugReadRepository.GetByIdAsync(request.Id,cancellationToken);
        if (drugExist is null)
            throw new NullReferenceException();
        var drug = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country)
        {
            Id = request.Id
        };

        await drugWriteRepository.AddAsync(drug,cancellationToken);
        return drug;
    }
}
