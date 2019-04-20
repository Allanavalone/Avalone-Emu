

// Generated on 02/17/2017 01:58:13
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class TeleportDestinationsListMessage : Message
    {
        public const uint Id = 5960;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public sbyte teleporterType;
        public IEnumerable<int> mapIds;
        public IEnumerable<short> subAreaIds;
        public IEnumerable<short> costs;
        public IEnumerable<sbyte> destTeleporterType;
        
        public TeleportDestinationsListMessage()
        {
        }
        
        public TeleportDestinationsListMessage(sbyte teleporterType, IEnumerable<int> mapIds, IEnumerable<short> subAreaIds, IEnumerable<short> costs, IEnumerable<sbyte> destTeleporterType)
        {
            this.teleporterType = teleporterType;
            this.mapIds = mapIds;
            this.subAreaIds = subAreaIds;
            this.costs = costs;
            this.destTeleporterType = destTeleporterType;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(teleporterType);
            var mapIds_before = writer.Position;
            var mapIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in mapIds)
            {
                 writer.WriteInt(entry);
                 mapIds_count++;
            }
            var mapIds_after = writer.Position;
            writer.Seek((int)mapIds_before);
            writer.WriteShort((short)mapIds_count);
            writer.Seek((int)mapIds_after);

            var subAreaIds_before = writer.Position;
            var subAreaIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in subAreaIds)
            {
                 writer.WriteVarShort(entry);
                 subAreaIds_count++;
            }
            var subAreaIds_after = writer.Position;
            writer.Seek((int)subAreaIds_before);
            writer.WriteShort((short)subAreaIds_count);
            writer.Seek((int)subAreaIds_after);

            var costs_before = writer.Position;
            var costs_count = 0;
            writer.WriteShort(0);
            foreach (var entry in costs)
            {
                 writer.WriteVarShort(entry);
                 costs_count++;
            }
            var costs_after = writer.Position;
            writer.Seek((int)costs_before);
            writer.WriteShort((short)costs_count);
            writer.Seek((int)costs_after);

            var destTeleporterType_before = writer.Position;
            var destTeleporterType_count = 0;
            writer.WriteShort(0);
            foreach (var entry in destTeleporterType)
            {
                 writer.WriteSByte(entry);
                 destTeleporterType_count++;
            }
            var destTeleporterType_after = writer.Position;
            writer.Seek((int)destTeleporterType_before);
            writer.WriteShort((short)destTeleporterType_count);
            writer.Seek((int)destTeleporterType_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            teleporterType = reader.ReadSByte();
            var limit = reader.ReadShort();
            var mapIds_ = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 mapIds_[i] = reader.ReadInt();
                 if (mapIds_[i] < 0)
                     throw new Exception("Forbidden value on mapIds_[i] = " + mapIds_[i] + ", it doesn't respect the following condition : mapIds_[i] < 0");
            }
            mapIds = mapIds_;
            limit = reader.ReadShort();
            var subAreaIds_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 subAreaIds_[i] = reader.ReadVarShort();
                 if (subAreaIds_[i] < 0)
                     throw new Exception("Forbidden value on subAreaIds_[i] = " + subAreaIds_[i] + ", it doesn't respect the following condition : subAreaIds_[i] < 0");
            }
            subAreaIds = subAreaIds_;
            limit = reader.ReadShort();
            var costs_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 costs_[i] = reader.ReadVarShort();
                 if (costs_[i] < 0)
                     throw new Exception("Forbidden value on costs_[i] = " + costs_[i] + ", it doesn't respect the following condition : costs_[i] < 0");
            }
            costs = costs_;
            limit = reader.ReadShort();
            var destTeleporterType_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 destTeleporterType_[i] = reader.ReadSByte();
            }
            destTeleporterType = destTeleporterType_;
        }
        
    }
    
}