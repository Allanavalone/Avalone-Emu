

// Generated on 02/17/2017 01:58:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class LivingObjectDissociateMessage : Message
    {
        public const uint Id = 5723;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int livingUID;
        public sbyte livingPosition;
        
        public LivingObjectDissociateMessage()
        {
        }
        
        public LivingObjectDissociateMessage(int livingUID, sbyte livingPosition)
        {
            this.livingUID = livingUID;
            this.livingPosition = livingPosition;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(livingUID);
            writer.WriteSByte(livingPosition);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            livingUID = reader.ReadVarInt();
            if (livingUID < 0)
                throw new Exception("Forbidden value on livingUID = " + livingUID + ", it doesn't respect the following condition : livingUID < 0");
            livingPosition = reader.ReadSByte();
            if (livingPosition < 0 || livingPosition > 255)
                throw new Exception("Forbidden value on livingPosition = " + livingPosition + ", it doesn't respect the following condition : livingPosition < 0 || livingPosition > 255");
        }
        
    }
    
}