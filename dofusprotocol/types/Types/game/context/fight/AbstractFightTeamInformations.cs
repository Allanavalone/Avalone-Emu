

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class AbstractFightTeamInformations
    {
        public const short Id = 116;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte teamId;
        public double leaderId;
        public sbyte teamSide;
        public sbyte teamTypeId;
        public sbyte nbWaves;
        
        public AbstractFightTeamInformations()
        {
        }
        
        public AbstractFightTeamInformations(sbyte teamId, double leaderId, sbyte teamSide, sbyte teamTypeId, sbyte nbWaves)
        {
            this.teamId = teamId;
            this.leaderId = leaderId;
            this.teamSide = teamSide;
            this.teamTypeId = teamTypeId;
            this.nbWaves = nbWaves;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(teamId);
            writer.WriteDouble(leaderId);
            writer.WriteSByte(teamSide);
            writer.WriteSByte(teamTypeId);
            writer.WriteSByte(nbWaves);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            teamId = reader.ReadSByte();
            leaderId = reader.ReadDouble();
            if (leaderId < -9007199254740990 || leaderId > 9007199254740990)
                throw new Exception("Forbidden value on leaderId = " + leaderId + ", it doesn't respect the following condition : leaderId < -9007199254740990 || leaderId > 9007199254740990");
            teamSide = reader.ReadSByte();
            teamTypeId = reader.ReadSByte();
            nbWaves = reader.ReadSByte();
            if (nbWaves < 0)
                throw new Exception("Forbidden value on nbWaves = " + nbWaves + ", it doesn't respect the following condition : nbWaves < 0");
        }
        
        
    }
    
}