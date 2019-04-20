

// Generated on 02/17/2017 01:58:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TeleportBuddiesRequestedMessage : Message
    {
        public const uint Id = 6302;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short dungeonId;
        public long inviterId;
        public IEnumerable<long> invalidBuddiesIds;
        
        public TeleportBuddiesRequestedMessage()
        {
        }
        
        public TeleportBuddiesRequestedMessage(short dungeonId, long inviterId, IEnumerable<long> invalidBuddiesIds)
        {
            this.dungeonId = dungeonId;
            this.inviterId = inviterId;
            this.invalidBuddiesIds = invalidBuddiesIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(dungeonId);
            writer.WriteVarLong(inviterId);
            var invalidBuddiesIds_before = writer.Position;
            var invalidBuddiesIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in invalidBuddiesIds)
            {
                 writer.WriteVarLong(entry);
                 invalidBuddiesIds_count++;
            }
            var invalidBuddiesIds_after = writer.Position;
            writer.Seek((int)invalidBuddiesIds_before);
            writer.WriteShort((short)invalidBuddiesIds_count);
            writer.Seek((int)invalidBuddiesIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            dungeonId = reader.ReadVarShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
            inviterId = reader.ReadVarLong();
            if (inviterId < 0 || inviterId > 9007199254740990)
                throw new Exception("Forbidden value on inviterId = " + inviterId + ", it doesn't respect the following condition : inviterId < 0 || inviterId > 9007199254740990");
            var limit = reader.ReadShort();
            var invalidBuddiesIds_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 invalidBuddiesIds_[i] = reader.ReadVarLong();
                 if (invalidBuddiesIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on invalidBuddiesIds_[i] = " + invalidBuddiesIds_[i] + ", it doesn't respect the following condition : invalidBuddiesIds_[i] > 9007199254740990");
            }
            invalidBuddiesIds = invalidBuddiesIds_;
        }
        
    }
    
}