

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FinishMoveInformations
    {
        public const short Id = 506;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int finishMoveId;
        public bool finishMoveState;
        
        public FinishMoveInformations()
        {
        }
        
        public FinishMoveInformations(int finishMoveId, bool finishMoveState)
        {
            this.finishMoveId = finishMoveId;
            this.finishMoveState = finishMoveState;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(finishMoveId);
            writer.WriteBoolean(finishMoveState);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            finishMoveId = reader.ReadInt();
            if (finishMoveId < 0)
                throw new Exception("Forbidden value on finishMoveId = " + finishMoveId + ", it doesn't respect the following condition : finishMoveId < 0");
            finishMoveState = reader.ReadBoolean();
        }
        
        
    }
    
}