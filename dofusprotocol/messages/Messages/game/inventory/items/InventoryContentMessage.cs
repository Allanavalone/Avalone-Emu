

// Generated on 02/17/2017 01:58:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryContentMessage : Message
    {
        public const uint Id = 3016;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ObjectItem> objects;
        public long kamas;
        
        public InventoryContentMessage()
        {
        }
        
        public InventoryContentMessage(IEnumerable<Types.ObjectItem> objects, long kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var objects_before = writer.Position;
            var objects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objects)
            {
                 entry.Serialize(writer);
                 objects_count++;
            }
            var objects_after = writer.Position;
            writer.Seek((int)objects_before);
            writer.WriteShort((short)objects_count);
            writer.Seek((int)objects_after);

            writer.WriteVarLong(kamas);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var objects_ = new Types.ObjectItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects_[i] = new Types.ObjectItem();
                 objects_[i].Deserialize(reader);
            }
            objects = objects_;
            kamas = reader.ReadVarLong();
            if (kamas < 0 || kamas > 9007199254740990)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0 || kamas > 9007199254740990");
        }
        
    }
    
}