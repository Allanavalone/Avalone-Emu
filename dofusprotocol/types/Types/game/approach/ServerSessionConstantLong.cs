

// Generated on 02/17/2017 01:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ServerSessionConstantLong : ServerSessionConstant
    {
        public const short Id = 429;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public double value;
        
        public ServerSessionConstantLong()
        {
        }
        
        public ServerSessionConstantLong(short id, double value)
         : base(id)
        {
            this.value = value;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(value);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            value = reader.ReadDouble();
            if (value < -9007199254740990 || value > 9007199254740990)
                throw new Exception("Forbidden value on value = " + value + ", it doesn't respect the following condition : value < -9007199254740990 || value > 9007199254740990");
        }
        
        
    }
    
}