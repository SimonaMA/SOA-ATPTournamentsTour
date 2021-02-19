using System;
using System.Threading.Tasks;
using ATPTournamentsTour.Messages;
using Rebus.Handlers;

namespace ATPTournamentsTour.Payment
{
    public class NewOrderHandler : IHandleMessages<PaymentRequestMessage>
    {
        public Task Handle(PaymentRequestMessage message)
        {
            Console.WriteLine($"Payment request received for cart id {message.CartId}.");
            return Task.CompletedTask;
        }
    }
}
