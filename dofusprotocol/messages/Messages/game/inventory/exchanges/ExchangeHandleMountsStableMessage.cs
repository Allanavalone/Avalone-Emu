

// Generated on 02/17/2017 01:58:15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class ExchangeHandleMountsStableMessage : Message
    {
        public const uint Id = 6562;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte actionType;
        public IEnumerable<int> ridesId;
        
        public ExchangeHandleMountsStableMessage()
        {
        }
        
        public ExchangeHandleMountsStableMessage(sbyte actionType, IEnumerable<int> ridesId)
        {
            this.actionType = actionType;
            this.ridesId = ridesId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(actionType);
            var ridesId_before = writer.Position;
            var ridesId_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ridesId)
            {
                 writer.WriteVarInt(entry);
                 ridesId_count++;
            }
            var ridesId_after = writer.Position;
            writer.Seek((int)ridesId_before);
            writer.WriteShort((short)ridesId_count);
            writer.Seek((int)ridesId_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            actionType = reader.ReadSByte();
            var limit = reader.ReadShort();
            var ridesId_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 ridesId_[i] = reader.ReadVarInt();
                 if (ridesId_[i] < 0)
                     throw new Exception("Forbidden value on ridesId_[i] = " + ridesId_[i] + ", it doesn't respect the following condition : ridesId_[i] < 0");
            }
            ridesId = ridesId_;
        }
        
    }
    
}