

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class JobCrafterDirectoryEntryJobInfo
    {
        public const short Id = 195;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte jobId;
        public sbyte jobLevel;
        public bool free;
        public sbyte minLevel;
        
        public JobCrafterDirectoryEntryJobInfo()
        {
        }
        
        public JobCrafterDirectoryEntryJobInfo(sbyte jobId, sbyte jobLevel, bool free, sbyte minLevel)
        {
            this.jobId = jobId;
            this.jobLevel = jobLevel;
            this.free = free;
            this.minLevel = minLevel;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(jobId);
            writer.WriteSByte(jobLevel);
            writer.WriteBoolean(free);
            writer.WriteSByte(minLevel);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            jobId = reader.ReadSByte();
            if (jobId < 0)
                throw new Exception("Forbidden value on jobId = " + jobId + ", it doesn't respect the following condition : jobId < 0");
            jobLevel = reader.ReadSByte();
            if (jobLevel < 1 || jobLevel > 200)
                throw new Exception("Forbidden value on jobLevel = " + jobLevel + ", it doesn't respect the following condition : jobLevel < 1 || jobLevel > 200");
            free = reader.ReadBoolean();
            minLevel = reader.ReadSByte();
            if (minLevel < 0 || minLevel > 255)
                throw new Exception("Forbidden value on minLevel = " + minLevel + ", it doesn't respect the following condition : minLevel < 0 || minLevel > 255");
        }
        
        
    }
    
}