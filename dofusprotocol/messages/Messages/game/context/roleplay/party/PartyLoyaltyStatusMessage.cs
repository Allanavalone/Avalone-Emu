

// Generated on 02/17/2017 01:58:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyLoyaltyStatusMessage : AbstractPartyMessage
    {
        public const uint Id = 6270;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool loyal;
        
        public PartyLoyaltyStatusMessage()
        {
        }
        
        public PartyLoyaltyStatusMessage(int partyId, bool loyal)
         : base(partyId)
        {
            this.loyal = loyal;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(loyal);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            loyal = reader.ReadBoolean();
        }
        
    }
    
}