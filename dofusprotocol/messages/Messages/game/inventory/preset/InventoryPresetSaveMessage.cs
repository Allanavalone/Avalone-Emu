using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryPresetSaveMessage : AbstractPresetSaveMessage
    {
        public const uint Id = 6165;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool saveEquipment;
        
        public InventoryPresetSaveMessage()
        {
        }
        
        public InventoryPresetSaveMessage(byte presetId, byte symbolId, bool saveEquipment)
         : base(presetId, symbolId)
        {
            this.saveEquipment = saveEquipment;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(saveEquipment);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            saveEquipment = reader.ReadBoolean();
        }
    }
}