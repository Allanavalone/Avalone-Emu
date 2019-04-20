

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SkillActionDescriptionTimed : SkillActionDescription
    {
        public const short Id = 103;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte time;
        
        public SkillActionDescriptionTimed()
        {
        }
        
        public SkillActionDescriptionTimed(short skillId, sbyte time)
         : base(skillId)
        {
            this.time = time;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(time);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            time = reader.ReadSByte();
            if (time < 0 || time > 255)
                throw new Exception("Forbidden value on time = " + time + ", it doesn't respect the following condition : time < 0 || time > 255");
        }
        
        
    }
    
}