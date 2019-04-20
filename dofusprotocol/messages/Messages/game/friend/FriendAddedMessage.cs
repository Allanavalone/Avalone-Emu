

// Generated on 02/17/2017 01:58:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FriendAddedMessage : Message
    {
        public const uint Id = 5599;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public FriendInformations friendAdded;
        
        public FriendAddedMessage()
        {
        }
        
        public FriendAddedMessage(FriendInformations friendAdded)
        {
            this.friendAdded = friendAdded;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(friendAdded.TypeId);
            friendAdded.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            friendAdded = Types.ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
            friendAdded.Deserialize(reader);
        }
        
    }
    
}