

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public const short Id = 423;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public string leaderName;
        public short nbConnectedMembers;
        public sbyte nbTaxCollectors;
        public int lastActivity;
        
        public GuildInsiderFactSheetInformations()
        {
        }
        
        public GuildInsiderFactSheetInformations(int guildId, string guildName, sbyte guildLevel, Types.GuildEmblem guildEmblem, long leaderId, short nbMembers, string leaderName, short nbConnectedMembers, sbyte nbTaxCollectors, int lastActivity)
         : base(guildId, guildName, guildLevel, guildEmblem, leaderId, nbMembers)
        {
            this.leaderName = leaderName;
            this.nbConnectedMembers = nbConnectedMembers;
            this.nbTaxCollectors = nbTaxCollectors;
            this.lastActivity = lastActivity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(leaderName);
            writer.WriteVarShort(nbConnectedMembers);
            writer.WriteSByte(nbTaxCollectors);
            writer.WriteInt(lastActivity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            leaderName = reader.ReadUTF();
            nbConnectedMembers = reader.ReadVarShort();
            if (nbConnectedMembers < 0)
                throw new Exception("Forbidden value on nbConnectedMembers = " + nbConnectedMembers + ", it doesn't respect the following condition : nbConnectedMembers < 0");
            nbTaxCollectors = reader.ReadSByte();
            if (nbTaxCollectors < 0)
                throw new Exception("Forbidden value on nbTaxCollectors = " + nbTaxCollectors + ", it doesn't respect the following condition : nbTaxCollectors < 0");
            lastActivity = reader.ReadInt();
            if (lastActivity < 0)
                throw new Exception("Forbidden value on lastActivity = " + lastActivity + ", it doesn't respect the following condition : lastActivity < 0");
        }
        
        
    }
    
}