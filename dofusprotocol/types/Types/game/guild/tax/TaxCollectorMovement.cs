

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class TaxCollectorMovement
    {
        public const short Id = 493;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte movementType;
        public Types.TaxCollectorBasicInformations basicInfos;
        public long playerId;
        public string playerName;
        
        public TaxCollectorMovement()
        {
        }
        
        public TaxCollectorMovement(sbyte movementType, Types.TaxCollectorBasicInformations basicInfos, long playerId, string playerName)
        {
            this.movementType = movementType;
            this.basicInfos = basicInfos;
            this.playerId = playerId;
            this.playerName = playerName;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(movementType);
            basicInfos.Serialize(writer);
            writer.WriteVarLong(playerId);
            writer.WriteUTF(playerName);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            movementType = reader.ReadSByte();
            basicInfos = new Types.TaxCollectorBasicInformations();
            basicInfos.Deserialize(reader);
            playerId = reader.ReadVarLong();
            if (playerId < 0 || playerId > 9007199254740990)
                throw new Exception("Forbidden value on playerId = " + playerId + ", it doesn't respect the following condition : playerId < 0 || playerId > 9007199254740990");
            playerName = reader.ReadUTF();
        }
        
        
    }
    
}