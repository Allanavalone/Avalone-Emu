

// Generated on 02/17/2017 01:58:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TreasureHuntShowLegendaryUIMessage : Message
    {
        public const uint Id = 6498;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> availableLegendaryIds;
        
        public TreasureHuntShowLegendaryUIMessage()
        {
        }
        
        public TreasureHuntShowLegendaryUIMessage(IEnumerable<short> availableLegendaryIds)
        {
            this.availableLegendaryIds = availableLegendaryIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var availableLegendaryIds_before = writer.Position;
            var availableLegendaryIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in availableLegendaryIds)
            {
                 writer.WriteVarShort(entry);
                 availableLegendaryIds_count++;
            }
            var availableLegendaryIds_after = writer.Position;
            writer.Seek((int)availableLegendaryIds_before);
            writer.WriteShort((short)availableLegendaryIds_count);
            writer.Seek((int)availableLegendaryIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var availableLegendaryIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 availableLegendaryIds_[i] = reader.ReadVarShort();
                 if (availableLegendaryIds_[i] < 0)
                     throw new Exception("Forbidden value on availableLegendaryIds_[i] = " + availableLegendaryIds_[i] + ", it doesn't respect the following condition : availableLegendaryIds_[i] < 0");
            }
            availableLegendaryIds = availableLegendaryIds_;
        }
        
    }
    
}