

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class SellerBuyerDescriptor
    {
        public const short Id = 121;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<int> quantities;
        public IEnumerable<int> types;
        public float taxPercentage;
        public float taxModificationPercentage;
        public sbyte maxItemLevel;
        public int maxItemPerAccount;
        public int npcContextualId;
        public short unsoldDelay;
        
        public SellerBuyerDescriptor()
        {
        }
        
        public SellerBuyerDescriptor(IEnumerable<int> quantities, IEnumerable<int> types, float taxPercentage, float taxModificationPercentage, sbyte maxItemLevel, int maxItemPerAccount, int npcContextualId, short unsoldDelay)
        {
            this.quantities = quantities;
            this.types = types;
            this.taxPercentage = taxPercentage;
            this.taxModificationPercentage = taxModificationPercentage;
            this.maxItemLevel = maxItemLevel;
            this.maxItemPerAccount = maxItemPerAccount;
            this.npcContextualId = npcContextualId;
            this.unsoldDelay = unsoldDelay;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            var quantities_before = writer.Position;
            var quantities_count = 0;
            writer.WriteShort(0);
            foreach (var entry in quantities)
            {
                 writer.WriteVarInt(entry);
                 quantities_count++;
            }
            var quantities_after = writer.Position;
            writer.Seek((int)quantities_before);
            writer.WriteShort((short)quantities_count);
            writer.Seek((int)quantities_after);

            var types_before = writer.Position;
            var types_count = 0;
            writer.WriteShort(0);
            foreach (var entry in types)
            {
                 writer.WriteVarInt(entry);
                 types_count++;
            }
            var types_after = writer.Position;
            writer.Seek((int)types_before);
            writer.WriteShort((short)types_count);
            writer.Seek((int)types_after);

            writer.WriteFloat(taxPercentage);
            writer.WriteFloat(taxModificationPercentage);
            writer.WriteSByte(maxItemLevel);
            writer.WriteVarInt(maxItemPerAccount);
            writer.WriteInt(npcContextualId);
            writer.WriteVarShort(unsoldDelay);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var quantities_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 quantities_[i] = reader.ReadVarInt();
                 if (quantities_[i] < 0)
                     throw new Exception("Forbidden value on quantities_[i] = " + quantities_[i] + ", it doesn't respect the following condition : quantities_[i] < 0");
            }
            quantities = quantities_;
            limit = reader.ReadShort();
            var types_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 types_[i] = reader.ReadVarInt();
                 if (types_[i] < 0)
                     throw new Exception("Forbidden value on types_[i] = " + types_[i] + ", it doesn't respect the following condition : types_[i] < 0");
            }
            types = types_;
            taxPercentage = reader.ReadFloat();
            taxModificationPercentage = reader.ReadFloat();
            maxItemLevel = reader.ReadSByte();
            if (maxItemLevel < 0 || maxItemLevel > 255)
                throw new Exception("Forbidden value on maxItemLevel = " + maxItemLevel + ", it doesn't respect the following condition : maxItemLevel < 0 || maxItemLevel > 255");
            maxItemPerAccount = reader.ReadVarInt();
            if (maxItemPerAccount < 0)
                throw new Exception("Forbidden value on maxItemPerAccount = " + maxItemPerAccount + ", it doesn't respect the following condition : maxItemPerAccount < 0");
            npcContextualId = reader.ReadInt();
            unsoldDelay = reader.ReadVarShort();
            if (unsoldDelay < 0)
                throw new Exception("Forbidden value on unsoldDelay = " + unsoldDelay + ", it doesn't respect the following condition : unsoldDelay < 0");
        }
        
        
    }
    
}