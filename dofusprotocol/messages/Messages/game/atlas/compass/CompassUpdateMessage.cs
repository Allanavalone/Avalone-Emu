

// Generated on 02/17/2017 01:57:40
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CompassUpdateMessage : Message
    {
        public const uint Id = 5591;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public MapCoordinates coords;
        
        public CompassUpdateMessage()
        {
        }
        
        public CompassUpdateMessage(sbyte type, MapCoordinates coords)
        {
            this.type = type;
            this.coords = coords;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteShort(coords.TypeId);
            coords.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            coords = Types.ProtocolTypeManager.GetInstance<MapCoordinates>(reader.ReadShort());
            coords.Deserialize(reader);
        }
        
    }
    
}