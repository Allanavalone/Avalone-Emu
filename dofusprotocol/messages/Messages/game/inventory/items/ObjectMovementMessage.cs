

// Generated on 02/17/2017 01:58:22
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectMovementMessage : Message
    {
        public const uint Id = 3010;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int objectUID;
        public sbyte position;
        
        public ObjectMovementMessage()
        {
        }
        
        public ObjectMovementMessage(int objectUID, sbyte position)
        {
            this.objectUID = objectUID;
            this.position = position;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(objectUID);
            writer.WriteSByte(position);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            position = reader.ReadSByte();
        }
        
    }
    
}