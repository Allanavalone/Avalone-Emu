

// Generated on 02/17/2017 01:57:31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AggregateStatMessage : Message
    {
        public const uint Id = 6669;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short statId;
        
        public AggregateStatMessage()
        {
        }
        
        public AggregateStatMessage(short statId)
        {
            this.statId = statId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(statId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            statId = reader.ReadVarShort();
        }
        
    }
    
}