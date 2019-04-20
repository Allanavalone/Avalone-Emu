

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
    {
        public const short Id = 3;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short monsterId;
        public sbyte powerLevel;
        
        public GameRolePlayMutantInformations()
        {
        }
        
        public GameRolePlayMutantInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId, short monsterId, sbyte powerLevel)
         : base(contextualId, look, disposition, name, humanoidInfo, accountId)
        {
            this.monsterId = monsterId;
            this.powerLevel = powerLevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(monsterId);
            writer.WriteSByte(powerLevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            monsterId = reader.ReadVarShort();
            if (monsterId < 0)
                throw new Exception("Forbidden value on monsterId = " + monsterId + ", it doesn't respect the following condition : monsterId < 0");
            powerLevel = reader.ReadSByte();
        }
        
        
    }
    
}