using FluentValidator;
using ModernStore.Shared;
using System.Text;

namespace ModernStore.Domain.Entities
{
    public class User: Entity
    {
        public User(string userName, string password, string confirmPassord)
        {
            UserName = userName;
            Password = EncryptPassword(password);
            Active = true;

            new ValidationContract<User>(this)
                .AreEquals(x => x.Password, EncryptPassword(confirmPassord), "Senha não confirmada");
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        
        public void Deactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2991");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }


    }
}
