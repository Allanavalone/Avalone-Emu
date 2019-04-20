

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayPortalInformations : GameRolePlayActorInformations
    {
        public const short Id = 467;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public PortalInformation portal;
        
        public GameRolePlayPortalInformations()
        {
        }
        
        public GameRolePlayPortalInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, PortalInformation portal)
         : base(contextualId, look, disposition)
        {
            this.portal = portal;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(portal.TypeId);
            portal.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            portal = Types.ProtocolTypeManager.GetInstance<PortalInformation>(reader.ReadShort());
            portal.Deserialize(reader);
        }
        
        
    }
    
}