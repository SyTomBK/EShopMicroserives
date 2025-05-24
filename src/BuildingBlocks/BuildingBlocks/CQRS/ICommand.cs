using MediatR;
namespace BuildingBlocks.CQRS;
public interface ICommand : ICommand<Unit> //void
{
}

public interface ICommand<out TResponse>: IRequest<TResponse>
{
}
