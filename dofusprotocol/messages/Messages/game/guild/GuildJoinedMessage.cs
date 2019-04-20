

// Generated on 02/17/2017 01:58:10
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GuildJoinedMessage : Message
    {
        public const uint Id = 5564;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public Types.GuildInformations guildInfo;
        public int memberRights;
        
        public GuildJoinedMessage()
        {
        }
        
        public GuildJoinedMessage(Types.GuildInformations guildInfo, int memberRights)
        {
            this.guildInfo = guildInfo;
            this.memberRights = memberRights;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            guildInfo.Serialize(writer);
            writer.WriteVarInt(memberRights);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
            memberRights = reader.ReadVarInt();
            if (memberRights < 0)
                throw new Exception("Forbidden value on memberRights = " + memberRights + ", it doesn't respect the following condition : memberRights < 0");
        }
        
    }
    
}