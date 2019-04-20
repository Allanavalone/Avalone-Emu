

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PaddockInstancesInformations : PaddockInformations
    {
        public const short Id = 509;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<PaddockBuyableInformations> paddocks;
        
        public PaddockInstancesInformations()
        {
        }
        
        public PaddockInstancesInformations(short maxOutdoorMount, short maxItems, IEnumerable<PaddockBuyableInformations> paddocks)
         : base(maxOutdoorMount, maxItems)
        {
            this.paddocks = paddocks;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var paddocks_before = writer.Position;
            var paddocks_count = 0;
            writer.WriteShort(0);
            foreach (var entry in paddocks)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 paddocks_count++;
            }
            var paddocks_after = writer.Position;
            writer.Seek((int)paddocks_before);
            writer.WriteShort((short)paddocks_count);
            writer.Seek((int)paddocks_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var paddocks_ = new PaddockBuyableInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 paddocks_[i] = Types.ProtocolTypeManager.GetInstance<PaddockBuyableInformations>(reader.ReadShort());
                 paddocks_[i].Deserialize(reader);
            }
            paddocks = paddocks_;
        }
        
        
    }
    
}