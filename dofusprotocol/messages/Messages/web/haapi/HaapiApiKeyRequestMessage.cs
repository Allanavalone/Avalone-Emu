

// Generated on 02/17/2017 01:58:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HaapiApiKeyRequestMessage : Message
    {
        public const uint Id = 6648;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte keyType;
        
        public HaapiApiKeyRequestMessage()
        {
        }
        
        public HaapiApiKeyRequestMessage(sbyte keyType)
        {
            this.keyType = keyType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(keyType);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            keyType = reader.ReadSByte();
        }
        
    }
    
}