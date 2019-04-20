

// Generated on 02/17/2017 01:58:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class FriendsListMessage : Message
    {
        public const uint Id = 4002;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<FriendInformations> friendsList;
        
        public FriendsListMessage()
        {
        }
        
        public FriendsListMessage(IEnumerable<FriendInformations> friendsList)
        {
            this.friendsList = friendsList;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var friendsList_before = writer.Position;
            var friendsList_count = 0;
            writer.WriteShort(0);
            foreach (var entry in friendsList)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 friendsList_count++;
            }
            var friendsList_after = writer.Position;
            writer.Seek((int)friendsList_before);
            writer.WriteShort((short)friendsList_count);
            writer.Seek((int)friendsList_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var friendsList_ = new FriendInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 friendsList_[i] = Types.ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
                 friendsList_[i].Deserialize(reader);
            }
            friendsList = friendsList_;
        }
        
    }
    
}