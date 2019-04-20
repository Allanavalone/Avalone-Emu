

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayPrismInformations : GameRolePlayActorInformations
    {
        public const short Id = 161;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public PrismInformation prism;
        
        public GameRolePlayPrismInformations()
        {
        }
        
        public GameRolePlayPrismInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, PrismInformation prism)
         : base(contextualId, look, disposition)
        {
            this.prism = prism;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(prism.TypeId);
            prism.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            prism = Types.ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
            prism.Deserialize(reader);
        }
        
        
    }
    
}