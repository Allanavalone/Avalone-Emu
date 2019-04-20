

// Generated on 02/17/2017 01:57:46
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameContextRemoveMultipleElementsMessage : Message
    {
        public const uint Id = 252;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<double> elementsIds;
        
        public GameContextRemoveMultipleElementsMessage()
        {
        }
        
        public GameContextRemoveMultipleElementsMessage(IEnumerable<double> elementsIds)
        {
            this.elementsIds = elementsIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var elementsIds_before = writer.Position;
            var elementsIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in elementsIds)
            {
                 writer.WriteDouble(entry);
                 elementsIds_count++;
            }
            var elementsIds_after = writer.Position;
            writer.Seek((int)elementsIds_before);
            writer.WriteShort((short)elementsIds_count);
            writer.Seek((int)elementsIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var elementsIds_ = new double[limit];
            for (int i = 0; i < limit; i++)
            {
                 elementsIds_[i] = reader.ReadDouble();
                 if (elementsIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on elementsIds_[i] = " + elementsIds_[i] + ", it doesn't respect the following condition : elementsIds_[i] > 9007199254740990");
            }
            elementsIds = elementsIds_;
        }
        
    }
    
}