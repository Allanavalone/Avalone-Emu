

// Generated on 02/17/2017 01:53:03
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class StatedElement
    {
        public const short Id = 108;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int elementId;
        public short elementCellId;
        public int elementState;
        public bool onCurrentMap;
        
        public StatedElement()
        {
        }
        
        public StatedElement(int elementId, short elementCellId, int elementState, bool onCurrentMap)
        {
            this.elementId = elementId;
            this.elementCellId = elementCellId;
            this.elementState = elementState;
            this.onCurrentMap = onCurrentMap;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(elementId);
            writer.WriteVarShort(elementCellId);
            writer.WriteVarInt(elementState);
            writer.WriteBoolean(onCurrentMap);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            elementId = reader.ReadInt();
            if (elementId < 0)
                throw new Exception("Forbidden value on elementId = " + elementId + ", it doesn't respect the following condition : elementId < 0");
            elementCellId = reader.ReadVarShort();
            if (elementCellId < 0 || elementCellId > 559)
                throw new Exception("Forbidden value on elementCellId = " + elementCellId + ", it doesn't respect the following condition : elementCellId < 0 || elementCellId > 559");
            elementState = reader.ReadVarInt();
            if (elementState < 0)
                throw new Exception("Forbidden value on elementState = " + elementState + ", it doesn't respect the following condition : elementState < 0");
            onCurrentMap = reader.ReadBoolean();
        }
        
        
    }
    
}