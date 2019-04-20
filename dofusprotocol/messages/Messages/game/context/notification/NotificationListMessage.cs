

// Generated on 02/17/2017 01:57:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class NotificationListMessage : Message
    {
        public const uint Id = 6087;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> flags;
        
        public NotificationListMessage()
        {
        }
        
        public NotificationListMessage(IEnumerable<int> flags)
        {
            this.flags = flags;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var flags_before = writer.Position;
            var flags_count = 0;
            writer.WriteShort(0);
            foreach (var entry in flags)
            {
                 writer.WriteVarInt(entry);
                 flags_count++;
            }
            var flags_after = writer.Position;
            writer.Seek((int)flags_before);
            writer.WriteShort((short)flags_count);
            writer.Seek((int)flags_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var flags_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 flags_[i] = reader.ReadVarInt();
            }
            flags = flags_;
        }
        
    }
    
}