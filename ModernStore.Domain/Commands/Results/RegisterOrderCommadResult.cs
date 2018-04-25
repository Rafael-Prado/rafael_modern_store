using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commads.Results
{
    public class RegisterOrderCommadResult: ICommadResult
    {
        public RegisterOrderCommadResult(){ }

        public RegisterOrderCommadResult(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
