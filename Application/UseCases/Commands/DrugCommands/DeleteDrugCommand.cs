using MediatR;

namespace DrugsApt.Application.UseCases.Commands.DrugCommands;
/// <summary>
/// команда на удание обьекта сущноти Drug
/// </summary>
/// <param name="Id">идентификатор</param>
public record DeleteDrugCommand(Guid Id) : IRequest<bool>;