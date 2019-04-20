

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class MapCoordinates
    {
        public const short Id = 174;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short worldX;
        public short worldY;
        
        public MapCoordinates()
        {
        }
        
        public MapCoordinates(short worldX, short worldY)
        {
            this.worldX = worldX;
            this.worldY = worldY;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
        }
        
        
    }
    
}