

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DareErrorMessage : Message
    {
        public const uint Id = 6667;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte error;
        
        public DareErrorMessage()
        {
        }
        
        public DareErrorMessage(sbyte error)
        {
            this.error = error;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(error);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            error = reader.ReadSByte();
        }
        
    }
    
}