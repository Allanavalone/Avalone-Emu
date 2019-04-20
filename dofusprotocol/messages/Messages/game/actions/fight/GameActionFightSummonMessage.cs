

// Generated on 02/17/2017 01:57:37
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightSummonMessage : AbstractGameActionMessage
    {
        public const uint Id = 5825;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<GameFightFighterInformations> summons;
        
        public GameActionFightSummonMessage()
        {
        }
        
        public GameActionFightSummonMessage(short actionId, double sourceId, IEnumerable<GameFightFighterInformations> summons)
         : base(actionId, sourceId)
        {
            this.summons = summons;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var summons_before = writer.Position;
            var summons_count = 0;
            writer.WriteShort(0);
            foreach (var entry in summons)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 summons_count++;
            }
            var summons_after = writer.Position;
            writer.Seek((int)summons_before);
            writer.WriteShort((short)summons_count);
            writer.Seek((int)summons_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var summons_ = new GameFightFighterInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 summons_[i] = Types.ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
                 summons_[i].Deserialize(reader);
            }
            summons = summons_;
        }
        
    }
    
}