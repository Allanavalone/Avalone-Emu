

// Generated on 02/17/2017 01:57:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class MapFightStartPositionsUpdateMessage : Message
    {
        public const uint Id = 6716;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int mapId;
        public Types.FightStartingPositions fightStartPositions;
        
        public MapFightStartPositionsUpdateMessage()
        {
        }
        
        public MapFightStartPositionsUpdateMessage(int mapId, Types.FightStartingPositions fightStartPositions)
        {
            this.mapId = mapId;
            this.fightStartPositions = fightStartPositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
            fightStartPositions.Serialize(writer);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
            fightStartPositions = new Types.FightStartingPositions();
            fightStartPositions.Deserialize(reader);
        }
        
    }
    
}