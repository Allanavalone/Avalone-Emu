

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GuildFactSheetInformations : GuildInformations
    {
        public const short Id = 424;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public long leaderId;
        public short nbMembers;
        
        public GuildFactSheetInformations()
        {
        }
        
        public GuildFactSheetInformations(int guildId, string guildName, sbyte guildLevel, Types.GuildEmblem guildEmblem, long leaderId, short nbMembers)
         : base(guildId, guildName, guildLevel, guildEmblem)
        {
            this.leaderId = leaderId;
            this.nbMembers = nbMembers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(leaderId);
            writer.WriteVarShort(nbMembers);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            leaderId = reader.ReadVarLong();
            if (leaderId < 0 || leaderId > 9007199254740990)
                throw new Exception("Forbidden value on leaderId = " + leaderId + ", it doesn't respect the following condition : leaderId < 0 || leaderId > 9007199254740990");
            nbMembers = reader.ReadVarShort();
            if (nbMembers < 0)
                throw new Exception("Forbidden value on nbMembers = " + nbMembers + ", it doesn't respect the following condition : nbMembers < 0");
        }
        
        
    }
    
}