

// Generated on 02/17/2017 01:58:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ObjectAveragePricesMessage : Message
    {
        public const uint Id = 6335;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> ids;
        public IEnumerable<long> avgPrices;
        
        public ObjectAveragePricesMessage()
        {
        }
        
        public ObjectAveragePricesMessage(IEnumerable<short> ids, IEnumerable<long> avgPrices)
        {
            this.ids = ids;
            this.avgPrices = avgPrices;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var ids_before = writer.Position;
            var ids_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ids)
            {
                 writer.WriteVarShort(entry);
                 ids_count++;
            }
            var ids_after = writer.Position;
            writer.Seek((int)ids_before);
            writer.WriteShort((short)ids_count);
            writer.Seek((int)ids_after);

            var avgPrices_before = writer.Position;
            var avgPrices_count = 0;
            writer.WriteShort(0);
            foreach (var entry in avgPrices)
            {
                 writer.WriteVarLong(entry);
                 avgPrices_count++;
            }
            var avgPrices_after = writer.Position;
            writer.Seek((int)avgPrices_before);
            writer.WriteShort((short)avgPrices_count);
            writer.Seek((int)avgPrices_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var ids_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids_[i] = reader.ReadVarShort();
                 if (ids_[i] < 0)
                     throw new Exception("Forbidden value on ids_[i] = " + ids_[i] + ", it doesn't respect the following condition : ids_[i] < 0");
            }
            ids = ids_;
            limit = reader.ReadShort();
            var avgPrices_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 avgPrices_[i] = reader.ReadVarLong();
                 if (avgPrices_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on avgPrices_[i] = " + avgPrices_[i] + ", it doesn't respect the following condition : avgPrices_[i] > 9007199254740990");
            }
            avgPrices = avgPrices_;
        }
        
    }
    
}