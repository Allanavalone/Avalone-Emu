

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightAIInformations : GameFightFighterInformations
    {
        public const short Id = 151;
        public override short TypeId
        {
            get { return Id; }
        }
        
        
        public GameFightAIInformations()
        {
        }
        
        public GameFightAIInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, IEnumerable<short> previousPositions)
         : base(contextualId, look, disposition, teamId, wave, alive, stats, previousPositions)
        {
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }
        
        
    }
    
}