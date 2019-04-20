

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ShortcutBarContentMessage : Message
    {
        public const uint Id = 6231;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte barType;
        public IEnumerable<Shortcut> shortcuts;
        
        public ShortcutBarContentMessage()
        {
        }
        
        public ShortcutBarContentMessage(sbyte barType, IEnumerable<Shortcut> shortcuts)
        {
            this.barType = barType;
            this.shortcuts = shortcuts;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(barType);
            var shortcuts_before = writer.Position;
            var shortcuts_count = 0;
            writer.WriteShort(0);
            foreach (var entry in shortcuts)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 shortcuts_count++;
            }
            var shortcuts_after = writer.Position;
            writer.Seek((int)shortcuts_before);
            writer.WriteShort((short)shortcuts_count);
            writer.Seek((int)shortcuts_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            barType = reader.ReadSByte();
            var limit = reader.ReadShort();
            var shortcuts_ = new Shortcut[limit];
            for (int i = 0; i < limit; i++)
            {
                 shortcuts_[i] = Types.ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
                 shortcuts_[i].Deserialize(reader);
            }
            shortcuts = shortcuts_;
        }
        
    }
    
}