

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class BidExchangerObjectInfo
    {
        public const short Id = 122;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int objectUID;
        public IEnumerable<ObjectEffect> effects;
        public IEnumerable<long> prices;
        
        public BidExchangerObjectInfo()
        {
        }
        
        public BidExchangerObjectInfo(int objectUID, IEnumerable<ObjectEffect> effects, IEnumerable<long> prices)
        {
            this.objectUID = objectUID;
            this.effects = effects;
            this.prices = prices;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(objectUID);
            var effects_before = writer.Position;
            var effects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 effects_count++;
            }
            var effects_after = writer.Position;
            writer.Seek((int)effects_before);
            writer.WriteShort((short)effects_count);
            writer.Seek((int)effects_after);

            var prices_before = writer.Position;
            var prices_count = 0;
            writer.WriteShort(0);
            foreach (var entry in prices)
            {
                 writer.WriteVarLong(entry);
                 prices_count++;
            }
            var prices_after = writer.Position;
            writer.Seek((int)prices_before);
            writer.WriteShort((short)prices_count);
            writer.Seek((int)prices_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            var limit = reader.ReadShort();
            var effects_ = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects_[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                 effects_[i].Deserialize(reader);
            }
            effects = effects_;
            limit = reader.ReadShort();
            var prices_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 prices_[i] = reader.ReadVarLong();
                 if (prices_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on prices_[i] = " + prices_[i] + ", it doesn't respect the following condition : prices_[i] > 9007199254740990");
            }
            prices = prices_;
        }
        
        
    }
    
}