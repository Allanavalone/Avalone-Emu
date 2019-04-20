using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public const short Id = 512;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.GuildInformations guildInfo;
        
        public HouseGuildedInformations()
        {
        }

        public HouseGuildedInformations(int instanceId, bool secondHand, bool isLocked, string ownerName, long price, bool isSaleLocked, Types.GuildInformations guildInfo)
         : base(instanceId, secondHand, isLocked, ownerName, price, isSaleLocked)
        {
            this.guildInfo = guildInfo;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            guildInfo.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            guildInfo = new Types.GuildInformations();
            guildInfo.Deserialize(reader);
        }
        
        
    }
    
}