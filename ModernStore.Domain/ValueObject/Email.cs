using FluentValidator;

namespace ModernStore.Domain.ValueObject
{
    public class Email: Notifiable
    {
        protected Email(){}

        public Email(string address)
        {
            Address = address;


            new ValidationContract<Email>(this)
               .IsEmail(x => x.Address, "Email é inváloido");
        }

        public string Address { get; private set; }

    }
}
