

// Generated on 02/17/2017 01:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class AbstractCharacterInformation
    {
        public const short Id = 400;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public long id;
        
        public AbstractCharacterInformation()
        {
        }
        
        public AbstractCharacterInformation(long id)
        {
            this.id = id;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(id);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarLong();
            if (id < 0 || id > 9007199254740990)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0 || id > 9007199254740990");
        }
        
        
    }
    
}