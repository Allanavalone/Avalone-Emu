

// Generated on 02/17/2017 01:57:37
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameActionFightTackledMessage : AbstractGameActionMessage
    {
        public const uint Id = 1004;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<double> tacklersIds;
        
        public GameActionFightTackledMessage()
        {
        }
        
        public GameActionFightTackledMessage(short actionId, double sourceId, IEnumerable<double> tacklersIds)
         : base(actionId, sourceId)
        {
            this.tacklersIds = tacklersIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var tacklersIds_before = writer.Position;
            var tacklersIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in tacklersIds)
            {
                 writer.WriteDouble(entry);
                 tacklersIds_count++;
            }
            var tacklersIds_after = writer.Position;
            writer.Seek((int)tacklersIds_before);
            writer.WriteShort((short)tacklersIds_count);
            writer.Seek((int)tacklersIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var tacklersIds_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 tacklersIds_[i] = reader.ReadDouble();
                 if (tacklersIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on tacklersIds_[i] = " + tacklersIds_[i] + ", it doesn't respect the following condition : tacklersIds_[i] > 9007199254740990");
            }
            tacklersIds = tacklersIds_;
        }
        
    }
    
}