

// Generated on 02/17/2017 01:58:17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeOkMultiCraftMessage : Message
    {
        public const uint Id = 5768;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long initiatorId;
        public long otherId;
        public sbyte role;
        
        public ExchangeOkMultiCraftMessage()
        {
        }
        
        public ExchangeOkMultiCraftMessage(long initiatorId, long otherId, sbyte role)
        {
            this.initiatorId = initiatorId;
            this.otherId = otherId;
            this.role = role;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(initiatorId);
            writer.WriteVarLong(otherId);
            writer.WriteSByte(role);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            initiatorId = reader.ReadVarLong();
            if (initiatorId < 0 || initiatorId > 9007199254740990)
                throw new Exception("Forbidden value on initiatorId = " + initiatorId + ", it doesn't respect the following condition : initiatorId < 0 || initiatorId > 9007199254740990");
            otherId = reader.ReadVarLong();
            if (otherId < 0 || otherId > 9007199254740990)
                throw new Exception("Forbidden value on otherId = " + otherId + ", it doesn't respect the following condition : otherId < 0 || otherId > 9007199254740990");
            role = reader.ReadSByte();
        }
        
    }
    
}