

// Generated on 02/17/2017 01:58:27
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ShortcutBarSwapErrorMessage : Message
    {
        public const uint Id = 6226;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte error;
        
        public ShortcutBarSwapErrorMessage()
        {
        }
        
        public ShortcutBarSwapErrorMessage(sbyte error)
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