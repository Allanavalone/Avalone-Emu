

// Generated on 02/17/2017 01:58:19
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeTypesExchangerDescriptionForUserMessage : Message
    {
        public const uint Id = 5765;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> typeDescription;
        
        public ExchangeTypesExchangerDescriptionForUserMessage()
        {
        }
        
        public ExchangeTypesExchangerDescriptionForUserMessage(IEnumerable<int> typeDescription)
        {
            this.typeDescription = typeDescription;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var typeDescription_before = writer.Position;
            var typeDescription_count = 0;
            writer.WriteShort(0);
            foreach (var entry in typeDescription)
            {
                 writer.WriteVarInt(entry);
                 typeDescription_count++;
            }
            var typeDescription_after = writer.Position;
            writer.Seek((int)typeDescription_before);
            writer.WriteShort((short)typeDescription_count);
            writer.Seek((int)typeDescription_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var typeDescription_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 typeDescription_[i] = reader.ReadVarInt();
                 if (typeDescription_[i] < 0)
                     throw new Exception("Forbidden value on typeDescription_[i] = " + typeDescription_[i] + ", it doesn't respect the following condition : typeDescription_[i] < 0");
            }
            typeDescription = typeDescription_;
        }
        
    }
    
}