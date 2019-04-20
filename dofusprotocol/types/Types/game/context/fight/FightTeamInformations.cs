

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTeamInformations : AbstractFightTeamInformations
    {
        public const short Id = 33;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<FightTeamMemberInformations> teamMembers;
        
        public FightTeamInformations()
        {
        }
        
        public FightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves, IEnumerable<FightTeamMemberInformations> teamMembers)
         : base(teamId, leaderId, teamSide, teamTypeId, nbWaves)
        {
            this.teamMembers = teamMembers;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var teamMembers_before = writer.Position;
            var teamMembers_count = 0;
            writer.WriteShort(0);
            foreach (var entry in teamMembers)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 teamMembers_count++;
            }
            var teamMembers_after = writer.Position;
            writer.Seek((int)teamMembers_before);
            writer.WriteShort((short)teamMembers_count);
            writer.Seek((int)teamMembers_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var teamMembers_ = new FightTeamMemberInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 teamMembers_[i] = Types.ProtocolTypeManager.GetInstance<FightTeamMemberInformations>(reader.ReadShort());
                 teamMembers_[i].Deserialize(reader);
            }
            teamMembers = teamMembers_;
        }
        
        
    }
    
}