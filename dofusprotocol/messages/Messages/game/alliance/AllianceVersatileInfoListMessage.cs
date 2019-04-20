

// Generated on 02/17/2017 01:57:39
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceVersatileInfoListMessage : Message
    {
        public const uint Id = 6436;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.AllianceVersatileInformations> alliances;
        
        public AllianceVersatileInfoListMessage()
        {
        }
        
        public AllianceVersatileInfoListMessage(IEnumerable<Types.AllianceVersatileInformations> alliances)
        {
            this.alliances = alliances;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var alliances_before = writer.Position;
            var alliances_count = 0;
            writer.WriteShort(0);
            foreach (var entry in alliances)
            {
                 entry.Serialize(writer);
                 alliances_count++;
            }
            var alliances_after = writer.Position;
            writer.Seek((int)alliances_before);
            writer.WriteShort((short)alliances_count);
            writer.Seek((int)alliances_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var alliances_ = new Types.AllianceVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 alliances_[i] = new Types.AllianceVersatileInformations();
                 alliances_[i].Deserialize(reader);
            }
            alliances = alliances_;
        }
        
    }
    
}