

// Generated on 02/17/2017 01:58:12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class InteractiveMapUpdateMessage : Message
    {
        public const uint Id = 5002;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<InteractiveElement> interactiveElements;
        
        public InteractiveMapUpdateMessage()
        {
        }
        
        public InteractiveMapUpdateMessage(IEnumerable<InteractiveElement> interactiveElements)
        {
            this.interactiveElements = interactiveElements;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var interactiveElements_before = writer.Position;
            var interactiveElements_count = 0;
            writer.WriteShort(0);
            foreach (var entry in interactiveElements)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 interactiveElements_count++;
            }
            var interactiveElements_after = writer.Position;
            writer.Seek((int)interactiveElements_before);
            writer.WriteShort((short)interactiveElements_count);
            writer.Seek((int)interactiveElements_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var interactiveElements_ = new InteractiveElement[limit];
            for (int i = 0; i < limit; i++)
            {
                 interactiveElements_[i] = Types.ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
                 interactiveElements_[i].Deserialize(reader);
            }
            interactiveElements = interactiveElements_;
        }
        
    }
    
}