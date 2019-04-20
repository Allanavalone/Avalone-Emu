

// Generated on 02/17/2017 01:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class QuestActiveDetailedInformations : QuestActiveInformations
    {
        public const short Id = 382;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short stepId;
        public IEnumerable<QuestObjectiveInformations> objectives;
        
        public QuestActiveDetailedInformations()
        {
        }
        
        public QuestActiveDetailedInformations(short questId, short stepId, IEnumerable<QuestObjectiveInformations> objectives)
         : base(questId)
        {
            this.stepId = stepId;
            this.objectives = objectives;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(stepId);
            var objectives_before = writer.Position;
            var objectives_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objectives)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 objectives_count++;
            }
            var objectives_after = writer.Position;
            writer.Seek((int)objectives_before);
            writer.WriteShort((short)objectives_count);
            writer.Seek((int)objectives_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            stepId = reader.ReadVarShort();
            if (stepId < 0)
                throw new Exception("Forbidden value on stepId = " + stepId + ", it doesn't respect the following condition : stepId < 0");
            var limit = reader.ReadShort();
            var objectives_ = new QuestObjectiveInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 objectives_[i] = Types.ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
                 objectives_[i].Deserialize(reader);
            }
            objectives = objectives_;
        }
        
        
    }
    
}