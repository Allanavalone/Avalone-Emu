

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
    {
        public const short Id = 372;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public long kamas;
        public long experience;
        public int pods;
        public long itemsValue;
        
        public TaxCollectorLootInformations()
        {
        }
        
        public TaxCollectorLootInformations(long kamas, long experience, int pods, long itemsValue)
        {
            this.kamas = kamas;
            this.experience = experience;
            this.pods = pods;
            this.itemsValue = itemsValue;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(kamas);
            writer.WriteVarLong(experience);
            writer.WriteVarInt(pods);
            writer.WriteVarLong(itemsValue);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            kamas = reader.ReadVarLong();
            if (kamas < 0 || kamas > 9007199254740990)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0 || kamas > 9007199254740990");
            experience = reader.ReadVarLong();
            if (experience < 0 || experience > 9007199254740990)
                throw new Exception("Forbidden value on experience = " + experience + ", it doesn't respect the following condition : experience < 0 || experience > 9007199254740990");
            pods = reader.ReadVarInt();
            if (pods < 0)
                throw new Exception("Forbidden value on pods = " + pods + ", it doesn't respect the following condition : pods < 0");
            itemsValue = reader.ReadVarLong();
            if (itemsValue < 0 || itemsValue > 9007199254740990)
                throw new Exception("Forbidden value on itemsValue = " + itemsValue + ", it doesn't respect the following condition : itemsValue < 0 || itemsValue > 9007199254740990");
        }
        
        
    }
    
}