

// Generated on 02/17/2017 01:57:48
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightSpectatorJoinMessage : GameFightJoinMessage
    {
        public const uint Id = 6504;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.NamedPartyTeam> namedPartyTeams;
        
        public GameFightSpectatorJoinMessage()
        {
        }
        
        public GameFightSpectatorJoinMessage(bool isTeamPhase, bool canBeCancelled, bool canSayReady, bool isFightStarted, short timeMaxBeforeFightStart, sbyte fightType, IEnumerable<Types.NamedPartyTeam> namedPartyTeams)
         : base(isTeamPhase, canBeCancelled, canSayReady, isFightStarted, timeMaxBeforeFightStart, fightType)
        {
            this.namedPartyTeams = namedPartyTeams;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var namedPartyTeams_before = writer.Position;
            var namedPartyTeams_count = 0;
            writer.WriteShort(0);
            foreach (var entry in namedPartyTeams)
            {
                 entry.Serialize(writer);
                 namedPartyTeams_count++;
            }
            var namedPartyTeams_after = writer.Position;
            writer.Seek((int)namedPartyTeams_before);
            writer.WriteShort((short)namedPartyTeams_count);
            writer.Seek((int)namedPartyTeams_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var namedPartyTeams_ = new Types.NamedPartyTeam[limit];
            for (int i = 0; i < limit; i++)
            {
                 namedPartyTeams_[i] = new Types.NamedPartyTeam();
                 namedPartyTeams_[i].Deserialize(reader);
            }
            namedPartyTeams = namedPartyTeams_;
        }
        
    }
    
}