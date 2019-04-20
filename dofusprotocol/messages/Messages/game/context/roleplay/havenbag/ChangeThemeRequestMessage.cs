

// Generated on 02/17/2017 01:57:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ChangeThemeRequestMessage : Message
    {
        public const uint Id = 6639;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte theme;
        
        public ChangeThemeRequestMessage()
        {
        }
        
        public ChangeThemeRequestMessage(sbyte theme)
        {
            this.theme = theme;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(theme);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            theme = reader.ReadSByte();
        }
        
    }
    
}