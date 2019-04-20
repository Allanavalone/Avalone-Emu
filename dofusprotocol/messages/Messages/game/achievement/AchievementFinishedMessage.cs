

// Generated on 02/17/2017 01:57:33
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AchievementFinishedMessage : Message
    {
        public const uint Id = 6208;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short id;
        public sbyte finishedlevel;
        
        public AchievementFinishedMessage()
        {
        }
        
        public AchievementFinishedMessage(short id, sbyte finishedlevel)
        {
            this.id = id;
            this.finishedlevel = finishedlevel;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(id);
            writer.WriteSByte(finishedlevel);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarShort();
            if (id < 0)
                throw new Exception("Forbidden value on id = " + id + ", it doesn't respect the following condition : id < 0");
            finishedlevel = reader.ReadSByte();
            if (finishedlevel < 0 || finishedlevel > 206)
                throw new Exception("Forbidden value on finishedlevel = " + finishedlevel + ", it doesn't respect the following condition : finishedlevel < 0 || finishedlevel > 206");
        }
        
    }
    
}