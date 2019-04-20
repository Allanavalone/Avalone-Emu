

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeStartOkJobIndexMessage : Message
    {
        public const uint Id = 5819;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> jobs;
        
        public ExchangeStartOkJobIndexMessage()
        {
        }
        
        public ExchangeStartOkJobIndexMessage(IEnumerable<int> jobs)
        {
            this.jobs = jobs;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var jobs_before = writer.Position;
            var jobs_count = 0;
            writer.WriteShort(0);
            foreach (var entry in jobs)
            {
                 writer.WriteVarInt(entry);
                 jobs_count++;
            }
            var jobs_after = writer.Position;
            writer.Seek((int)jobs_before);
            writer.WriteShort((short)jobs_count);
            writer.Seek((int)jobs_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var jobs_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 jobs_[i] = reader.ReadVarInt();
                 if (jobs_[i] < 0)
                     throw new Exception("Forbidden value on jobs_[i] = " + jobs_[i] + ", it doesn't respect the following condition : jobs_[i] < 0");
            }
            jobs = jobs_;
        }
        
    }
    
}