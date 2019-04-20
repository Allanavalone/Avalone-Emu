

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HumanOptionObjectUse : HumanOption
    {
        public const short Id = 449;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte delayTypeId;
        public double delayEndTime;
        public short objectGID;
        
        public HumanOptionObjectUse()
        {
        }
        
        public HumanOptionObjectUse(sbyte delayTypeId, double delayEndTime, short objectGID)
        {
            this.delayTypeId = delayTypeId;
            this.delayEndTime = delayEndTime;
            this.objectGID = objectGID;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(delayTypeId);
            writer.WriteDouble(delayEndTime);
            writer.WriteVarShort(objectGID);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            delayTypeId = reader.ReadSByte();
            delayEndTime = reader.ReadDouble();
            if (delayEndTime < 0 || delayEndTime > 9007199254740990)
                throw new Exception("Forbidden value on delayEndTime = " + delayEndTime + ", it doesn't respect the following condition : delayEndTime < 0 || delayEndTime > 9007199254740990");
            objectGID = reader.ReadVarShort();
            if (objectGID < 0)
                throw new Exception("Forbidden value on objectGID = " + objectGID + ", it doesn't respect the following condition : objectGID < 0");
        }
        
        
    }
    
}