

// Generated on 02/17/2017 01:57:36
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightPointsVariationMessage : AbstractGameActionMessage
    {
        public const uint Id = 1030;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public double targetId;
        public short delta;
        
        public GameActionFightPointsVariationMessage()
        {
        }
        
        public GameActionFightPointsVariationMessage(short actionId, double sourceId, double targetId, short delta)
         : base(actionId, sourceId)
        {
            this.targetId = targetId;
            this.delta = delta;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(targetId);
            writer.WriteShort(delta);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            targetId = reader.ReadDouble();
            if (targetId < -9007199254740990 || targetId > 9007199254740990)
                throw new Exception("Forbidden value on targetId = " + targetId + ", it doesn't respect the following condition : targetId < -9007199254740990 || targetId > 9007199254740990");
            delta = reader.ReadShort();
        }
        
    }
    
}