

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTeamMemberCompanionInformations : FightTeamMemberInformations
    {
        public const short Id = 451;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte companionId;
        public sbyte level;
        public double masterId;
        
        public FightTeamMemberCompanionInformations()
        {
        }
        
        public FightTeamMemberCompanionInformations(double id, sbyte companionId, sbyte level, double masterId)
         : base(id)
        {
            this.companionId = companionId;
            this.level = level;
            this.masterId = masterId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(companionId);
            writer.WriteSByte(level);
            writer.WriteDouble(masterId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            companionId = reader.ReadSByte();
            if (companionId < 0)
                throw new Exception("Forbidden value on companionId = " + companionId + ", it doesn't respect the following condition : companionId < 0");
            level = reader.ReadSByte();
            if (level < 1 || level > 200)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 1 || level > 200");
            masterId = reader.ReadDouble();
            if (masterId < -9007199254740990 || masterId > 9007199254740990)
                throw new Exception("Forbidden value on masterId = " + masterId + ", it doesn't respect the following condition : masterId < -9007199254740990 || masterId > 9007199254740990");
        }
        
        
    }
    
}