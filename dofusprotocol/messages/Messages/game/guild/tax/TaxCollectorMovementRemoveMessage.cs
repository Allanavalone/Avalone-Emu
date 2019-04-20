

// Generated on 02/17/2017 01:58:11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TaxCollectorMovementRemoveMessage : Message
    {
        public const uint Id = 5915;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int collectorId;
        
        public TaxCollectorMovementRemoveMessage()
        {
        }
        
        public TaxCollectorMovementRemoveMessage(int collectorId)
        {
            this.collectorId = collectorId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(collectorId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            collectorId = reader.ReadInt();
        }
        
    }
    
}