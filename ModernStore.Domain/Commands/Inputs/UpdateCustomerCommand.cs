using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Inputs
{
    public class UpdateCustomerCommand : ICommand
    {
        public Guid Customer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirtDate { get; set; }
    }
}
