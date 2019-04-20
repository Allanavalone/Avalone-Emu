

// Generated on 02/17/2017 01:57:59
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class PaddockPropertiesMessage : Message
    {
        public const uint Id = 5824;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.PaddockInstancesInformations properties;
        
        public PaddockPropertiesMessage()
        {
        }
        
        public PaddockPropertiesMessage(Types.PaddockInstancesInformations properties)
        {
            this.properties = properties;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            properties.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            properties = new Types.PaddockInstancesInformations();
            properties.Deserialize(reader);
        }
        
    }
    
}