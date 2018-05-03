using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommad
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
