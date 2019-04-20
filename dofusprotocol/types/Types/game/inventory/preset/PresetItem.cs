

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PresetItem
    {
        public const short Id = 354;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte position;
        public short objGid;
        public int objUid;
        
        public PresetItem()
        {
        }
        
        public PresetItem(sbyte position, short objGid, int objUid)
        {
            this.position = position;
            this.objGid = objGid;
            this.objUid = objUid;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(position);
            writer.WriteVarShort(objGid);
            writer.WriteVarInt(objUid);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            position = reader.ReadSByte();
            objGid = reader.ReadVarShort();
            if (objGid < 0)
                throw new Exception("Forbidden value on objGid = " + objGid + ", it doesn't respect the following condition : objGid < 0");
            objUid = reader.ReadVarInt();
            if (objUid < 0)
                throw new Exception("Forbidden value on objUid = " + objUid + ", it doesn't respect the following condition : objUid < 0");
        }
        
        
    }
    
}