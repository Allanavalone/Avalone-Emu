

// Generated on 02/17/2017 01:58:11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildVersatileInfoListMessage : Message
    {
        public const uint Id = 6435;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<GuildVersatileInformations> guilds;
        
        public GuildVersatileInfoListMessage()
        {
        }
        
        public GuildVersatileInfoListMessage(IEnumerable<GuildVersatileInformations> guilds)
        {
            this.guilds = guilds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var guilds_before = writer.Position;
            var guilds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in guilds)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 guilds_count++;
            }
            var guilds_after = writer.Position;
            writer.Seek((int)guilds_before);
            writer.WriteShort((short)guilds_count);
            writer.Seek((int)guilds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var guilds_ = new GuildVersatileInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 guilds_[i] = Types.ProtocolTypeManager.GetInstance<GuildVersatileInformations>(reader.ReadShort());
                 guilds_[i].Deserialize(reader);
            }
            guilds = guilds_;
        }
        
    }
    
}