

// Generated on 02/17/2017 01:58:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyNewGuestMessage : AbstractPartyEventMessage
    {
        public const uint Id = 6260;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.PartyGuestInformations guest;
        
        public PartyNewGuestMessage()
        {
        }
        
        public PartyNewGuestMessage(int partyId, Types.PartyGuestInformations guest)
         : base(partyId)
        {
            this.guest = guest;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            guest.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guest = new Types.PartyGuestInformations();
            guest.Deserialize(reader);
        }
        
    }
    
}