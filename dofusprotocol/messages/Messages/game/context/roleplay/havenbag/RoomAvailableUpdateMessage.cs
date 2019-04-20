

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class RoomAvailableUpdateMessage : Message
    {
        public const uint Id = 6630;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte nbRoom;
        
        public RoomAvailableUpdateMessage()
        {
        }
        
        public RoomAvailableUpdateMessage(sbyte nbRoom)
        {
            this.nbRoom = nbRoom;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(nbRoom);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            nbRoom = reader.ReadSByte();
            if (nbRoom < 0 || nbRoom > 255)
                throw new Exception("Forbidden value on nbRoom = " + nbRoom + ", it doesn't respect the following condition : nbRoom < 0 || nbRoom > 255");
        }
        
    }
    
}