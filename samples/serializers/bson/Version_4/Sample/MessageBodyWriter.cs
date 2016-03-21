﻿using System.Text;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.MessageMutator;

#region mutator
public class MessageBodyWriter : 
    IMutateIncomingTransportMessages
{
    static ILog log = LogManager.GetLogger(typeof(MessageBodyWriter));

    public void MutateIncoming(TransportMessage transportMessage)
    {
        string bodyAsString = Encoding.UTF8
            .GetString(transportMessage.Body);
        log.Info("Serialized Message Body:");
        log.Info(bodyAsString);
    }
}
#endregion