

// Generated on 02/17/2017 01:57:32
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class BasicStatWithDataMessage : BasicStatMessage
    {
        public const uint Id = 6573;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<StatisticData> datas;
        
        public BasicStatWithDataMessage()
        {
        }
        
        public BasicStatWithDataMessage(double timeSpent, short statId, IEnumerable<StatisticData> datas)
         : base(timeSpent, statId)
        {
            this.datas = datas;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var datas_before = writer.Position;
            var datas_count = 0;
            writer.WriteShort(0);
            foreach (var entry in datas)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 datas_count++;
            }
            var datas_after = writer.Position;
            writer.Seek((int)datas_before);
            writer.WriteShort((short)datas_count);
            writer.Seek((int)datas_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var datas_ = new StatisticData[limit];
            for (int i = 0; i < limit; i++)
            {
                 datas_[i] = Types.ProtocolTypeManager.GetInstance<StatisticData>(reader.ReadShort());
                 datas_[i].Deserialize(reader);
            }
            datas = datas_;
        }
        
    }
    
}