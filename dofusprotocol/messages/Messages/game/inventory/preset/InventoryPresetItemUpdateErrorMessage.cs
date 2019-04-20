

// Generated on 02/17/2017 01:58:23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryPresetItemUpdateErrorMessage : Message
    {
        public const uint Id = 6211;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte code;
        
        public InventoryPresetItemUpdateErrorMessage()
        {
        }
        
        public InventoryPresetItemUpdateErrorMessage(sbyte code)
        {
            this.code = code;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(code);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            code = reader.ReadSByte();
        }
        
    }
    
}