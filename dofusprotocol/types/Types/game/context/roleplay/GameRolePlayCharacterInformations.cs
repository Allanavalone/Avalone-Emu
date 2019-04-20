

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
    {
        public const short Id = 36;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.ActorAlignmentInformations alignmentInfos;
        
        public GameRolePlayCharacterInformations()
        {
        }
        
        public GameRolePlayCharacterInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId, Types.ActorAlignmentInformations alignmentInfos)
         : base(contextualId, look, disposition, name, humanoidInfo, accountId)
        {
            this.alignmentInfos = alignmentInfos;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            alignmentInfos.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            alignmentInfos = new Types.ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
        }
        
        
    }
    
}