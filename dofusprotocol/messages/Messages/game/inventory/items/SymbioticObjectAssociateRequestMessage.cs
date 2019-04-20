

// Generated on 02/17/2017 01:58:23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SymbioticObjectAssociateRequestMessage : Message
    {
        public const uint Id = 6522;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int symbioteUID;
        public sbyte symbiotePos;
        public int hostUID;
        public sbyte hostPos;
        
        public SymbioticObjectAssociateRequestMessage()
        {
        }
        
        public SymbioticObjectAssociateRequestMessage(int symbioteUID, sbyte symbiotePos, int hostUID, sbyte hostPos)
        {
            this.symbioteUID = symbioteUID;
            this.symbiotePos = symbiotePos;
            this.hostUID = hostUID;
            this.hostPos = hostPos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(symbioteUID);
            writer.WriteSByte(symbiotePos);
            writer.WriteVarInt(hostUID);
            writer.WriteSByte(hostPos);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            symbioteUID = reader.ReadVarInt();
            if (symbioteUID < 0)
                throw new Exception("Forbidden value on symbioteUID = " + symbioteUID + ", it doesn't respect the following condition : symbioteUID < 0");
            symbiotePos = reader.ReadSByte();
            if (symbiotePos < 0 || symbiotePos > 255)
                throw new Exception("Forbidden value on symbiotePos = " + symbiotePos + ", it doesn't respect the following condition : symbiotePos < 0 || symbiotePos > 255");
            hostUID = reader.ReadVarInt();
            if (hostUID < 0)
                throw new Exception("Forbidden value on hostUID = " + hostUID + ", it doesn't respect the following condition : hostUID < 0");
            hostPos = reader.ReadSByte();
            if (hostPos < 0 || hostPos > 255)
                throw new Exception("Forbidden value on hostPos = " + hostPos + ", it doesn't respect the following condition : hostPos < 0 || hostPos > 255");
        }
        
    }
    
}