using MessagePack;
using System;

namespace TCPServer
{
    //Union makes it possible to deserialize message as the abstract class (NetworkMessage), thus making it generic. 
    //It detemins on its own what message type it is, meaning it doesn't have to stated explicitly when deserializing sent messages
    [Union(0, typeof(OnConnectionMessage))]
    [Union(1, typeof(NameMessage))]
    [Union(2, typeof(StringMessage))]
    [Union(3, typeof(ExampleMessage))]
    public abstract class NetworkMessage { }

    [MessagePackObject]
    public class OnConnectionMessage : NetworkMessage
    {
        /// <summary>
        /// Unique id for each client, easier to reference specific client
        /// </summary>
        [Key(0)]
        public Guid ClientId { get; set; }
    }

    [MessagePackObject]
    public class NameMessage : NetworkMessage
    {
        /// <summary>
        /// Not necessary, but for visual indicators are names more readable
        /// </summary>
        [Key(0)]
        public string Name { get; set; }
    }

    [MessagePackObject]
    public class StringMessage : NetworkMessage
    {
        /// <summary>
        /// Not necessary, but for visual indicators are names more readable
        /// </summary>
        [Key(0)]
        public string Message { get; set; }
    }

    [MessagePackObject]
    public class ExampleMessage : NetworkMessage
    {
        [Key(0)]
        public string Message { get; set; }
    }
}
