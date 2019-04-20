

// Generated on 02/17/2017 01:57:50
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameDataPaddockObjectListAddMessage : Message
    {
        public const uint Id = 5992;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.PaddockItem> paddockItemDescription;
        
        public GameDataPaddockObjectListAddMessage()
        {
        }
        
        public GameDataPaddockObjectListAddMessage(IEnumerable<Types.PaddockItem> paddockItemDescription)
        {
            this.paddockItemDescription = paddockItemDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var paddockItemDescription_before = writer.Position;
            var paddockItemDescription_count = 0;
            writer.WriteShort(0);
            foreach (var entry in paddockItemDescription)
            {
                 entry.Serialize(writer);
                 paddockItemDescription_count++;
            }
            var paddockItemDescription_after = writer.Position;
            writer.Seek((int)paddockItemDescription_before);
            writer.WriteShort((short)paddockItemDescription_count);
            writer.Seek((int)paddockItemDescription_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var paddockItemDescription_ = new Types.PaddockItem[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddockItemDescription_[i] = new Types.PaddockItem();
                 paddockItemDescription_[i].Deserialize(reader);
            }
            paddockItemDescription = paddockItemDescription_;
        }
        
    }
    
}