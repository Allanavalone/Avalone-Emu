

// Generated on 02/17/2017 01:58:21
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InventoryContentAndPresetMessage : InventoryContentMessage
    {
        public const uint Id = 6162;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.Preset> presets;
        public IEnumerable<Types.IdolsPreset> idolsPresets;
        
        public InventoryContentAndPresetMessage()
        {
        }
        
        public InventoryContentAndPresetMessage(IEnumerable<Types.ObjectItem> objects, long kamas, IEnumerable<Types.Preset> presets, IEnumerable<Types.IdolsPreset> idolsPresets)
         : base(objects, kamas)
        {
            this.presets = presets;
            this.idolsPresets = idolsPresets;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var presets_before = writer.Position;
            var presets_count = 0;
            writer.WriteShort(0);
            foreach (var entry in presets)
            {
                 entry.Serialize(writer);
                 presets_count++;
            }
            var presets_after = writer.Position;
            writer.Seek((int)presets_before);
            writer.WriteShort((short)presets_count);
            writer.Seek((int)presets_after);

            var idolsPresets_before = writer.Position;
            var idolsPresets_count = 0;
            writer.WriteShort(0);
            foreach (var entry in idolsPresets)
            {
                 entry.Serialize(writer);
                 idolsPresets_count++;
            }
            var idolsPresets_after = writer.Position;
            writer.Seek((int)idolsPresets_before);
            writer.WriteShort((short)idolsPresets_count);
            writer.Seek((int)idolsPresets_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var presets_ = new Types.Preset[limit];
            for (int i = 0; i < limit; i++)
            {
                 presets_[i] = new Types.Preset();
                 presets_[i].Deserialize(reader);
            }
            presets = presets_;
            limit = reader.ReadShort();
            var idolsPresets_ = new Types.IdolsPreset[limit];
            for (int i = 0; i < limit; i++)
            {
                 idolsPresets_[i] = new Types.IdolsPreset();
                 idolsPresets_[i].Deserialize(reader);
            }
            idolsPresets = idolsPresets_;
        }
        
    }
    
}