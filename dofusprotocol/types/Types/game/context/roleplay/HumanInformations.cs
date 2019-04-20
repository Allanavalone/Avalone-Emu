

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HumanInformations
    {
        public const short Id = 157;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public Types.ActorRestrictionsInformations restrictions;
        public bool sex;
        public IEnumerable<HumanOption> options;
        
        public HumanInformations()
        {
        }
        
        public HumanInformations(Types.ActorRestrictionsInformations restrictions, bool sex, IEnumerable<HumanOption> options)
        {
            this.restrictions = restrictions;
            this.sex = sex;
            this.options = options;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            restrictions.Serialize(writer);
            writer.WriteBoolean(sex);
            var options_before = writer.Position;
            var options_count = 0;
            writer.WriteShort(0);
            foreach (var entry in options)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 options_count++;
            }
            var options_after = writer.Position;
            writer.Seek((int)options_before);
            writer.WriteShort((short)options_count);
            writer.Seek((int)options_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            restrictions = new Types.ActorRestrictionsInformations();
            restrictions.Deserialize(reader);
            sex = reader.ReadBoolean();
            var limit = reader.ReadShort();
            var options_ = new HumanOption[limit];
            for (int i = 0; i < limit; i++)
            {
                 options_[i] = Types.ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                 options_[i].Deserialize(reader);
            }
            options = options_;
        }
        
        
    }
    
}