using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ChatCommunityChannelSetCommunityRequestMessage : Message
    {
        public const uint Id = 6729;
        public override uint MessageId
        {
            get { return Id; }
        }

        public short communityId;

        public ChatCommunityChannelSetCommunityRequestMessage()
        {
        }

        public ChatCommunityChannelSetCommunityRequestMessage(short communityId)
        {
            this.communityId = communityId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(this.communityId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.communityId = reader.ReadShort();
        }

    }

}