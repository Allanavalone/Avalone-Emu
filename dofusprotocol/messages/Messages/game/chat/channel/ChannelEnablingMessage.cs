

// Generated on 02/17/2017 01:57:45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ChannelEnablingMessage : Message
    {
        public const uint Id = 890;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte channel;
        public bool enable;
        
        public ChannelEnablingMessage()
        {
        }
        
        public ChannelEnablingMessage(sbyte channel, bool enable)
        {
            this.channel = channel;
            this.enable = enable;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(channel);
            writer.WriteBoolean(enable);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            channel = reader.ReadSByte();
            enable = reader.ReadBoolean();
        }
        
    }
    
}