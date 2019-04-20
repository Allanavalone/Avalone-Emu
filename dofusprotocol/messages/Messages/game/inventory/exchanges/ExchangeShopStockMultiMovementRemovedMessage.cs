

// Generated on 02/17/2017 01:58:18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeShopStockMultiMovementRemovedMessage : Message
    {
        public const uint Id = 6037;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> objectIdList;
        
        public ExchangeShopStockMultiMovementRemovedMessage()
        {
        }
        
        public ExchangeShopStockMultiMovementRemovedMessage(IEnumerable<int> objectIdList)
        {
            this.objectIdList = objectIdList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var objectIdList_before = writer.Position;
            var objectIdList_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objectIdList)
            {
                 writer.WriteVarInt(entry);
                 objectIdList_count++;
            }
            var objectIdList_after = writer.Position;
            writer.Seek((int)objectIdList_before);
            writer.WriteShort((short)objectIdList_count);
            writer.Seek((int)objectIdList_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var objectIdList_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectIdList_[i] = reader.ReadVarInt();
                 if (objectIdList_[i] < 0)
                     throw new Exception("Forbidden value on objectIdList_[i] = " + objectIdList_[i] + ", it doesn't respect the following condition : objectIdList_[i] < 0");
            }
            objectIdList = objectIdList_;
        }
        
    }
    
}