

// Generated on 02/17/2017 01:57:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class JobDescriptionMessage : Message
    {
        public const uint Id = 5655;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.JobDescription> jobsDescription;
        
        public JobDescriptionMessage()
        {
        }
        
        public JobDescriptionMessage(IEnumerable<Types.JobDescription> jobsDescription)
        {
            this.jobsDescription = jobsDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var jobsDescription_before = writer.Position;
            var jobsDescription_count = 0;
            writer.WriteShort(0);
            foreach (var entry in jobsDescription)
            {
                 entry.Serialize(writer);
                 jobsDescription_count++;
            }
            var jobsDescription_after = writer.Position;
            writer.Seek((int)jobsDescription_before);
            writer.WriteShort((short)jobsDescription_count);
            writer.Seek((int)jobsDescription_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var jobsDescription_ = new Types.JobDescription[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobsDescription_[i] = new Types.JobDescription();
                 jobsDescription_[i].Deserialize(reader);
            }
            jobsDescription = jobsDescription_;
        }
        
    }
    
}