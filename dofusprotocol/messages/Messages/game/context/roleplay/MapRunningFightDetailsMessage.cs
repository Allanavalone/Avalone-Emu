

// Generated on 02/17/2017 01:57:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MapRunningFightDetailsMessage : Message
    {
        public const uint Id = 5751;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int fightId;
        public IEnumerable<GameFightFighterLightInformations> attackers;
        public IEnumerable<GameFightFighterLightInformations> defenders;
        
        public MapRunningFightDetailsMessage()
        {
        }
        
        public MapRunningFightDetailsMessage(int fightId, IEnumerable<GameFightFighterLightInformations> attackers, IEnumerable<GameFightFighterLightInformations> defenders)
        {
            this.fightId = fightId;
            this.attackers = attackers;
            this.defenders = defenders;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            var attackers_before = writer.Position;
            var attackers_count = 0;
            writer.WriteShort(0);
            foreach (var entry in attackers)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 attackers_count++;
            }
            var attackers_after = writer.Position;
            writer.Seek((int)attackers_before);
            writer.WriteShort((short)attackers_count);
            writer.Seek((int)attackers_after);

            var defenders_before = writer.Position;
            var defenders_count = 0;
            writer.WriteShort(0);
            foreach (var entry in defenders)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 defenders_count++;
            }
            var defenders_after = writer.Position;
            writer.Seek((int)defenders_before);
            writer.WriteShort((short)defenders_count);
            writer.Seek((int)defenders_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            if (fightId < 0)
                throw new Exception("Forbidden value on fightId = " + fightId + ", it doesn't respect the following condition : fightId < 0");
            var limit = reader.ReadShort();
            var attackers_ = new GameFightFighterLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 attackers_[i] = Types.ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
                 attackers_[i].Deserialize(reader);
            }
            attackers = attackers_;
            limit = reader.ReadShort();
            var defenders_ = new GameFightFighterLightInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 defenders_[i] = Types.ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
                 defenders_[i].Deserialize(reader);
            }
            defenders = defenders_;
        }
        
    }
    
}