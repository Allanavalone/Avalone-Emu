

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class DareReward
    {
        public const short Id = 505;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public short monsterId;
        public long kamas;
        public double dareId;
        
        public DareReward()
        {
        }
        
        public DareReward(sbyte type, short monsterId, long kamas, double dareId)
        {
            this.type = type;
            this.monsterId = monsterId;
            this.kamas = kamas;
            this.dareId = dareId;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteVarShort(monsterId);
            writer.WriteVarLong(kamas);
            writer.WriteDouble(dareId);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            monsterId = reader.ReadVarShort();
            if (monsterId < 0)
                throw new Exception("Forbidden value on monsterId = " + monsterId + ", it doesn't respect the following condition : monsterId < 0");
            kamas = reader.ReadVarLong();
            if (kamas < 0 || kamas > 9007199254740990)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0 || kamas > 9007199254740990");
            dareId = reader.ReadDouble();
            if (dareId < 0 || dareId > 9007199254740990)
                throw new Exception("Forbidden value on dareId = " + dareId + ", it doesn't respect the following condition : dareId < 0 || dareId > 9007199254740990");
        }
        
        
    }
    
}