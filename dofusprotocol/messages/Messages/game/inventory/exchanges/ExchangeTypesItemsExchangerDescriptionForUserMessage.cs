

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeTypesItemsExchangerDescriptionForUserMessage : Message
    {
        public const uint Id = 5752;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.BidExchangerObjectInfo> itemTypeDescriptions;
        
        public ExchangeTypesItemsExchangerDescriptionForUserMessage()
        {
        }
        
        public ExchangeTypesItemsExchangerDescriptionForUserMessage(IEnumerable<Types.BidExchangerObjectInfo> itemTypeDescriptions)
        {
            this.itemTypeDescriptions = itemTypeDescriptions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var itemTypeDescriptions_before = writer.Position;
            var itemTypeDescriptions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in itemTypeDescriptions)
            {
                 entry.Serialize(writer);
                 itemTypeDescriptions_count++;
            }
            var itemTypeDescriptions_after = writer.Position;
            writer.Seek((int)itemTypeDescriptions_before);
            writer.WriteShort((short)itemTypeDescriptions_count);
            writer.Seek((int)itemTypeDescriptions_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var itemTypeDescriptions_ = new Types.BidExchangerObjectInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 itemTypeDescriptions_[i] = new Types.BidExchangerObjectInfo();
                 itemTypeDescriptions_[i].Deserialize(reader);
            }
            itemTypeDescriptions = itemTypeDescriptions_;
        }
        
    }
    
}