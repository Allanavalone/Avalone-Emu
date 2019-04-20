

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PaddockGuildedInformations : PaddockBuyableInformations
    {
        public const short Id = 508;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public bool deserted;
        public Types.GuildInformations guildInfo;
        
        public PaddockGuildedInformations()
        {
        }
        
        public PaddockGuildedInformations(long price, bool locked, bool deserted, Types.GuildInformations guildInfo)
         : base(price, locked)
        {
            this.deserted = deserted;
            this.guildInfo = guildInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(deserted);
            guildInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            deserted = reader.ReadBoolean();
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
        }
        
        
    }
    
}