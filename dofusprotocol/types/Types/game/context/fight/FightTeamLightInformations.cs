

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        public const short Id = 115;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool hasFriend;
        public bool hasGuildMember;
        public bool hasAllianceMember;
        public bool hasGroupMember;
        public bool hasMyTaxCollector;
        public sbyte teamMembersCount;
        public int meanLevel;
        
        public FightTeamLightInformations()
        {
        }
        
        public FightTeamLightInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, bool hasFriend, bool hasGuildMember, bool hasAllianceMember, bool hasGroupMember, bool hasMyTaxCollector, sbyte teamMembersCount, int meanLevel)
         : base(teamId, leaderId, teamSide, teamTypeId, nbWaves)
        {
            this.hasFriend = hasFriend;
            this.hasGuildMember = hasGuildMember;
            this.hasAllianceMember = hasAllianceMember;
            this.hasGroupMember = hasGroupMember;
            this.hasMyTaxCollector = hasMyTaxCollector;
            this.teamMembersCount = teamMembersCount;
            this.meanLevel = meanLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            byte flag1 = 0;
            flag1 = BooleanByteWrapper.SetFlag(flag1, 0, hasFriend);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 1, hasGuildMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 2, hasAllianceMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 3, hasGroupMember);
            flag1 = BooleanByteWrapper.SetFlag(flag1, 4, hasMyTaxCollector);
            writer.WriteByte(flag1);
            writer.WriteSByte(teamMembersCount);
            writer.WriteVarInt(meanLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            byte flag1 = reader.ReadByte();
            hasFriend = BooleanByteWrapper.GetFlag(flag1, 0);
            hasGuildMember = BooleanByteWrapper.GetFlag(flag1, 1);
            hasAllianceMember = BooleanByteWrapper.GetFlag(flag1, 2);
            hasGroupMember = BooleanByteWrapper.GetFlag(flag1, 3);
            hasMyTaxCollector = BooleanByteWrapper.GetFlag(flag1, 4);
            teamMembersCount = reader.ReadSByte();
            if (teamMembersCount < 0)
                throw new Exception("Forbidden value on teamMembersCount = " + teamMembersCount + ", it doesn't respect the following condition : teamMembersCount < 0");
            meanLevel = reader.ReadVarInt();
            if (meanLevel < 0)
                throw new Exception("Forbidden value on meanLevel = " + meanLevel + ", it doesn't respect the following condition : meanLevel < 0");
        }
        
        
    }
    
}