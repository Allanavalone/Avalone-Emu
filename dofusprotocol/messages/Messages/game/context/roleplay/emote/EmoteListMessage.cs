

// Generated on 02/17/2017 01:57:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class EmoteListMessage : Message
    {
        public const uint Id = 5689;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<sbyte> emoteIds;
        
        public EmoteListMessage()
        {
        }
        
        public EmoteListMessage(IEnumerable<sbyte> emoteIds)
        {
            this.emoteIds = emoteIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var emoteIds_before = writer.Position;
            var emoteIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in emoteIds)
            {
                 writer.WriteSByte(entry);
                 emoteIds_count++;
            }
            var emoteIds_after = writer.Position;
            writer.Seek((int)emoteIds_before);
            writer.WriteShort((short)emoteIds_count);
            writer.Seek((int)emoteIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var emoteIds_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 emoteIds_[i] = reader.ReadSByte();
                 if (emoteIds_[i] > 255)
                     throw new Exception("Forbidden value on emoteIds_[i] = " + emoteIds_[i] + ", it doesn't respect the following condition : emoteIds_[i] > 255");
            }
            emoteIds = emoteIds_;
        }
        
    }
    
}