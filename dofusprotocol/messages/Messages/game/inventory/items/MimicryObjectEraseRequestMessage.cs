

// Generated on 02/17/2017 01:58:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MimicryObjectEraseRequestMessage : Message
    {
        public const uint Id = 6457;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int hostUID;
        public sbyte hostPos;
        
        public MimicryObjectEraseRequestMessage()
        {
        }
        
        public MimicryObjectEraseRequestMessage(int hostUID, sbyte hostPos)
        {
            this.hostUID = hostUID;
            this.hostPos = hostPos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(hostUID);
            writer.WriteSByte(hostPos);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            hostUID = reader.ReadVarInt();
            if (hostUID < 0)
                throw new Exception("Forbidden value on hostUID = " + hostUID + ", it doesn't respect the following condition : hostUID < 0");
            hostPos = reader.ReadSByte();
            if (hostPos < 0 || hostPos > 255)
                throw new Exception("Forbidden value on hostPos = " + hostPos + ", it doesn't respect the following condition : hostPos < 0 || hostPos > 255");
        }
        
    }
    
}