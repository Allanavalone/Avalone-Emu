

// Generated on 02/17/2017 01:58:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyUpdateMessage : AbstractPartyEventMessage
    {
        public const uint Id = 5575;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public PartyMemberInformations memberInformations;
        
        public PartyUpdateMessage()
        {
        }
        
        public PartyUpdateMessage(int partyId, PartyMemberInformations memberInformations)
         : base(partyId)
        {
            this.memberInformations = memberInformations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(memberInformations.TypeId);
            memberInformations.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            memberInformations = Types.ProtocolTypeManager.GetInstance<PartyMemberInformations>(reader.ReadShort());
            memberInformations.Deserialize(reader);
        }
        
    }
    
}