

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightExternalInformations
    {
        public const short Id = 117;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int fightId;
        public sbyte fightType;
        public int fightStart;
        public bool fightSpectatorLocked;
        public IEnumerable<Types.FightTeamLightInformations> fightTeams;
        public IEnumerable<Types.FightOptionsInformations> fightTeamsOptions;
        
        public FightExternalInformations()
        {
        }
        
        public FightExternalInformations(int fightId, sbyte fightType, int fightStart, bool fightSpectatorLocked, IEnumerable<Types.FightTeamLightInformations> fightTeams, IEnumerable<Types.FightOptionsInformations> fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightStart = fightStart;
            this.fightSpectatorLocked = fightSpectatorLocked;
            this.fightTeams = fightTeams;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteSByte(fightType);
            writer.WriteInt(fightStart);
            writer.WriteBoolean(fightSpectatorLocked);
            foreach (var entry in fightTeams)
            {
                 entry.Serialize(writer);
            }
            foreach (var entry in fightTeamsOptions)
            {
                 entry.Serialize(writer);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            fightType = reader.ReadSByte();
            fightStart = reader.ReadInt();
            if (fightStart < 0)
                throw new Exception("Forbidden value on fightStart = " + fightStart + ", it doesn't respect the following condition : fightStart < 0");
            fightSpectatorLocked = reader.ReadBoolean();
            var fightTeams_ = new Types.FightTeamLightInformations[2];
            for (int i = 0; i < 2; i++)
            {
                 fightTeams_[i] = new Types.FightTeamLightInformations();
                 fightTeams_[i].Deserialize(reader);
            }
            fightTeams = fightTeams_;
            var fightTeamsOptions_ = new Types.FightOptionsInformations[2];
            for (int i = 0; i < 2; i++)
            {
                 fightTeamsOptions_[i] = new Types.FightOptionsInformations();
                 fightTeamsOptions_[i].Deserialize(reader);
            }
            fightTeamsOptions = fightTeamsOptions_;
        }
        
        
    }
    
}