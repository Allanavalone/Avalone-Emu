

// Generated on 02/17/2017 01:57:38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceInvitationMessage : Message
    {
        public const uint Id = 6395;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public long targetId;
        
        public AllianceInvitationMessage()
        {
        }
        
        public AllianceInvitationMessage(long targetId)
        {
            this.targetId = targetId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarLong(targetId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            targetId = reader.ReadVarLong();
            if (targetId < 0 || targetId > 9007199254740990)
                throw new Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < 0 || targetId > 9007199254740990");
        }
        
    }
    
}