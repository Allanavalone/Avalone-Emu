

// Generated on 02/17/2017 01:58:11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TaxCollectorMovementAddMessage : Message
    {
        public const uint Id = 5917;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public TaxCollectorInformations informations;
        
        public TaxCollectorMovementAddMessage()
        {
        }
        
        public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
        {
            this.informations = informations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            informations = Types.ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
            informations.Deserialize(reader);
        }
        
    }
    
}