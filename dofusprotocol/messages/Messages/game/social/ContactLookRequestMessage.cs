

// Generated on 02/17/2017 01:58:27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ContactLookRequestMessage : Message
    {
        public const uint Id = 5932;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte requestId;
        public sbyte contactType;
        
        public ContactLookRequestMessage()
        {
        }
        
        public ContactLookRequestMessage(sbyte requestId, sbyte contactType)
        {
            this.requestId = requestId;
            this.contactType = contactType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(requestId);
            writer.WriteSByte(contactType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            requestId = reader.ReadSByte();
            if (requestId < 0 || requestId > 255)
                throw new Exception("Forbidden value on requestId = " + requestId + ", it doesn't respect the following condition : requestId < 0 || requestId > 255");
            contactType = reader.ReadSByte();
        }
        
    }
    
}