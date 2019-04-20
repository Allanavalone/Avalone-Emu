

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class AllianceInformations : BasicNamedAllianceInformations
    {
        public const short Id = 417;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.GuildEmblem allianceEmblem;
        
        public AllianceInformations()
        {
        }
        
        public AllianceInformations(int allianceId, string allianceTag, string allianceName, Types.GuildEmblem allianceEmblem)
         : base(allianceId, allianceTag, allianceName)
        {
            this.allianceEmblem = allianceEmblem;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            allianceEmblem.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            allianceEmblem = new Types.GuildEmblem();
            allianceEmblem.Deserialize(reader);
        }
        
        
    }
    
}