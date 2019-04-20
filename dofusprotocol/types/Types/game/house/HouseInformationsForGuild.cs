using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseInformationsForGuild : HouseInformations
    {
        public const short Id = 170;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int instanceId;
        public bool secondHand;
        public string ownerName;
        public short worldX;
        public short worldY;
        public int mapId;
        public short subAreaId;
        public IEnumerable<int> skillListIds;
        public int guildshareParams;
        
        public HouseInformationsForGuild()
        {
        }
        
        public HouseInformationsForGuild(int houseId, short modelId, int instanceId, bool secondHand, string ownerName, short worldX, short worldY, int mapId, short subAreaId, IEnumerable<int> skillListIds, int guildshareParams)
         : base(houseId, modelId)
        {
            this.instanceId = instanceId;
            this.secondHand = secondHand;
            this.ownerName = ownerName;
            this.worldX = worldX;
            this.worldY = worldY;
            this.mapId = mapId;
            this.subAreaId = subAreaId;
            this.skillListIds = skillListIds;
            this.guildshareParams = guildshareParams;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(instanceId);
            writer.WriteBoolean(secondHand);
            writer.WriteUTF(ownerName);
            writer.WriteShort(worldX);
            writer.WriteShort(worldY);
            writer.WriteInt(mapId);
            writer.WriteVarShort(subAreaId);
            var skillListIds_before = writer.Position;
            var skillListIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in skillListIds)
            {
                 writer.WriteInt(entry);
                 skillListIds_count++;
            }
            var skillListIds_after = writer.Position;
            writer.Seek((int)skillListIds_before);
            writer.WriteShort((short)skillListIds_count);
            writer.Seek((int)skillListIds_after);

            writer.WriteVarInt(guildshareParams);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            instanceId = reader.ReadInt();
            if (instanceId < 0)
                throw new Exception("Forbidden value on instanceId = " + instanceId + ", it doesn't respect the following condition : instanceId < 0 || instanceId > 4294967295");
            secondHand = reader.ReadBoolean();
            ownerName = reader.ReadUTF();
            worldX = reader.ReadShort();
            if (worldX < -255 || worldX > 255)
                throw new Exception("Forbidden value on worldX = " + worldX + ", it doesn't respect the following condition : worldX < -255 || worldX > 255");
            worldY = reader.ReadShort();
            if (worldY < -255 || worldY > 255)
                throw new Exception("Forbidden value on worldY = " + worldY + ", it doesn't respect the following condition : worldY < -255 || worldY > 255");
            mapId = reader.ReadInt();
            subAreaId = reader.ReadVarShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            var limit = reader.ReadShort();
            var skillListIds_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 skillListIds_[i] = reader.ReadInt();
            }
            skillListIds = skillListIds_;
            guildshareParams = reader.ReadVarInt();
            if (guildshareParams < 0)
                throw new Exception("Forbidden value on guildshareParams = " + guildshareParams + ", it doesn't respect the following condition : guildshareParams < 0");
        }
        
        
    }
    
}