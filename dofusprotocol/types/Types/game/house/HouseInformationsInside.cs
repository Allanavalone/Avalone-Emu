using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseInformationsInside : HouseInformations
    {
        public const short Id = 218;
        public override short TypeId
        {
            get { return Id; }
        }

        public HouseInstanceInformations houseInfos;
        public short worldX;
        public short worldY;
        
        public HouseInformationsInside()
        {
        }
        
        public HouseInformationsInside(int houseId, short modelId, HouseInstanceInformations houseInfos, short worldX, short worldY)
         : base(houseId, modelId)
        {
            this.houseInfos = houseInfos;
            this.worldX = worldX;
            this.worldY = worldY;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(houseInfos.TypeId);
            houseInfos.Serialize(writer);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            houseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
            houseInfos.Deserialize(reader);
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");

        }
        
    }
    
}