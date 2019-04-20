

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PrismsListMessage : Message
    {
        public const uint Id = 6440;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<PrismSubareaEmptyInfo> prisms;
        
        public PrismsListMessage()
        {
        }
        
        public PrismsListMessage(IEnumerable<PrismSubareaEmptyInfo> prisms)
        {
            this.prisms = prisms;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var prisms_before = writer.Position;
            var prisms_count = 0;
            writer.WriteShort(0);
            foreach (var entry in prisms)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 prisms_count++;
            }
            var prisms_after = writer.Position;
            writer.Seek((int)prisms_before);
            writer.WriteShort((short)prisms_count);
            writer.Seek((int)prisms_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var prisms_ = new PrismSubareaEmptyInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 prisms_[i] = Types.ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
                 prisms_[i].Deserialize(reader);
            }
            prisms = prisms_;
        }
        
    }
    
}