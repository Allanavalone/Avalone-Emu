

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseOnMapInformations : HouseInformations
    {
        public const short Id = 510;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> doorsOnMap;
        public IEnumerable<Types.HouseInstanceInformations> houseInstances;
        
        public HouseOnMapInformations()
        {
        }
        
        public HouseOnMapInformations(int houseId, short modelId, IEnumerable<int> doorsOnMap, IEnumerable<Types.HouseInstanceInformations> houseInstances)
         : base(houseId, modelId)
        {
            this.doorsOnMap = doorsOnMap;
            this.houseInstances = houseInstances;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
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

            var houseInstances_before = writer.Position;
            var houseInstances_count = 0;
            writer.WriteShort(0);
            foreach (var entry in houseInstances)
            {
                 entry.Serialize(writer);
                 houseInstances_count++;
            }
            var houseInstances_after = writer.Position;
            writer.Seek((int)houseInstances_before);
            writer.WriteShort((short)houseInstances_count);
            writer.Seek((int)houseInstances_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var doorsOnMap_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 doorsOnMap_[i] = reader.ReadInt();
                 if (doorsOnMap_[i] < 0)
                     throw new Exception("Forbidden value on doorsOnMap_[i] = " + doorsOnMap_[i] + ", it doesn't respect the following condition : doorsOnMap_[i] < 0");
            }
            doorsOnMap = doorsOnMap_;
            limit = reader.ReadShort();
            var houseInstances_ = new Types.HouseInstanceInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houseInstances_[i] = new Types.HouseInstanceInformations();
                 houseInstances_[i].Deserialize(reader);
            }
            houseInstances = houseInstances_;
        }
        
        
    }
    
}