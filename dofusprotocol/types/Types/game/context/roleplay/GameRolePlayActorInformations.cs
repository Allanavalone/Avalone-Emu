

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayActorInformations : GameContextActorInformations
    {
        public const short Id = 141;
        public override short TypeId
        {
            get { return Id; }
        }
        
        
        public GameRolePlayActorInformations()
        {
        }
        
        public GameRolePlayActorInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition)
         : base(contextualId, look, disposition)
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