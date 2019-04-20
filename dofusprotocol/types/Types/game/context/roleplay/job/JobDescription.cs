

// Generated on 02/17/2017 01:52:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class JobDescription
    {
        public const short Id = 101;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte jobId;
        public IEnumerable<SkillActionDescription> skills;
        
        public JobDescription()
        {
        }
        
        public JobDescription(sbyte jobId, IEnumerable<SkillActionDescription> skills)
        {
            this.jobId = jobId;
            this.skills = skills;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(jobId);
            var skills_before = writer.Position;
            var skills_count = 0;
            writer.WriteShort(0);
            foreach (var entry in skills)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 skills_count++;
            }
            var skills_after = writer.Position;
            writer.Seek((int)skills_before);
            writer.WriteShort((short)skills_count);
            writer.Seek((int)skills_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            var limit = reader.ReadShort();
            var skills_ = new SkillActionDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 skills_[i] = Types.ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadShort());
                 skills_[i].Deserialize(reader);
            }
            skills = skills_;
        }
        
        
    }
    
}