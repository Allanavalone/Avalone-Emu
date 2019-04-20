

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class InteractiveElement
    {
        public const short Id = 80;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int elementId;
        public int elementTypeId;
        public IEnumerable<InteractiveElementSkill> enabledSkills;
        public IEnumerable<InteractiveElementSkill> disabledSkills;
        public bool onCurrentMap;
        
        public InteractiveElement()
        {
        }
        
        public InteractiveElement(int elementId, int elementTypeId, IEnumerable<InteractiveElementSkill> enabledSkills, IEnumerable<InteractiveElementSkill> disabledSkills, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementTypeId = elementTypeId;
            this.enabledSkills = enabledSkills;
            this.disabledSkills = disabledSkills;
            this.onCurrentMap = onCurrentMap;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteInt(elementTypeId);
            var enabledSkills_before = writer.Position;
            var enabledSkills_count = 0;
            writer.WriteShort(0);
            foreach (var entry in enabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 enabledSkills_count++;
            }
            var enabledSkills_after = writer.Position;
            writer.Seek((int)enabledSkills_before);
            writer.WriteShort((short)enabledSkills_count);
            writer.Seek((int)enabledSkills_after);

            var disabledSkills_before = writer.Position;
            var disabledSkills_count = 0;
            writer.WriteShort(0);
            foreach (var entry in disabledSkills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 disabledSkills_count++;
            }
            var disabledSkills_after = writer.Position;
            writer.Seek((int)disabledSkills_before);
            writer.WriteShort((short)disabledSkills_count);
            writer.Seek((int)disabledSkills_after);

            writer.WriteBoolean(onCurrentMap);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementTypeId = reader.ReadInt();
            var limit = reader.ReadShort();
            var enabledSkills_ = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 enabledSkills_[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                 enabledSkills_[i].Deserialize(reader);
            }
            enabledSkills = enabledSkills_;
            limit = reader.ReadShort();
            var disabledSkills_ = new InteractiveElementSkill[limit];
            for (int i = 0; i < limit; i++)
            {
                 disabledSkills_[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
                 disabledSkills_[i].Deserialize(reader);
            }
            disabledSkills = disabledSkills_;
            onCurrentMap = reader.ReadBoolean();
        }
        
        
    }
    
}