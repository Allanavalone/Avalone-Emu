

// Generated on 02/17/2017 01:57:38
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AllianceCreationValidMessage : Message
    {
        public const uint Id = 6393;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public string allianceName;
        public string allianceTag;
        public Types.GuildEmblem allianceEmblem;
        
        public AllianceCreationValidMessage()
        {
        }
        
        public AllianceCreationValidMessage(string allianceName, string allianceTag, Types.GuildEmblem allianceEmblem)
        {
            this.allianceName = allianceName;
            this.allianceTag = allianceTag;
            this.allianceEmblem = allianceEmblem;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(allianceName);
            writer.WriteUTF(allianceTag);
            allianceEmblem.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            allianceName = reader.ReadUTF();
            allianceTag = reader.ReadUTF();
            allianceEmblem = new Types.GuildEmblem();
            allianceEmblem.Deserialize(reader);
        }
        
    }
    
}