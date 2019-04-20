

// Generated on 02/17/2017 01:58:16
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeMountsPaddockRemoveMessage : Message
    {
        public const uint Id = 6559;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> mountsId;
        
        public ExchangeMountsPaddockRemoveMessage()
        {
        }
        
        public ExchangeMountsPaddockRemoveMessage(IEnumerable<int> mountsId)
        {
            this.mountsId = mountsId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var mountsId_before = writer.Position;
            var mountsId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in mountsId)
            {
                 writer.WriteVarInt(entry);
                 mountsId_count++;
            }
            var mountsId_after = writer.Position;
            writer.Seek((int)mountsId_before);
            writer.WriteShort((short)mountsId_count);
            writer.Seek((int)mountsId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var mountsId_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 mountsId_[i] = reader.ReadVarInt();
            }
            mountsId = mountsId_;
        }
        
    }
    
}