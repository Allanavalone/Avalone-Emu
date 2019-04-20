

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GuildInAllianceInformations : GuildInformations
    {
        public const short Id = 420;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte nbMembers;
        
        public GuildInAllianceInformations()
        {
        }
        
        public GuildInAllianceInformations(int guildId, string guildName, sbyte guildLevel, Types.GuildEmblem guildEmblem, sbyte nbMembers)
         : base(guildId, guildName, guildLevel, guildEmblem)
        {
            this.nbMembers = nbMembers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(nbMembers);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            nbMembers = reader.ReadSByte();
            if (nbMembers < 1 || nbMembers > 240)
                throw new Exception("Forbidden value on nbMembers = " + nbMembers + ", it doesn't respect the following condition : nbMembers < 1 || nbMembers > 240");
        }
        
        
    }
    
}