

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightMonsterWithAlignmentInformations : GameFightMonsterInformations
    {
        public const short Id = 203;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public Types.ActorAlignmentInformations alignmentInfos;
        
        public GameFightMonsterWithAlignmentInformations()
        {
        }
        
        public GameFightMonsterWithAlignmentInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, IEnumerable<short> previousPositions, short creatureGenericId, sbyte creatureGrade, Types.ActorAlignmentInformations alignmentInfos)
         : base(contextualId, look, disposition, teamId, wave, alive, stats, previousPositions, creatureGenericId, creatureGrade)
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