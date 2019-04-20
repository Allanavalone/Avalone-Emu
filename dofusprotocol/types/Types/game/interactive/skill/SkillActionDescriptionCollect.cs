

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
    {
        public const short Id = 99;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short min;
        public short max;
        
        public SkillActionDescriptionCollect()
        {
        }
        
        public SkillActionDescriptionCollect(short skillId, sbyte time, short min, short max)
         : base(skillId, time)
        {
            this.min = min;
            this.max = max;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(min);
            writer.WriteVarShort(max);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            min = reader.ReadVarShort();
            if (min < 0)
                throw new Exception("Forbidden value on min = " + min + ", it doesn't respect the following condition : min < 0");
            max = reader.ReadVarShort();
            if (max < 0)
                throw new Exception("Forbidden value on max = " + max + ", it doesn't respect the following condition : max < 0");
        }
        
        
    }
    
}