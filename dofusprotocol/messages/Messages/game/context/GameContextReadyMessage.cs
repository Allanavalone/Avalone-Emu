

// Generated on 02/17/2017 01:57:46
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameContextReadyMessage : Message
    {
        public const uint Id = 6071;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public int mapId;
        
        public GameContextReadyMessage()
        {
        }
        
        public GameContextReadyMessage(int mapId)
        {
            this.mapId = mapId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(mapId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            mapId = reader.ReadInt();
            if (mapId < 0)
                throw new Exception("Forbidden value on mapId = " + mapId + ", it doesn't respect the following condition : mapId < 0");
        }
        
    }
    
}