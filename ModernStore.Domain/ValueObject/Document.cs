using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.ValueObject
{
    public class Document: Notifiable
    {
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
