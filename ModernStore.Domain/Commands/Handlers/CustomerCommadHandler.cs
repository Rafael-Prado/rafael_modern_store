using FluentValidator;
using ModernStore.Domain.Commads.Results;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObject;
using ModernStore.Shared.Commands;
using System;
namespace ModernStore.Domain.Commads.Handlers
{
    public class CustomerCommadHandler : Notifiable,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommadHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        } 
        public ICommadResult Handle(RegisterCustomerCommand commad)
        {         
            //Verifica se o cpf já existe
            if(_customerRepository.DocumentExists(commad.Document))
            {
                AddNotification("Document", "Este CPF já está em uso");
                return null;                     
            }

            // Passo 2 Gerar novo Cliente
            var name = new Name(commad.FirstName, commad.LastName);
            var document = new Document(commad.Document);
            var email = new Email(commad.Email);
            var user = new User(commad.UserName, commad.Password, commad.ConfirmPassoword);
            var customer = new Customer(name, email, document, user);

            //Passo 3. Adicionando as notificações
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //Passo 4 Salve customer
            if (IsValid())
            {
                _customerRepository.Save(customer);
            }

            //Passo 5 Enviar email.
            _emailService.Send(customer.Name.ToString(), customer.Email.Address,
                string.Format(EmailTemplaites.WelcomeEmailTitle, customer.Name),
                string .Format(EmailTemplaites.WelcomeEmailBody,customer.Name));

            //Passo 6 Retornar algo.

            return new RegisterCustomerCommadResult(customer.Id, customer.Name.ToString());
        }
    }
}
