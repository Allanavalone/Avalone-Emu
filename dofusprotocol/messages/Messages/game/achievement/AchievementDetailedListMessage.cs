

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AchievementDetailedListMessage : Message
    {
        public const uint Id = 6358;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.Achievement> startedAchievements;
        public IEnumerable<Types.Achievement> finishedAchievements;
        
        public AchievementDetailedListMessage()
        {
        }
        
        public AchievementDetailedListMessage(IEnumerable<Types.Achievement> startedAchievements, IEnumerable<Types.Achievement> finishedAchievements)
        {
            this.startedAchievements = startedAchievements;
            this.finishedAchievements = finishedAchievements;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var startedAchievements_before = writer.Position;
            var startedAchievements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in startedAchievements)
            {
                 entry.Serialize(writer);
                 startedAchievements_count++;
            }
            var startedAchievements_after = writer.Position;
            writer.Seek((int)startedAchievements_before);
            writer.WriteShort((short)startedAchievements_count);
            writer.Seek((int)startedAchievements_after);

            var finishedAchievements_before = writer.Position;
            var finishedAchievements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in finishedAchievements)
            {
                 entry.Serialize(writer);
                 finishedAchievements_count++;
            }
            var finishedAchievements_after = writer.Position;
            writer.Seek((int)finishedAchievements_before);
            writer.WriteShort((short)finishedAchievements_count);
            writer.Seek((int)finishedAchievements_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var startedAchievements_ = new Types.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                 startedAchievements_[i] = new Types.Achievement();
                 startedAchievements_[i].Deserialize(reader);
            }
            startedAchievements = startedAchievements_;
            limit = reader.ReadShort();
            var finishedAchievements_ = new Types.Achievement[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedAchievements_[i] = new Types.Achievement();
                 finishedAchievements_[i].Deserialize(reader);
            }
            finishedAchievements = finishedAchievements_;
        }
        
    }
    
}