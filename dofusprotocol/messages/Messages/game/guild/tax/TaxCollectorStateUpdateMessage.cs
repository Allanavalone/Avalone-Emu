

// Generated on 02/17/2017 01:58:12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TaxCollectorStateUpdateMessage : Message
    {
        public const uint Id = 6455;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int uniqueId;
        public sbyte state;
        
        public TaxCollectorStateUpdateMessage()
        {
        }
        
        public TaxCollectorStateUpdateMessage(int uniqueId, sbyte state)
        {
            this.uniqueId = uniqueId;
            this.state = state;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(uniqueId);
            writer.WriteSByte(state);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            uniqueId = reader.ReadInt();
            state = reader.ReadSByte();
        }
        
    }
    
}