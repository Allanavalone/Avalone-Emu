

// Generated on 02/17/2017 01:58:17
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeOfflineSoldItemsMessage : Message
    {
        public const uint Id = 6613;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItemGenericQuantityPrice> bidHouseItems;
        public IEnumerable<Types.ObjectItemGenericQuantityPrice> merchantItems;
        
        public ExchangeOfflineSoldItemsMessage()
        {
        }
        
        public ExchangeOfflineSoldItemsMessage(IEnumerable<Types.ObjectItemGenericQuantityPrice> bidHouseItems, IEnumerable<Types.ObjectItemGenericQuantityPrice> merchantItems)
        {
            this.bidHouseItems = bidHouseItems;
            this.merchantItems = merchantItems;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var bidHouseItems_before = writer.Position;
            var bidHouseItems_count = 0;
            writer.WriteShort(0);
            foreach (var entry in bidHouseItems)
            {
                 entry.Serialize(writer);
                 bidHouseItems_count++;
            }
            var bidHouseItems_after = writer.Position;
            writer.Seek((int)bidHouseItems_before);
            writer.WriteShort((short)bidHouseItems_count);
            writer.Seek((int)bidHouseItems_after);

            var merchantItems_before = writer.Position;
            var merchantItems_count = 0;
            writer.WriteShort(0);
            foreach (var entry in merchantItems)
            {
                 entry.Serialize(writer);
                 merchantItems_count++;
            }
            var merchantItems_after = writer.Position;
            writer.Seek((int)merchantItems_before);
            writer.WriteShort((short)merchantItems_count);
            writer.Seek((int)merchantItems_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var bidHouseItems_ = new Types.ObjectItemGenericQuantityPrice[limit];
            for (int i = 0; i < limit; i++)
            {
                 bidHouseItems_[i] = new Types.ObjectItemGenericQuantityPrice();
                 bidHouseItems_[i].Deserialize(reader);
            }
            bidHouseItems = bidHouseItems_;
            limit = reader.ReadShort();
            var merchantItems_ = new Types.ObjectItemGenericQuantityPrice[limit];
            for (int i = 0; i < limit; i++)
            {
                 merchantItems_[i] = new Types.ObjectItemGenericQuantityPrice();
                 merchantItems_[i].Deserialize(reader);
            }
            merchantItems = merchantItems_;
        }
        
    }
    
}