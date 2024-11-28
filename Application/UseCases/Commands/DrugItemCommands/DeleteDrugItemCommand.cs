using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugItemCommands;
/// <summary>
/// команда на удаение обьекта сущности DrugItem
/// </summary>
/// <param name="Id">идентификатор</param>
public record DeleteDrugItemCommand(Guid Id) : IRequest<bool>;