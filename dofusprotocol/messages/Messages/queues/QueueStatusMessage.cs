

// Generated on 02/17/2017 01:58:28
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class QueueStatusMessage : Message
    {
        public const uint Id = 6100;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short position;
        public short total;
        
        public QueueStatusMessage()
        {
        }
        
        public QueueStatusMessage(short position, short total)
        {
            this.position = position;
            this.total = total;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(position);
            writer.WriteShort(total);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            position = reader.ReadShort();
            if (position < 0 || position > 65535)
                throw new Exception("Forbidden value on position = " + position + ", it doesn't respect the following condition : position < 0 || position > 65535");
            total = reader.ReadShort();
            if (total < 0 || total > 65535)
                throw new Exception("Forbidden value on total = " + total + ", it doesn't respect the following condition : total < 0 || total > 65535");
        }
        
    }
    
}