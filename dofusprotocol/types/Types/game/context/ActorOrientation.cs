

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ActorOrientation
    {
        public const short Id = 353;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public double id;
        public sbyte direction;
        
        public ActorOrientation()
        {
        }
        
        public ActorOrientation(double id, sbyte direction)
        {
            this.id = id;
            this.direction = direction;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(id);
            writer.WriteSByte(direction);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadDouble();
            if (id < -9007199254740990 || id > 9007199254740990)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < -9007199254740990 || id > 9007199254740990");
            direction = reader.ReadSByte();
        }
        
        
    }
    
}