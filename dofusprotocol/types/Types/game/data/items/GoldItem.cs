

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GoldItem : Item
    {
        public const short Id = 123;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public long sum;
        
        public GoldItem()
        {
        }
        
        public GoldItem(long sum)
        {
            this.sum = sum;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(sum);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            sum = reader.ReadVarLong();
            if (sum < 0 || sum > 9007199254740990)
                throw new Exception("Forbidden value on sum = " + sum + ", it doesn't respect the following condition : sum < 0 || sum > 9007199254740990");
        }
        
        
    }
    
}