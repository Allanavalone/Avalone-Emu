

// Generated on 02/17/2017 01:57:35
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public const uint Id = 6070;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public AbstractFightDispellableEffect effect;
        
        public GameActionFightDispellableEffectMessage()
        {
        }
        
        public GameActionFightDispellableEffectMessage(short actionId, double sourceId, AbstractFightDispellableEffect effect)
         : base(actionId, sourceId)
        {
            this.effect = effect;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(effect.TypeId);
            effect.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            effect = Types.ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
            effect.Deserialize(reader);
        }
        
    }
    
}