

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AcquaintanceSearchMessage : Message
    {
        public const uint Id = 6144;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string nickname;
        
        public AcquaintanceSearchMessage()
        {
        }
        
        public AcquaintanceSearchMessage(string nickname)
        {
            this.nickname = nickname;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(nickname);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            nickname = reader.ReadUTF();
        }
        
    }
    
}