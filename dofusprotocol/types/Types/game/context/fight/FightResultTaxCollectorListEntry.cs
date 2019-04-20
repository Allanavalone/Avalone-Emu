

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightResultTaxCollectorListEntry : FightResultFighterListEntry
    {
        public const short Id = 84;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte level;
        public Types.BasicGuildInformations guildInfo;
        public int experienceForGuild;
        
        public FightResultTaxCollectorListEntry()
        {
        }
        
        public FightResultTaxCollectorListEntry(short outcome, sbyte wave, Types.FightLoot rewards, double id, bool alive, sbyte level, Types.BasicGuildInformations guildInfo, int experienceForGuild)
         : base(outcome, wave, rewards, id, alive)
        {
            this.level = level;
            this.guildInfo = guildInfo;
            this.experienceForGuild = experienceForGuild;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(level);
            guildInfo.Serialize(writer);
            writer.WriteInt(experienceForGuild);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadSByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = "
                    + ", it doesn't respect the following condition : level < 1 || level > 200");
            guildInfo = new Types.BasicGuildInformations();
            guildInfo.Deserialize(reader);
            experienceForGuild = reader.ReadInt();
        }
        
        
    }
    
}