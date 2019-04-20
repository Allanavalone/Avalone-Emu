

// Generated on 02/17/2017 01:57:44
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ChatClientMultiMessage : ChatAbstractClientMessage
    {
        public const uint Id = 861;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte channel;
        
        public ChatClientMultiMessage()
        {
        }
        
        public ChatClientMultiMessage(string content, sbyte channel)
         : base(content)
        {
            this.channel = channel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(channel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            channel = reader.ReadSByte();
        }
        
    }
    
}