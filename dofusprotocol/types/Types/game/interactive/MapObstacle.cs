

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class MapObstacle
    {
        public const short Id = 200;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short obstacleCellId;
        public sbyte state;
        
        public MapObstacle()
        {
        }
        
        public MapObstacle(short obstacleCellId, sbyte state)
        {
            this.obstacleCellId = obstacleCellId;
            this.state = state;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(obstacleCellId);
            writer.WriteSByte(state);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            obstacleCellId = reader.ReadVarShort();
            if (obstacleCellId < 0 || obstacleCellId > 559)
                throw new Exception("Forbidden value on obstacleCellId = " + obstacleCellId + ", it doesn't respect the following condition : obstacleCellId < 0 || obstacleCellId > 559");
            state = reader.ReadSByte();
        }
        
        
    }
    
}