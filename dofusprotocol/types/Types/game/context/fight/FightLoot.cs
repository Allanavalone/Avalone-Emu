

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightLoot
    {
        public const short Id = 41;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> objects;
        public long kamas;
        
        public FightLoot()
        {
        }
        
        public FightLoot(IEnumerable<short> objects, long kamas)
        {
            this.objects = objects;
            this.kamas = kamas;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            var objects_before = writer.Position;
            var objects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in objects)
            {
                 writer.WriteVarShort(entry);
                 objects_count++;
            }
            var objects_after = writer.Position;
            writer.Seek((int)objects_before);
            writer.WriteShort((short)objects_count);
            writer.Seek((int)objects_after);

            writer.WriteVarLong(kamas);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var objects_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 objects_[i] = reader.ReadVarShort();
                 if (objects_[i] < 0)
                     throw new Exception("Forbidden value on objects_[i] = " + objects_[i] + ", it doesn't respect the following condition : objects_[i] < 0");
            }
            objects = objects_;
            kamas = reader.ReadVarLong();
            if (kamas < 0 || kamas > 9007199254740990)
                throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0 || kamas > 9007199254740990");
        }
        
        
    }
    
}