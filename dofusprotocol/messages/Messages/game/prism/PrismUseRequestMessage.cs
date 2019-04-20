

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PrismUseRequestMessage : Message
    {
        public const uint Id = 6041;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte moduleToUse;
        
        public PrismUseRequestMessage()
        {
        }
        
        public PrismUseRequestMessage(sbyte moduleToUse)
        {
            this.moduleToUse = moduleToUse;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(moduleToUse);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            moduleToUse = reader.ReadSByte();
        }
        
    }
    
}