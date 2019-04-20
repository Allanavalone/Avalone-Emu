using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class UnfollowQuestObjectiveRequestMessage : Message
    {
        public const uint Id = 6723;
        public override uint MessageId
        {
            get { return Id; }
        }

        public short questId;
        public short objectiveId;

        public UnfollowQuestObjectiveRequestMessage()
        {
        }

        public UnfollowQuestObjectiveRequestMessage(short questId, short objectiveId)
        {
            this.questId = questId;
            this.objectiveId = objectiveId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(this.questId);
            writer.WriteShort(this.objectiveId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.questId = reader.ReadVarShort();
            if (this.questId < 0)
                throw new Exception("Forbidden value on questId = " + questId + ", it doesn't respect the following condition : questId < 0");
            this.objectiveId = reader.ReadShort();
        }
    }
}