

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class CloseHavenBagFurnitureSequenceRequestMessage : Message
    {
        public const uint Id = 6621;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        
        public CloseHavenBagFurnitureSequenceRequestMessage()
        {
        }
        
        
        public override void Serialize(IDataWriter writer)
        {
        }
        
        public override void Deserialize(IDataReader reader)
        {
        }
        
    }
    
}