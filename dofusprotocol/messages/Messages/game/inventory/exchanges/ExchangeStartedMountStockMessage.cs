

// Generated on 02/17/2017 01:58:18
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeStartedMountStockMessage : Message
    {
        public const uint Id = 5984;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItem> objectsInfos;
        
        public ExchangeStartedMountStockMessage()
        {
        }
        
        public ExchangeStartedMountStockMessage(IEnumerable<Types.ObjectItem> objectsInfos)
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
            var objectsInfos_ = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectsInfos_[i] = new Types.ObjectItem();
                 objectsInfos_[i].Deserialize(reader);
            }
            objectsInfos = objectsInfos_;
        }
        
    }
    
}