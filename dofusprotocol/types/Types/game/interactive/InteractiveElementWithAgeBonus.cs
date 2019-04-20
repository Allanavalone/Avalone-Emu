

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class InteractiveElementWithAgeBonus : InteractiveElement
    {
        public const short Id = 398;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short ageBonus;
        
        public InteractiveElementWithAgeBonus()
        {
        }
        
        public InteractiveElementWithAgeBonus(int elementId, int elementTypeId, IEnumerable<InteractiveElementSkill> enabledSkills, IEnumerable<InteractiveElementSkill> disabledSkills, bool onCurrentMap, short ageBonus)
         : base(elementId, elementTypeId, enabledSkills, disabledSkills, onCurrentMap)
        {
            this.ageBonus = ageBonus;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(ageBonus);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ageBonus = reader.ReadShort();
            if (ageBonus < -1 || ageBonus > 1000)
                throw new Exception("Forbidden value on ageBonus = " + ageBonus + ", it doesn't respect the following condition : ageBonus < -1 || ageBonus > 1000");
        }
        
        
    }
    
}