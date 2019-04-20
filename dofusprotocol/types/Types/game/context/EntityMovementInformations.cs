

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class EntityMovementInformations
    {
        public const short Id = 63;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int id;
        public IEnumerable<sbyte> steps;
        
        public EntityMovementInformations()
        {
        }
        
        public EntityMovementInformations(int id, IEnumerable<sbyte> steps)
        {
            this.id = id;
            this.steps = steps;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(id);
            var steps_before = writer.Position;
            var steps_count = 0;
            writer.WriteShort(0);
            foreach (var entry in steps)
            {
                 writer.WriteSByte(entry);
                 steps_count++;
            }
            var steps_after = writer.Position;
            writer.Seek((int)steps_before);
            writer.WriteShort((short)steps_count);
            writer.Seek((int)steps_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadInt();
            var limit = reader.ReadShort();
            var steps_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 steps_[i] = reader.ReadSByte();
            }
            steps = steps_;
        }
        
        
    }
    
}