

// Generated on 02/17/2017 01:58:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyInvitationDungeonMessage : PartyInvitationMessage
    {
        public const uint Id = 6244;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short dungeonId;
        
        public PartyInvitationDungeonMessage()
        {
        }
        
        public PartyInvitationDungeonMessage(int partyId, sbyte partyType, string partyName, sbyte maxParticipants, long fromId, string fromName, long toId, short dungeonId)
         : base(partyId, partyType, partyName, maxParticipants, fromId, fromName, toId)
        {
            this.dungeonId = dungeonId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(dungeonId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            dungeonId = reader.ReadVarShort();
            if (dungeonId < 0)
                throw new Exception("Forbidden value on dungeonId = " + dungeonId + ", it doesn't respect the following condition : dungeonId < 0");
        }
        
    }
    
}