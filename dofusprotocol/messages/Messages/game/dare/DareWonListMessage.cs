

// Generated on 02/17/2017 01:58:06
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class DareWonListMessage : Message
    {
        public const uint Id = 6682;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<double> dareId;
        
        public DareWonListMessage()
        {
        }
        
        public DareWonListMessage(IEnumerable<double> dareId)
        {
            this.dareId = dareId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var dareId_before = writer.Position;
            var dareId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in dareId)
            {
                 writer.WriteDouble(entry);
                 dareId_count++;
            }
            var dareId_after = writer.Position;
            writer.Seek((int)dareId_before);
            writer.WriteShort((short)dareId_count);
            writer.Seek((int)dareId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var dareId_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 dareId_[i] = reader.ReadDouble();
                 if (dareId_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on dareId_[i] = " + dareId_[i] + ", it doesn't respect the following condition : dareId_[i] > 9007199254740990");
            }
            dareId = dareId_;
        }
        
    }
    
}