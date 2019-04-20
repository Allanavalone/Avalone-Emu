

// Generated on 02/17/2017 01:57:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameRolePlayShowActorMessage : Message
    {
        public const uint Id = 5632;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public GameRolePlayActorInformations informations;
        
        public GameRolePlayShowActorMessage()
        {
        }
        
        public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
        {
            this.informations = informations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(informations.TypeId);
            informations.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            informations = Types.ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
            informations.Deserialize(reader);
        }
        
    }
    
}