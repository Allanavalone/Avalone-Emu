using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidPriceMessage : Message
    {
        public const uint Id = 5755;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short genericId;
        public long averagePrice;
        
        public ExchangeBidPriceMessage()
        {
        }
        
        public ExchangeBidPriceMessage(short genericId, long averagePrice)
        {
            this.genericId = genericId;
            this.averagePrice = averagePrice;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(genericId);
            writer.WriteVarLong(averagePrice);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            genericId = reader.ReadVarShort();
            if (genericId < 0)
                throw new Exception("Forbidden value on genericId = " + genericId + ", it doesn't respect the following condition : genericId < 0");
            averagePrice = reader.ReadVarLong();
            if (averagePrice < -9007199254740992 || averagePrice > 9007199254740992)
                throw new Exception("Forbidden value on averagePrice = " + averagePrice + ", it doesn't respect the following condition : averagePrice < -9007199254740992 || averagePrice > 9007199254740990");
        }
    }
}