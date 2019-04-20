

// Generated on 02/17/2017 01:57:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class HavenBagFurnituresRequestMessage : Message
    {
        public const uint Id = 6637;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> cellIds;
        public IEnumerable<int> funitureIds;
        public IEnumerable<sbyte> orientations;
        
        public HavenBagFurnituresRequestMessage()
        {
        }
        
        public HavenBagFurnituresRequestMessage(IEnumerable<short> cellIds, IEnumerable<int> funitureIds, IEnumerable<sbyte> orientations)
        {
            this.cellIds = cellIds;
            this.funitureIds = funitureIds;
            this.orientations = orientations;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var cellIds_before = writer.Position;
            var cellIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in cellIds)
            {
                 writer.WriteVarShort(entry);
                 cellIds_count++;
            }
            var cellIds_after = writer.Position;
            writer.Seek((int)cellIds_before);
            writer.WriteShort((short)cellIds_count);
            writer.Seek((int)cellIds_after);

            var funitureIds_before = writer.Position;
            var funitureIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in funitureIds)
            {
                 writer.WriteInt(entry);
                 funitureIds_count++;
            }
            var funitureIds_after = writer.Position;
            writer.Seek((int)funitureIds_before);
            writer.WriteShort((short)funitureIds_count);
            writer.Seek((int)funitureIds_after);

            var orientations_before = writer.Position;
            var orientations_count = 0;
            writer.WriteShort(0);
            foreach (var entry in orientations)
            {
                 writer.WriteSByte(entry);
                 orientations_count++;
            }
            var orientations_after = writer.Position;
            writer.Seek((int)orientations_before);
            writer.WriteShort((short)orientations_count);
            writer.Seek((int)orientations_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var cellIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 cellIds_[i] = reader.ReadVarShort();
                 if (cellIds_[i] < 0)
                     throw new Exception("Forbidden value on cellIds_[i] = " + cellIds_[i] + ", it doesn't respect the following condition : cellIds_[i] < 0");
            }
            cellIds = cellIds_;
            limit = reader.ReadShort();
            var funitureIds_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 funitureIds_[i] = reader.ReadInt();
            }
            funitureIds = funitureIds_;
            limit = reader.ReadShort();
            var orientations_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 orientations_[i] = reader.ReadSByte();
                 if (orientations_[i] < 0)
                     throw new Exception("Forbidden value on orientations_[i] = " + orientations_[i] + ", it doesn't respect the following condition : orientations_[i] < 0");
            }
            orientations = orientations_;
        }
        
    }
    
}