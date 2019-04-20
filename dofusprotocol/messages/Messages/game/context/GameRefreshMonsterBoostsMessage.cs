

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRefreshMonsterBoostsMessage : Message
    {
        public const uint Id = 6618;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.MonsterBoosts> monsterBoosts;
        public IEnumerable<Types.MonsterBoosts> familyBoosts;
        
        public GameRefreshMonsterBoostsMessage()
        {
        }
        
        public GameRefreshMonsterBoostsMessage(IEnumerable<Types.MonsterBoosts> monsterBoosts, IEnumerable<Types.MonsterBoosts> familyBoosts)
        {
            this.monsterBoosts = monsterBoosts;
            this.familyBoosts = familyBoosts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var monsterBoosts_before = writer.Position;
            var monsterBoosts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in monsterBoosts)
            {
                 entry.Serialize(writer);
                 monsterBoosts_count++;
            }
            var monsterBoosts_after = writer.Position;
            writer.Seek((int)monsterBoosts_before);
            writer.WriteShort((short)monsterBoosts_count);
            writer.Seek((int)monsterBoosts_after);

            var familyBoosts_before = writer.Position;
            var familyBoosts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in familyBoosts)
            {
                 entry.Serialize(writer);
                 familyBoosts_count++;
            }
            var familyBoosts_after = writer.Position;
            writer.Seek((int)familyBoosts_before);
            writer.WriteShort((short)familyBoosts_count);
            writer.Seek((int)familyBoosts_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var monsterBoosts_ = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 monsterBoosts_[i] = new Types.MonsterBoosts();
                 monsterBoosts_[i].Deserialize(reader);
            }
            monsterBoosts = monsterBoosts_;
            limit = reader.ReadShort();
            var familyBoosts_ = new Types.MonsterBoosts[limit];
            for (int i = 0; i < limit; i++)
            {
                 familyBoosts_[i] = new Types.MonsterBoosts();
                 familyBoosts_[i].Deserialize(reader);
            }
            familyBoosts = familyBoosts_;
        }
        
    }
    
}