

// Generated on 02/17/2017 01:58:07
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IgnoredAddRequestMessage : Message
    {
        public const uint Id = 5673;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string name;
        public bool session;
        
        public IgnoredAddRequestMessage()
        {
        }
        
        public IgnoredAddRequestMessage(string name, bool session)
        {
            this.name = name;
            this.session = session;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(name);
            writer.WriteBoolean(session);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            name = reader.ReadUTF();
            session = reader.ReadBoolean();
        }
        
    }
    
}