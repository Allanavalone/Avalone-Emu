

// Generated on 02/17/2017 01:57:53
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public const uint Id = 5691;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<double> actorIds;
        
        public EmotePlayMassiveMessage()
        {
        }
        
        public EmotePlayMassiveMessage(byte emoteId, double emoteStartTime, IEnumerable<double> actorIds)
         : base(emoteId, emoteStartTime)
        {
            this.actorIds = actorIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var actorIds_before = writer.Position;
            var actorIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in actorIds)
            {
                 writer.WriteDouble(entry);
                 actorIds_count++;
            }
            var actorIds_after = writer.Position;
            writer.Seek((int)actorIds_before);
            writer.WriteShort((short)actorIds_count);
            writer.Seek((int)actorIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var actorIds_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 actorIds_[i] = reader.ReadDouble();
                 if (actorIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on actorIds_[i] = " + actorIds_[i] + ", it doesn't respect the following condition : actorIds_[i] > 9007199254740990");
            }
            actorIds = actorIds_;
        }
        
    }
    
}