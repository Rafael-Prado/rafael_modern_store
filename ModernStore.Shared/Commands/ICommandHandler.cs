
namespace ModernStore.Shared.Commands
{
    public interface ICommandHandler<T> where T : ICommad
    {
        void Handle(T commad);
    }
}
