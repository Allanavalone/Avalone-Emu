

// Generated on 02/17/2017 01:57:34
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AbstractGameActionWithAckMessage : AbstractGameActionMessage
    {
        public const uint Id = 1001;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short waitAckId;
        
        public AbstractGameActionWithAckMessage()
        {
        }
        
        public AbstractGameActionWithAckMessage(short actionId, double sourceId, short waitAckId)
         : base(actionId, sourceId)
        {
            this.waitAckId = waitAckId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(waitAckId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            waitAckId = reader.ReadShort();
        }
        
    }
    
}