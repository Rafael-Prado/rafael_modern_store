using FluentValidator;
using ModernStore.Shared;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer: Entity
    {
        public Customer(string firstName, string lastName, string email, User user)
        {            
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;
            // Validação
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60)
                .HasMinLenght(x => x.FirstName, 3)
                .IsRequired(x => x.FirstName, "Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60)
                .HasMinLenght(x => x.LastName, 3)
                .IsEmail(x => x.Email, "E-mail é invalido");

        }
        
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public  DateTime? BirthDate{ get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }

        public void Update(string name, DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
