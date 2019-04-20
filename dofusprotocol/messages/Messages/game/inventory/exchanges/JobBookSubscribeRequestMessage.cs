

// Generated on 02/17/2017 01:58:20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class JobBookSubscribeRequestMessage : Message
    {
        public const uint Id = 6592;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<sbyte> jobIds;
        
        public JobBookSubscribeRequestMessage()
        {
        }
        
        public JobBookSubscribeRequestMessage(IEnumerable<sbyte> jobIds)
        {
            this.jobIds = jobIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var jobIds_before = writer.Position;
            var jobIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in jobIds)
            {
                 writer.WriteSByte(entry);
                 jobIds_count++;
            }
            var jobIds_after = writer.Position;
            writer.Seek((int)jobIds_before);
            writer.WriteShort((short)jobIds_count);
            writer.Seek((int)jobIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var jobIds_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobIds_[i] = reader.ReadSByte();
                 if (jobIds_[i] < 0)
                     throw new Exception("Forbidden value on jobIds_[i] = " + jobIds_[i] + ", it doesn't respect the following condition : jobIds_[i] < 0");
            }
            jobIds = jobIds_;
        }
        
    }
    
}