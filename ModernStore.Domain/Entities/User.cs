using ModernStore.Shared;

namespace ModernStore.Domain.Entities
{
    public class User: Entity
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
            Active = false;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        
        public void Deactivate() => Active = false;
        

    }
}
