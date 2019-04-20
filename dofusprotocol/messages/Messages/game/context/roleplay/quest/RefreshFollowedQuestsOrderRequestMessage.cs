using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class RefreshFollowedQuestsOrderRequestMessage : Message
    {
        public const uint Id = 6722;
        public override uint MessageId
        {
            get { return Id; }
        }

        public IEnumerable<short> quests;

        public RefreshFollowedQuestsOrderRequestMessage()
        {
        }

        public RefreshFollowedQuestsOrderRequestMessage(IEnumerable<short> quests)
        {
            this.quests = quests;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt((int)quests.Count());
            foreach(var entry in quests)
            {
                writer.WriteVarShort(entry);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadVarInt();
            var quests_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                quests_[i] = reader.ReadVarShort();
            }
            quests = quests_;
        }

    }

}