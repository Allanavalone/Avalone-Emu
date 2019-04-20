

// Generated on 02/17/2017 01:57:41
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class BasicLatencyStatsMessage : Message
    {
        public const uint Id = 5663;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short latency;
        public short sampleCount;
        public short max;
        
        public BasicLatencyStatsMessage()
        {
        }
        
        public BasicLatencyStatsMessage(short latency, short sampleCount, short max)
        {
            this.latency = latency;
            this.sampleCount = sampleCount;
            this.max = max;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(latency);
            writer.WriteVarShort(sampleCount);
            writer.WriteVarShort(max);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            latency = reader.ReadShort();
            if (latency < 0 || latency > 65535)
                throw new Exception("Forbidden value on latency = " + latency + ", it doesn't respect the following condition : latency < 0 || latency > 65535");
            sampleCount = reader.ReadVarShort();
            if (sampleCount < 0)
                throw new Exception("Forbidden value on sampleCount = " + sampleCount + ", it doesn't respect the following condition : sampleCount < 0");
            max = reader.ReadVarShort();
            if (max < 0)
                throw new Exception("Forbidden value on max = " + max + ", it doesn't respect the following condition : max < 0");
        }
        
    }
    
}