

// Generated on 02/17/2017 01:58:09
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildInvitationStateRecrutedMessage : Message
    {
        public const uint Id = 5548;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte invitationState;
        
        public GuildInvitationStateRecrutedMessage()
        {
        }
        
        public GuildInvitationStateRecrutedMessage(sbyte invitationState)
        {
            this.invitationState = invitationState;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(invitationState);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            invitationState = reader.ReadSByte();
        }
        
    }
    
}