using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage : GameRolePlayArenaUpdatePlayerInfosMessage
    {
        public const uint Id = 6728;
        public override uint MessageId
        {
            get { return Id; }
        }

        public ArenaRankInfos team;
        public ArenaRankInfos duel;

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage()
        {
        }

        public GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(ArenaRankInfos solo, ArenaRankInfos team, ArenaRankInfos duel)
         : base(solo)
        {
            this.team = team;
            this.duel = duel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            this.team.Serialize(writer);
            this.duel.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            this.team = new ArenaRankInfos();
            this.team.Deserialize(reader);
            this.duel = new ArenaRankInfos();
            this.duel.Deserialize(reader);
        }

    }
}