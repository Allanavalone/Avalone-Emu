

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DareRewardsListMessage : Message
    {
        public const uint Id = 6677;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.DareReward> rewards;
        
        public DareRewardsListMessage()
        {
        }
        
        public DareRewardsListMessage(IEnumerable<Types.DareReward> rewards)
        {
            this.rewards = rewards;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var rewards_before = writer.Position;
            var rewards_count = 0;
            writer.WriteShort(0);
            foreach (var entry in rewards)
            {
                 entry.Serialize(writer);
                 rewards_count++;
            }
            var rewards_after = writer.Position;
            writer.Seek((int)rewards_before);
            writer.WriteShort((short)rewards_count);
            writer.Seek((int)rewards_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var rewards_ = new Types.DareReward[limit];
            for (int i = 0; i < limit; i++)
            {
                 rewards_[i] = new Types.DareReward();
                 rewards_[i].Deserialize(reader);
            }
            rewards = rewards_;
        }
        
    }
    
}