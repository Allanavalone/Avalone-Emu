

// Generated on 02/17/2017 01:57:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightRefreshFighterMessage : Message
    {
        public const uint Id = 6309;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public GameContextActorInformations informations;
        
        public GameFightRefreshFighterMessage()
        {
        }
        
        public GameFightRefreshFighterMessage(GameContextActorInformations informations)
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
            informations = Types.ProtocolTypeManager.GetInstance<GameContextActorInformations>(reader.ReadShort());
            informations.Deserialize(reader);
        }
        
    }
    
}