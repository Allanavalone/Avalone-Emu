

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class DecraftedItemStackInfo
    {
        public const short Id = 481;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int objectUID;
        public float bonusMin;
        public float bonusMax;
        public IEnumerable<short> runesId;
        public IEnumerable<int> runesQty;
        
        public DecraftedItemStackInfo()
        {
        }
        
        public DecraftedItemStackInfo(int objectUID, float bonusMin, float bonusMax, IEnumerable<short> runesId, IEnumerable<int> runesQty)
        {
            this.objectUID = objectUID;
            this.bonusMin = bonusMin;
            this.bonusMax = bonusMax;
            this.runesId = runesId;
            this.runesQty = runesQty;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(objectUID);
            writer.WriteFloat(bonusMin);
            writer.WriteFloat(bonusMax);
            var runesId_before = writer.Position;
            var runesId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in runesId)
            {
                 writer.WriteVarShort(entry);
                 runesId_count++;
            }
            var runesId_after = writer.Position;
            writer.Seek((int)runesId_before);
            writer.WriteShort((short)runesId_count);
            writer.Seek((int)runesId_after);

            var runesQty_before = writer.Position;
            var runesQty_count = 0;
            writer.WriteShort(0);
            foreach (var entry in runesQty)
            {
                 writer.WriteVarInt(entry);
                 runesQty_count++;
            }
            var runesQty_after = writer.Position;
            writer.Seek((int)runesQty_before);
            writer.WriteShort((short)runesQty_count);
            writer.Seek((int)runesQty_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            objectUID = reader.ReadVarInt();
            if (objectUID < 0)
                throw new Exception("Forbidden value on objectUID = " + objectUID + ", it doesn't respect the following condition : objectUID < 0");
            bonusMin = reader.ReadFloat();
            bonusMax = reader.ReadFloat();
            var limit = reader.ReadShort();
            var runesId_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesId_[i] = reader.ReadVarShort();
                 if (runesId_[i] < 0)
                     throw new Exception("Forbidden value on runesId_[i] = " + runesId_[i] + ", it doesn't respect the following condition : runesId_[i] < 0");
            }
            runesId = runesId_;
            limit = reader.ReadShort();
            var runesQty_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 runesQty_[i] = reader.ReadVarInt();
                 if (runesQty_[i] < 0)
                     throw new Exception("Forbidden value on runesQty_[i] = " + runesQty_[i] + ", it doesn't respect the following condition : runesQty_[i] < 0");
            }
            runesQty = runesQty_;
        }
        
        
    }
    
}