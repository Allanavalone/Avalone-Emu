

// Generated on 02/17/2017 01:58:14
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DecraftResultMessage : Message
    {
        public const uint Id = 6569;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.DecraftedItemStackInfo> results;
        
        public DecraftResultMessage()
        {
        }
        
        public DecraftResultMessage(IEnumerable<Types.DecraftedItemStackInfo> results)
        {
            this.results = results;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var results_before = writer.Position;
            var results_count = 0;
            writer.WriteShort(0);
            foreach (var entry in results)
            {
                 entry.Serialize(writer);
                 results_count++;
            }
            var results_after = writer.Position;
            writer.Seek((int)results_before);
            writer.WriteShort((short)results_count);
            writer.Seek((int)results_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var results_ = new Types.DecraftedItemStackInfo[limit];
            for (int i = 0; i < limit; i++)
            {
                 results_[i] = new Types.DecraftedItemStackInfo();
                 results_[i].Deserialize(reader);
            }
            results = results_;
        }
        
    }
    
}