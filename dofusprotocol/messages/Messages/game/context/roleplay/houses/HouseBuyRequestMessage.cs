

// Generated on 02/17/2017 01:57:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HouseBuyRequestMessage : Message
    {
        public const uint Id = 5738;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long proposedPrice;
        
        public HouseBuyRequestMessage()
        {
        }
        
        public HouseBuyRequestMessage(long proposedPrice)
        {
            this.proposedPrice = proposedPrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(proposedPrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            proposedPrice = reader.ReadVarLong();
            if (proposedPrice < 0 || proposedPrice > 9007199254740990)
                throw new Exception("Forbidden value on proposedPrice = " + proposedPrice + ", it doesn't respect the following condition : proposedPrice < 0 || proposedPrice > 9007199254740990");
        }
        
    }
    
}