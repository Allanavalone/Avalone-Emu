

// Generated on 02/17/2017 01:58:20
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage : Message
    {
        public const uint Id = 6021;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool allow;
        
        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage()
        {
        }
        
        public ExchangeMultiCraftSetCrafterCanUseHisRessourcesMessage(bool allow)
        {
            this.allow = allow;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(allow);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            allow = reader.ReadBoolean();
        }
        
    }
    
}