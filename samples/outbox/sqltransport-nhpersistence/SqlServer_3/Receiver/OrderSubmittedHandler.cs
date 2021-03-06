using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class OrderSubmittedHandler :
    IHandleMessages<OrderSubmitted>
{
    static ILog log = LogManager.GetLogger<OrderSubmittedHandler>();
    static Random ChaosGenerator = new Random();

    public async Task Handle(OrderSubmitted message, IMessageHandlerContext context)
    {
        log.Info($"Order {message.OrderId} worth {message.Value} submitted");

        #region StoreUserData

        var nhibernateSession = context.SynchronizedStorageSession.Session();
        var order = new Order
        {
            OrderId = message.OrderId,
            Value = message.Value
        };
        nhibernateSession.Save(order);

        #endregion

        #region Reply

        var orderAccepted = new OrderAccepted
        {
            OrderId = message.OrderId,
        };
        await context.Reply(orderAccepted)
            .ConfigureAwait(false);

        #endregion

        if (ChaosGenerator.Next(2) == 0)
        {
            throw new Exception("Boom!");
        }
    }
}