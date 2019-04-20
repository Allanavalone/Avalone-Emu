

// Generated on 02/17/2017 01:58:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartsListMessage : Message
    {
        public const uint Id = 1502;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.ContentPart> parts;
        
        public PartsListMessage()
        {
        }
        
        public PartsListMessage(IEnumerable<Types.ContentPart> parts)
        {
            this.parts = parts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var parts_before = writer.Position;
            var parts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in parts)
            {
                 entry.Serialize(writer);
                 parts_count++;
            }
            var parts_after = writer.Position;
            writer.Seek((int)parts_before);
            writer.WriteShort((short)parts_count);
            writer.Seek((int)parts_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var parts_ = new Types.ContentPart[limit];
            for (int i = 0; i < limit; i++)
            {
                 parts_[i] = new Types.ContentPart();
                 parts_[i].Deserialize(reader);
            }
            parts = parts_;
        }
        
    }
    
}