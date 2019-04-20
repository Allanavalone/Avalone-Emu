

// Generated on 02/17/2017 01:58:09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildInformationsMembersMessage : Message
    {
        public const uint Id = 5558;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.GuildMember> members;
        
        public GuildInformationsMembersMessage()
        {
        }
        
        public GuildInformationsMembersMessage(IEnumerable<Types.GuildMember> members)
        {
            this.members = members;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var members_before = writer.Position;
            var members_count = 0;
            writer.WriteShort(0);
            foreach (var entry in members)
            {
                 entry.Serialize(writer);
                 members_count++;
            }
            var members_after = writer.Position;
            writer.Seek((int)members_before);
            writer.WriteShort((short)members_count);
            writer.Seek((int)members_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var members_ = new Types.GuildMember[limit];
            for (int i = 0; i < limit; i++)
            {
                 members_[i] = new Types.GuildMember();
                 members_[i].Deserialize(reader);
            }
            members = members_;
        }
        
    }
    
}