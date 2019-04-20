

// Generated on 02/17/2017 01:58:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
    {
        public const uint Id = 6715;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int id;
        
        public InteractiveUseWithParamRequestMessage()
        {
        }
        
        public InteractiveUseWithParamRequestMessage(int elemId, int skillInstanceUid, int id)
         : base(elemId, skillInstanceUid)
        {
            this.id = id;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(id);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            id = reader.ReadInt();
        }
        
    }
    
}