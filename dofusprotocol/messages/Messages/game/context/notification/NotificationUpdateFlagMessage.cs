

// Generated on 02/17/2017 01:57:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class NotificationUpdateFlagMessage : Message
    {
        public const uint Id = 6090;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short index;
        
        public NotificationUpdateFlagMessage()
        {
        }
        
        public NotificationUpdateFlagMessage(short index)
        {
            this.index = index;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(index);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            index = reader.ReadVarShort();
            if (index < 0)
                throw new Exception("Forbidden value on index = " + index + ", it doesn't respect the following condition : index < 0");
        }
        
    }
    
}