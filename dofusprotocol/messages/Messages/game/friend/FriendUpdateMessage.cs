

// Generated on 02/17/2017 01:58:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FriendUpdateMessage : Message
    {
        public const uint Id = 5924;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public FriendInformations friendUpdated;
        
        public FriendUpdateMessage()
        {
        }
        
        public FriendUpdateMessage(FriendInformations friendUpdated)
        {
            this.friendUpdated = friendUpdated;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(friendUpdated.TypeId);
            friendUpdated.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            friendUpdated = Types.ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
            friendUpdated.Deserialize(reader);
        }
        
    }
    
}