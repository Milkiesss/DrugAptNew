using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugStoreCommands;
/// <summary>
/// команда на удаление обьекта сущнотси DrugStore
/// </summary>
/// <param name="Id">идентификатор</param>
public record DeleteDrugStoreCommand(Guid Id) : IRequest<bool>;
