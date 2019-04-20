

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class EnterHavenBagRequestMessage : Message
    {
        public const uint Id = 6636;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long havenBagOwner;
        
        public EnterHavenBagRequestMessage()
        {
        }
        
        public EnterHavenBagRequestMessage(long havenBagOwner)
        {
            this.havenBagOwner = havenBagOwner;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(havenBagOwner);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            havenBagOwner = reader.ReadVarLong();
            if (havenBagOwner < 0 || havenBagOwner > 9007199254740990)
                throw new Exception("Forbidden value on havenBagOwner = " + havenBagOwner + ", it doesn't respect the following condition : havenBagOwner < 0 || havenBagOwner > 9007199254740990");
        }
        
    }
    
}