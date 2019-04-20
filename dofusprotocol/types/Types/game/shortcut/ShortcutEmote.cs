

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ShortcutEmote : Shortcut
    {
        public const short Id = 389;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte emoteId;
        
        public ShortcutEmote()
        {
        }
        
        public ShortcutEmote(sbyte slot, sbyte emoteId)
         : base(slot)
        {
            this.emoteId = emoteId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(emoteId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            emoteId = reader.ReadSByte();
            if (emoteId < 0 || emoteId > 255)
                throw new Exception("Forbidden value on emoteId = " + emoteId + ", it doesn't respect the following condition : emoteId < 0 || emoteId > 255");
        }
        
        
    }
    
}