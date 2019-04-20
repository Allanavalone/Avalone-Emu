

// Generated on 02/17/2017 01:58:18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeShopStockStartedMessage : Message
    {
        public const uint Id = 5910;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItemToSell> objectsInfos;
        
        public ExchangeShopStockStartedMessage()
        {
        }
        
        public ExchangeShopStockStartedMessage(IEnumerable<Types.ObjectItemToSell> objectsInfos)
        {
            this.objectsInfos = objectsInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var objectsInfos_before = writer.Position;
            var objectsInfos_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objectsInfos)
            {
                 entry.Serialize(writer);
                 objectsInfos_count++;
            }
            var objectsInfos_after = writer.Position;
            writer.Seek((int)objectsInfos_before);
            writer.WriteShort((short)objectsInfos_count);
            writer.Seek((int)objectsInfos_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var objectsInfos_ = new Types.ObjectItemToSell[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos_[i] = new Types.ObjectItemToSell();
                 objectsInfos_[i].Deserialize(reader);
            }
            objectsInfos = objectsInfos_;
        }
        
    }
    
}