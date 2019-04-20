

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ObjectEffectDice : ObjectEffect
    {
        public const short Id = 73;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short diceNum;
        public short diceSide;
        public short diceConst;
        
        public ObjectEffectDice()
        {
        }
        
        public ObjectEffectDice(short actionId, short diceNum, short diceSide, short diceConst)
         : base(actionId)
        {
            this.diceNum = diceNum;
            this.diceSide = diceSide;
            this.diceConst = diceConst;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(diceNum);
            writer.WriteVarShort(diceSide);
            writer.WriteVarShort(diceConst);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            diceNum = reader.ReadVarShort();
            if (diceNum < 0)
                throw new Exception("Forbidden value on diceNum = " + diceNum + ", it doesn't respect the following condition : diceNum < 0");
            diceSide = reader.ReadVarShort();
            if (diceSide < 0)
                throw new Exception("Forbidden value on diceSide = " + diceSide + ", it doesn't respect the following condition : diceSide < 0");
            diceConst = reader.ReadVarShort();
            if (diceConst < 0)
                throw new Exception("Forbidden value on diceConst = " + diceConst + ", it doesn't respect the following condition : diceConst < 0");
        }
        
        
    }
    
}