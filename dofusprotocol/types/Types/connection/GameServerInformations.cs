

// Generated on 02/17/2017 01:52:51
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameServerInformations
    {
        public const short Id = 25;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short id;
        public sbyte type;
        public sbyte status;
        public sbyte completion;
        public bool isSelectable;
        public sbyte charactersCount;
        public sbyte charactersSlots;
        public double date;
        
        public GameServerInformations()
        {
        }
        
        public GameServerInformations(short id, sbyte type, sbyte status, sbyte completion, bool isSelectable, sbyte charactersCount, sbyte charactersSlots, double date)
        {
            this.id = id;
            this.type = type;
            this.status = status;
            this.completion = completion;
            this.isSelectable = isSelectable;
            this.charactersCount = charactersCount;
            this.charactersSlots = charactersSlots;
            this.date = date;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(id);
            writer.WriteSByte(type);
            writer.WriteSByte(status);
            writer.WriteSByte(completion);
            writer.WriteBoolean(isSelectable);
            writer.WriteSByte(charactersCount);
            writer.WriteSByte(charactersSlots);
            writer.WriteDouble(date);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            type = reader.ReadSByte();
            status = reader.ReadSByte();
            completion = reader.ReadSByte();
            isSelectable = reader.ReadBoolean();
            charactersCount = reader.ReadSByte();
            if (charactersCount < 0)
                throw new Exception("Forbidden value on charactersCount = " + charactersCount + ", it doesn't respect the following condition : charactersCount < 0");
            charactersSlots = reader.ReadSByte();
            if (charactersSlots < 0)
                throw new Exception("Forbidden value on charactersSlots = " + charactersSlots + ", it doesn't respect the following condition : charactersSlots < 0");
            date = reader.ReadDouble();
            if (date < -9007199254740990 || date > 9007199254740990)
                throw new Exception("Forbidden value on date = " + date + ", it doesn't respect the following condition : date < -9007199254740990 || date > 9007199254740990");
        }
        
        
    }
    
}