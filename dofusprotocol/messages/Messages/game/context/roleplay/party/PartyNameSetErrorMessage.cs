

// Generated on 02/17/2017 01:58:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PartyNameSetErrorMessage : AbstractPartyMessage
    {
        public const uint Id = 6501;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte result;
        
        public PartyNameSetErrorMessage()
        {
        }
        
        public PartyNameSetErrorMessage(int partyId, sbyte result)
         : base(partyId)
        {
            this.result = result;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(result);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            result = reader.ReadSByte();
        }
        
    }
    
}