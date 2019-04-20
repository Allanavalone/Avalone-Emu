using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryPresetSaveResultMessage : AbstractPresetSaveResultMessage
    {
        public const uint Id = 6170;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public InventoryPresetSaveResultMessage()
        {
        }
        
        public InventoryPresetSaveResultMessage(byte presetId, byte code)
         : base(presetId, code)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
        
    }
    
}