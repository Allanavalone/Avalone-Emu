

// Generated on 02/17/2017 01:57:39
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceJoinedMessage : Message
    {
        public const uint Id = 6402;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.AllianceInformations allianceInfo;
        public bool enabled;
        public int leadingGuildId;
        
        public AllianceJoinedMessage()
        {
        }
        
        public AllianceJoinedMessage(Types.AllianceInformations allianceInfo, bool enabled, int leadingGuildId)
        {
            this.allianceInfo = allianceInfo;
            this.enabled = enabled;
            this.leadingGuildId = leadingGuildId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            allianceInfo.Serialize(writer);
            writer.WriteBoolean(enabled);
            writer.WriteVarInt(leadingGuildId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            allianceInfo = new Types.AllianceInformations();
            allianceInfo.Deserialize(reader);
            enabled = reader.ReadBoolean();
            leadingGuildId = reader.ReadVarInt();
            if (leadingGuildId < 0)
                throw new Exception("Forbidden value on leadingGuildId = " + leadingGuildId + ", it doesn't respect the following condition : leadingGuildId < 0");
        }
        
    }
    
}