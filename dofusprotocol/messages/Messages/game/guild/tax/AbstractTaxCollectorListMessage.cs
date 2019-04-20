

// Generated on 02/17/2017 01:58:11
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AbstractTaxCollectorListMessage : Message
    {
        public const uint Id = 6568;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<TaxCollectorInformations> informations;
        
        public AbstractTaxCollectorListMessage()
        {
        }
        
        public AbstractTaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations)
        {
            this.informations = informations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var informations_before = writer.Position;
            var informations_count = 0;
            writer.WriteShort(0);
            foreach (var entry in informations)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 informations_count++;
            }
            var informations_after = writer.Position;
            writer.Seek((int)informations_before);
            writer.WriteShort((short)informations_count);
            writer.Seek((int)informations_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var informations_ = new TaxCollectorInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 informations_[i] = Types.ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
                 informations_[i].Deserialize(reader);
            }
            informations = informations_;
        }
        
    }
    
}