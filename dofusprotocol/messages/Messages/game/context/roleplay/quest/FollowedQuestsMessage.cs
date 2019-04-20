

// Generated on 02/17/2017 01:58:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FollowedQuestsMessage : Message
    {
        public const uint Id = 6717;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.QuestActiveDetailedInformations> quests;
        
        public FollowedQuestsMessage()
        {
        }
        
        public FollowedQuestsMessage(IEnumerable<Types.QuestActiveDetailedInformations> quests)
        {
            this.quests = quests;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var quests_before = writer.Position;
            var quests_count = 0;
            writer.WriteShort(0);
            foreach (var entry in quests)
            {
                 entry.Serialize(writer);
                 quests_count++;
            }
            var quests_after = writer.Position;
            writer.Seek((int)quests_before);
            writer.WriteShort((short)quests_count);
            writer.Seek((int)quests_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var quests_ = new Types.QuestActiveDetailedInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 quests_[i] = new Types.QuestActiveDetailedInformations();
                 quests_[i].Deserialize(reader);
            }
            quests = quests_;
        }
        
    }
    
}