using DrugsApt.Application.Interfaces.Repositories.DrugRepositories;
using DrugsApt.Application.UseCases.Commands.DrugCommands;
using DrugsApt.Domain.Entities;
using MediatR;

namespace DrugsApt.Application.UseCases.Commands;
/// <summary>
/// обработчик команды CreateDrugCommand
/// </summary>
/// <param name="drugWriteRepository">репозиторий Drug для записи</param>
public class CreateDrugCommandHandler(IDrugWriteRepository drugWriteRepository)
    : IRequestHandler<CreateDrugCommand, Drug>
{
    public async Task<Drug> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = new Drug(request.Name, request.Manufacturer, request.CountryCodeId, request.Country);

        await drugWriteRepository.AddAsync(drug,cancellationToken);
        return drug;
    }
}