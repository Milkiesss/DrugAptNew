using MediatR;

namespace DrugsApt.Application.UseCases.Commands.ProfileCommands;
/// <summary>
/// команда на удаление сущности Profile
/// </summary>
/// <param name="Id">идентификатор</param>
public record DeleteProfileCommand(Guid Id) : IRequest<bool>;