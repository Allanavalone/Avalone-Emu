

// Generated on 02/17/2017 01:52:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
    {
        public const short Id = 471;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short npcId;
        
        public GameRolePlayTreasureHintInformations()
        {
        }
        
        public GameRolePlayTreasureHintInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, short npcId)
         : base(contextualId, look, disposition)
        {
            this.npcId = npcId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(npcId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            npcId = reader.ReadVarShort();
            if (npcId < 0)
                throw new Exception("Forbidden value on npcId = " + npcId + ", it doesn't respect the following condition : npcId < 0");
        }
        
        
    }
    
}