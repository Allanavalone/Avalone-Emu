

// Generated on 02/17/2017 01:58:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyMemberRemoveMessage : AbstractPartyEventMessage
    {
        public const uint Id = 5579;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long leavingPlayerId;
        
        public PartyMemberRemoveMessage()
        {
        }
        
        public PartyMemberRemoveMessage(int partyId, long leavingPlayerId)
         : base(partyId)
        {
            this.leavingPlayerId = leavingPlayerId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(leavingPlayerId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            leavingPlayerId = reader.ReadVarLong();
            if (leavingPlayerId < 0 || leavingPlayerId > 9007199254740990)
                throw new Exception("Forbidden value on leavingPlayerId = " + leavingPlayerId + ", it doesn't respect the following condition : leavingPlayerId < 0 || leavingPlayerId > 9007199254740990");
        }
        
    }
    
}