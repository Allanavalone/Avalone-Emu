

// Generated on 02/17/2017 01:58:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyCannotJoinErrorMessage : AbstractPartyMessage
    {
        public const uint Id = 5583;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte reason;
        
        public PartyCannotJoinErrorMessage()
        {
        }
        
        public PartyCannotJoinErrorMessage(int partyId, sbyte reason)
         : base(partyId)
        {
            this.reason = reason;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(reason);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            reason = reader.ReadSByte();
        }
        
    }
    
}