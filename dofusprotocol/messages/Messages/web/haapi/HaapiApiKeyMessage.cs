

// Generated on 02/17/2017 01:58:29
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HaapiApiKeyMessage : Message
    {
        public const uint Id = 6649;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte returnType;
        public sbyte keyType;
        public string token;
        
        public HaapiApiKeyMessage()
        {
        }
        
        public HaapiApiKeyMessage(sbyte returnType, sbyte keyType, string token)
        {
            this.returnType = returnType;
            this.keyType = keyType;
            this.token = token;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(returnType);
            writer.WriteSByte(keyType);
            writer.WriteUTF(token);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            returnType = reader.ReadSByte();
            keyType = reader.ReadSByte();
            token = reader.ReadUTF();
        }
        
    }
    
}