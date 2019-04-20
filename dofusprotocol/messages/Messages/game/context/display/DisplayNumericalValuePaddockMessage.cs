

// Generated on 02/17/2017 01:57:47
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DisplayNumericalValuePaddockMessage : Message
    {
        public const uint Id = 6563;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int rideId;
        public int value;
        public sbyte type;
        
        public DisplayNumericalValuePaddockMessage()
        {
        }
        
        public DisplayNumericalValuePaddockMessage(int rideId, int value, sbyte type)
        {
            this.rideId = rideId;
            this.value = value;
            this.type = type;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(rideId);
            writer.WriteInt(value);
            writer.WriteSByte(type);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            rideId = reader.ReadInt();
            value = reader.ReadInt();
            type = reader.ReadSByte();
        }
        
    }
    
}