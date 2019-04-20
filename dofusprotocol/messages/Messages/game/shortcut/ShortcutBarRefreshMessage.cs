

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ShortcutBarRefreshMessage : Message
    {
        public const uint Id = 6229;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte barType;
        public Shortcut shortcut;
        
        public ShortcutBarRefreshMessage()
        {
        }
        
        public ShortcutBarRefreshMessage(sbyte barType, Shortcut shortcut)
        {
            this.barType = barType;
            this.shortcut = shortcut;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(barType);
            writer.WriteShort(shortcut.TypeId);
            shortcut.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            barType = reader.ReadSByte();
            shortcut = Types.ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
            shortcut.Deserialize(reader);
        }
        
    }
    
}