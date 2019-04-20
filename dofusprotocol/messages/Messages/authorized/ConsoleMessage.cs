

// Generated on 02/17/2017 01:57:31
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ConsoleMessage : Message
    {
        public const uint Id = 75;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public string content;
        
        public ConsoleMessage()
        {
        }
        
        public ConsoleMessage(sbyte type, string content)
        {
            this.type = type;
            this.content = content;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(type);
            writer.WriteUTF(content);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            type = reader.ReadSByte();
            content = reader.ReadUTF();
        }
        
    }
    
}