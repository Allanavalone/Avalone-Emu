

// Generated on 02/17/2017 01:58:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class QuestListMessage : Message
    {
        public const uint Id = 5626;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> finishedQuestsIds;
        public IEnumerable<short> finishedQuestsCounts;
        public IEnumerable<QuestActiveInformations> activeQuests;
        public IEnumerable<short> reinitDoneQuestsIds;
        
        public QuestListMessage()
        {
        }
        
        public QuestListMessage(IEnumerable<short> finishedQuestsIds, IEnumerable<short> finishedQuestsCounts, IEnumerable<QuestActiveInformations> activeQuests, IEnumerable<short> reinitDoneQuestsIds)
        {
            this.finishedQuestsIds = finishedQuestsIds;
            this.finishedQuestsCounts = finishedQuestsCounts;
            this.activeQuests = activeQuests;
            this.reinitDoneQuestsIds = reinitDoneQuestsIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var finishedQuestsIds_before = writer.Position;
            var finishedQuestsIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in finishedQuestsIds)
            {
                 writer.WriteVarShort(entry);
                 finishedQuestsIds_count++;
            }
            var finishedQuestsIds_after = writer.Position;
            writer.Seek((int)finishedQuestsIds_before);
            writer.WriteShort((short)finishedQuestsIds_count);
            writer.Seek((int)finishedQuestsIds_after);

            var finishedQuestsCounts_before = writer.Position;
            var finishedQuestsCounts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in finishedQuestsCounts)
            {
                 writer.WriteVarShort(entry);
                 finishedQuestsCounts_count++;
            }
            var finishedQuestsCounts_after = writer.Position;
            writer.Seek((int)finishedQuestsCounts_before);
            writer.WriteShort((short)finishedQuestsCounts_count);
            writer.Seek((int)finishedQuestsCounts_after);

            var activeQuests_before = writer.Position;
            var activeQuests_count = 0;
            writer.WriteShort(0);
            foreach (var entry in activeQuests)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 activeQuests_count++;
            }
            var activeQuests_after = writer.Position;
            writer.Seek((int)activeQuests_before);
            writer.WriteShort((short)activeQuests_count);
            writer.Seek((int)activeQuests_after);

            var reinitDoneQuestsIds_before = writer.Position;
            var reinitDoneQuestsIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in reinitDoneQuestsIds)
            {
                 writer.WriteVarShort(entry);
                 reinitDoneQuestsIds_count++;
            }
            var reinitDoneQuestsIds_after = writer.Position;
            writer.Seek((int)reinitDoneQuestsIds_before);
            writer.WriteShort((short)reinitDoneQuestsIds_count);
            writer.Seek((int)reinitDoneQuestsIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var finishedQuestsIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedQuestsIds_[i] = reader.ReadVarShort();
                 if (finishedQuestsIds_[i] < 0)
                     throw new Exception("Forbidden value on finishedQuestsIds_[i] = " + finishedQuestsIds_[i] + ", it doesn't respect the following condition : finishedQuestsIds_[i] < 0");
            }
            finishedQuestsIds = finishedQuestsIds_;
            limit = reader.ReadShort();
            var finishedQuestsCounts_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 finishedQuestsCounts_[i] = reader.ReadVarShort();
                 if (finishedQuestsCounts_[i] < 0)
                     throw new Exception("Forbidden value on finishedQuestsCounts_[i] = " + finishedQuestsCounts_[i] + ", it doesn't respect the following condition : finishedQuestsCounts_[i] < 0");
            }
            finishedQuestsCounts = finishedQuestsCounts_;
            limit = reader.ReadShort();
            var activeQuests_ = new QuestActiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 activeQuests_[i] = Types.ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
                 activeQuests_[i].Deserialize(reader);
            }
            activeQuests = activeQuests_;
            limit = reader.ReadShort();
            var reinitDoneQuestsIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 reinitDoneQuestsIds_[i] = reader.ReadVarShort();
                 if (reinitDoneQuestsIds_[i] < 0)
                     throw new Exception("Forbidden value on reinitDoneQuestsIds_[i] = " + reinitDoneQuestsIds_[i] + ", it doesn't respect the following condition : reinitDoneQuestsIds_[i] < 0");
            }
            reinitDoneQuestsIds = reinitDoneQuestsIds_;
        }
        
    }
    
}