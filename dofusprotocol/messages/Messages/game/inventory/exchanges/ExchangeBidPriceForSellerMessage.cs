

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeBidPriceForSellerMessage : ExchangeBidPriceMessage
    {
        public const uint Id = 6464;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool allIdentical;
        public IEnumerable<long> minimalPrices;
        
        public ExchangeBidPriceForSellerMessage()
        {
        }
        
        public ExchangeBidPriceForSellerMessage(short genericId, long averagePrice, bool allIdentical, IEnumerable<long> minimalPrices)
         : base(genericId, averagePrice)
        {
            this.allIdentical = allIdentical;
            this.minimalPrices = minimalPrices;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(allIdentical);
            var minimalPrices_before = writer.Position;
            var minimalPrices_count = 0;
            writer.WriteShort(0);
            foreach (var entry in minimalPrices)
            {
                 writer.WriteVarLong(entry);
                 minimalPrices_count++;
            }
            var minimalPrices_after = writer.Position;
            writer.Seek((int)minimalPrices_before);
            writer.WriteShort((short)minimalPrices_count);
            writer.Seek((int)minimalPrices_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            allIdentical = reader.ReadBoolean();
            var limit = reader.ReadShort();
            var minimalPrices_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 minimalPrices_[i] = reader.ReadVarLong();
                 if (minimalPrices_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on minimalPrices_[i] = " + minimalPrices_[i] + ", it doesn't respect the following condition : minimalPrices_[i] > 9007199254740990");
            }
            minimalPrices = minimalPrices_;
        }
        
    }
    
}