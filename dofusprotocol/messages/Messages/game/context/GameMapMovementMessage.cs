

// Generated on 02/17/2017 01:57:46
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameMapMovementMessage : Message
    {
        public const uint Id = 951;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> keyMovements;
        public short forcedDirection;
        public double actorId;
        
        public GameMapMovementMessage()
        {
        }
        
        public GameMapMovementMessage(IEnumerable<short> keyMovements, short forcedDirection, double actorId)
        {
            this.keyMovements = keyMovements;
            this.forcedDirection = forcedDirection;
            this.actorId = actorId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var keyMovements_before = writer.Position;
            var keyMovements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in keyMovements)
            {
                 writer.WriteShort(entry);
                 keyMovements_count++;
            }
            var keyMovements_after = writer.Position;
            writer.Seek((int)keyMovements_before);
            writer.WriteShort((short)keyMovements_count);
            writer.Seek((int)keyMovements_after);

            writer.WriteShort(forcedDirection);
            writer.WriteDouble(actorId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var keyMovements_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 keyMovements_[i] = reader.ReadShort();
                 if (keyMovements_[i] < 0)
                     throw new Exception("Forbidden value on keyMovements_[i] = " + keyMovements_[i] + ", it doesn't respect the following condition : keyMovements_[i] < 0");
            }
            keyMovements = keyMovements_;
            forcedDirection = reader.ReadShort();
            actorId = reader.ReadDouble();
            if (actorId < -9007199254740990 || actorId > 9007199254740990)
                throw new Exception("Forbidden value on actorId = " + actorId + ", it doesn't respect the following condition : actorId < -9007199254740990 || actorId > 9007199254740990");
        }
        
    }
    
}