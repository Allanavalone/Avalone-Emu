

// Generated on 02/17/2017 01:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class AchievementRewardable
    {
        public const short Id = 412;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short id;
        public sbyte finishedlevel;
        
        public AchievementRewardable()
        {
        }
        
        public AchievementRewardable(short id, sbyte finishedlevel)
        {
            this.id = id;
            this.finishedlevel = finishedlevel;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(id);
            writer.WriteSByte(finishedlevel);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            finishedlevel = reader.ReadSByte();
            if (finishedlevel < 0 || finishedlevel > 206)
                throw new Exception("Forbidden value on finishedlevel = " + finishedlevel + ", it doesn't respect the following condition : finishedlevel < 0 || finishedlevel > 206");
        }
        
        
    }
    
}