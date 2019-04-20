

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseInformations
    {
        public const short Id = 111;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int houseId;
        public short modelId;
        
        public HouseInformations()
        {
        }
        
        public HouseInformations(int houseId, short modelId)
        {
            this.houseId = houseId;
            this.modelId = modelId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(houseId);
            writer.WriteVarShort(modelId);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            houseId = reader.ReadVarInt();
            if (houseId < 0)
                throw new Exception("Forbidden value on houseId = " + houseId + ", it doesn't respect the following condition : houseId < 0");
            modelId = reader.ReadVarShort();
            if (modelId < 0)
                throw new Exception("Forbidden value on modelId = " + modelId + ", it doesn't respect the following condition : modelId < 0");
        }
        
        
    }
    
}