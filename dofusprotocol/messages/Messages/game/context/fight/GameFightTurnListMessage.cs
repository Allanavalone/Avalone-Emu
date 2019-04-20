

// Generated on 02/17/2017 01:57:49
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightTurnListMessage : Message
    {
        public const uint Id = 713;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<double> ids;
        public IEnumerable<double> deadsIds;
        
        public GameFightTurnListMessage()
        {
        }
        
        public GameFightTurnListMessage(IEnumerable<double> ids, IEnumerable<double> deadsIds)
        {
            this.ids = ids;
            this.deadsIds = deadsIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var ids_before = writer.Position;
            var ids_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ids)
            {
                 writer.WriteDouble(entry);
                 ids_count++;
            }
            var ids_after = writer.Position;
            writer.Seek((int)ids_before);
            writer.WriteShort((short)ids_count);
            writer.Seek((int)ids_after);

            var deadsIds_before = writer.Position;
            var deadsIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in deadsIds)
            {
                 writer.WriteDouble(entry);
                 deadsIds_count++;
            }
            var deadsIds_after = writer.Position;
            writer.Seek((int)deadsIds_before);
            writer.WriteShort((short)deadsIds_count);
            writer.Seek((int)deadsIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var ids_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 ids_[i] = reader.ReadDouble();
                 if (ids_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on ids_[i] = " + ids_[i] + ", it doesn't respect the following condition : ids_[i] > 9007199254740990");
            }
            ids = ids_;
            limit = reader.ReadShort();
            var deadsIds_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 deadsIds_[i] = reader.ReadDouble();
                 if (deadsIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on deadsIds_[i] = " + deadsIds_[i] + ", it doesn't respect the following condition : deadsIds_[i] > 9007199254740990");
            }
            deadsIds = deadsIds_;
        }
        
    }
    
}