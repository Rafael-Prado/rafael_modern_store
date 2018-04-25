using FluentValidator;

namespace ModernStore.Domain.ValueObject
{
    public class Document: Notifiable
    {
        protected Document() { }

        public Document(string number)
        {
            Number = number;

            if (!Validate(Number))
                AddNotification("Number", "Cpf inválido");
        }

        public string Number { get; private set; }

        public bool Validate(string cpf)
        {
            return true;
        }

    }
}
