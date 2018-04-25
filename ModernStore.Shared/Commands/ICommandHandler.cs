
namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommad
    {
        ICommadResult Handle(T commad);
    }
}
