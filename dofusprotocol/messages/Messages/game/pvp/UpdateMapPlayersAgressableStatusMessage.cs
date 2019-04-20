

// Generated on 02/17/2017 01:58:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class UpdateMapPlayersAgressableStatusMessage : Message
    {
        public const uint Id = 6454;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<long> playerIds;
        public IEnumerable<sbyte> enable;
        
        public UpdateMapPlayersAgressableStatusMessage()
        {
        }
        
        public UpdateMapPlayersAgressableStatusMessage(IEnumerable<long> playerIds, IEnumerable<sbyte> enable)
        {
            this.playerIds = playerIds;
            this.enable = enable;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var playerIds_before = writer.Position;
            var playerIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in playerIds)
            {
                 writer.WriteVarLong(entry);
                 playerIds_count++;
            }
            var playerIds_after = writer.Position;
            writer.Seek((int)playerIds_before);
            writer.WriteShort((short)playerIds_count);
            writer.Seek((int)playerIds_after);

            var enable_before = writer.Position;
            var enable_count = 0;
            writer.WriteShort(0);
            foreach (var entry in enable)
            {
                 writer.WriteSByte(entry);
                 enable_count++;
            }
            var enable_after = writer.Position;
            writer.Seek((int)enable_before);
            writer.WriteShort((short)enable_count);
            writer.Seek((int)enable_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var playerIds_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 playerIds_[i] = reader.ReadVarLong();
                 if (playerIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on playerIds_[i] = " + playerIds_[i] + ", it doesn't respect the following condition : playerIds_[i] > 9007199254740990");
            }
            playerIds = playerIds_;
            limit = reader.ReadShort();
            var enable_ = new sbyte[limit];
            for (int i = 0; i < limit; i++)
            {
                 enable_[i] = reader.ReadSByte();
            }
            enable = enable_;
        }
        
    }
    
}