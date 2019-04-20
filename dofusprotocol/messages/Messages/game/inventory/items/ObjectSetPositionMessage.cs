

// Generated on 02/17/2017 01:58:22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectSetPositionMessage : Message
    {
        public const uint Id = 3021;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int objectUID;
        public sbyte position;
        public int quantity;
        
        public ObjectSetPositionMessage()
        {
        }
        
        public ObjectSetPositionMessage(int objectUID, sbyte position, int quantity)
        {
            this.objectUID = objectUID;
            this.position = position;
            this.quantity = quantity;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(objectUID);
            writer.WriteSByte(position);
            writer.WriteVarInt(quantity);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            position = reader.ReadSByte();
            quantity = reader.ReadVarInt();
            if (quantity < 0)
                throw new Exception("Forbidden value on quantity = " + quantity + ", it doesn't respect the following condition : quantity < 0");
        }
        
    }
    
}