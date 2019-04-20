

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightCommonInformations
    {
        public const short Id = 43;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int fightId;
        public sbyte fightType;
        public IEnumerable<FightTeamInformations> fightTeams;
        public IEnumerable<short> fightTeamsPositions;
        public IEnumerable<Types.FightOptionsInformations> fightTeamsOptions;
        
        public FightCommonInformations()
        {
        }
        
        public FightCommonInformations(int fightId, sbyte fightType, IEnumerable<FightTeamInformations> fightTeams, IEnumerable<short> fightTeamsPositions, IEnumerable<Types.FightOptionsInformations> fightTeamsOptions)
        {
            this.fightId = fightId;
            this.fightType = fightType;
            this.fightTeams = fightTeams;
            this.fightTeamsPositions = fightTeamsPositions;
            this.fightTeamsOptions = fightTeamsOptions;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(fightId);
            writer.WriteSByte(fightType);
            var fightTeams_before = writer.Position;
            var fightTeams_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fightTeams)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 fightTeams_count++;
            }
            var fightTeams_after = writer.Position;
            writer.Seek((int)fightTeams_before);
            writer.WriteShort((short)fightTeams_count);
            writer.Seek((int)fightTeams_after);

            var fightTeamsPositions_before = writer.Position;
            var fightTeamsPositions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fightTeamsPositions)
            {
                 writer.WriteVarShort(entry);
                 fightTeamsPositions_count++;
            }
            var fightTeamsPositions_after = writer.Position;
            writer.Seek((int)fightTeamsPositions_before);
            writer.WriteShort((short)fightTeamsPositions_count);
            writer.Seek((int)fightTeamsPositions_after);

            var fightTeamsOptions_before = writer.Position;
            var fightTeamsOptions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in fightTeamsOptions)
            {
                 entry.Serialize(writer);
                 fightTeamsOptions_count++;
            }
            var fightTeamsOptions_after = writer.Position;
            writer.Seek((int)fightTeamsOptions_before);
            writer.WriteShort((short)fightTeamsOptions_count);
            writer.Seek((int)fightTeamsOptions_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            fightId = reader.ReadInt();
            fightType = reader.ReadSByte();
            var limit = reader.ReadShort();
            var fightTeams_ = new FightTeamInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeams_[i] = Types.ProtocolTypeManager.GetInstance<FightTeamInformations>(reader.ReadShort());
                 fightTeams_[i].Deserialize(reader);
            }
            fightTeams = fightTeams_;
            limit = reader.ReadShort();
            var fightTeamsPositions_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeamsPositions_[i] = reader.ReadVarShort();
                 if (fightTeamsPositions_[i] > 559)
                     throw new Exception("Forbidden value on fightTeamsPositions_[i] = " + fightTeamsPositions_[i] + ", it doesn't respect the following condition : fightTeamsPositions_[i] > 559");
            }
            fightTeamsPositions = fightTeamsPositions_;
            limit = reader.ReadShort();
            var fightTeamsOptions_ = new Types.FightOptionsInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 fightTeamsOptions_[i] = new Types.FightOptionsInformations();
                 fightTeamsOptions_[i].Deserialize(reader);
            }
            fightTeamsOptions = fightTeamsOptions_;
        }
        
        
    }
    
}