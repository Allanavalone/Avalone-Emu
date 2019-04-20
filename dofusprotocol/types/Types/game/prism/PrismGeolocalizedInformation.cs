

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
    {
        public const short Id = 434;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short worldX;
        public short worldY;
        public int mapId;
        public PrismInformation prism;
        
        public PrismGeolocalizedInformation()
        {
        }
        
        public PrismGeolocalizedInformation(short subAreaId, int allianceId, short worldX, short worldY, int mapId, PrismInformation prism)
         : base(subAreaId, allianceId)
        {
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.prism = prism;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteShort(prism.TypeId);
            prism.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            prism = Types.ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
            prism.Deserialize(reader);
        }
        
        
    }
    
}