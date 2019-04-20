

// Generated on 02/17/2017 01:57:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HousePropertiesMessage : Message
    {
        public const uint Id = 5734;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int houseId;
        public IEnumerable<int> doorsOnMap;
        public HouseInstanceInformations properties;
        
        public HousePropertiesMessage()
        {
        }
        
        public HousePropertiesMessage(int houseId, IEnumerable<int> doorsOnMap, HouseInstanceInformations properties)
        {
            this.houseId = houseId;
            this.doorsOnMap = doorsOnMap;
            this.properties = properties;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(houseId);
            var doorsOnMap_before = writer.Position;
            var doorsOnMap_count = 0;
            writer.WriteShort(0);
            foreach (var entry in doorsOnMap)
            {
                 writer.WriteInt(entry);
                 doorsOnMap_count++;
            }
            var doorsOnMap_after = writer.Position;
            writer.Seek((int)doorsOnMap_before);
            writer.WriteShort((short)doorsOnMap_count);
            writer.Seek((int)doorsOnMap_after);

            writer.WriteShort(properties.TypeId);
            properties.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            var limit = reader.ReadShort();
            var doorsOnMap_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 doorsOnMap_[i] = reader.ReadInt();
                 if (doorsOnMap_[i] < 0)
                     throw new Exception("Forbidden value on doorsOnMap_[i] = " + doorsOnMap_[i] + ", it doesn't respect the following condition : doorsOnMap_[i] < 0");
            }
            doorsOnMap = doorsOnMap_;
            properties = Types.ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
            properties.Deserialize(reader);
        }
        
    }
    
}