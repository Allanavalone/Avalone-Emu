

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ShortcutObject : Shortcut
    {
        public const short Id = 367;
        public override short TypeId
        {
            get { return Id; }
        }
        
        
        public ShortcutObject()
        {
        }
        
        public ShortcutObject(sbyte slot)
         : base(slot)
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