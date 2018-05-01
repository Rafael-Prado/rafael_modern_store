
namespace ModernStore.Domain.Commands.Results
{
    public class GetCustomerCommadResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
    }
}
