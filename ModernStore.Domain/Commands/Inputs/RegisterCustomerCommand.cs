﻿using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class RegisterCustomerCommand: ICommad
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassoword { get; set; }

    }
}
