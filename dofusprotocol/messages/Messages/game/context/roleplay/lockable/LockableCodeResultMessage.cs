

// Generated on 02/17/2017 01:57:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class LockableCodeResultMessage : Message
    {
        public const uint Id = 5672;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte result;
        
        public LockableCodeResultMessage()
        {
        }
        
        public LockableCodeResultMessage(sbyte result)
        {
            this.result = result;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(result);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            result = reader.ReadSByte();
        }
        
    }
    
}