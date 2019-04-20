

// Generated on 02/17/2017 01:58:05
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class StatsUpgradeRequestMessage : Message
    {
        public const uint Id = 5610;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public bool useAdditionnal;
        public sbyte statId;
        public short boostPoint;
        
        public StatsUpgradeRequestMessage()
        {
        }
        
        public StatsUpgradeRequestMessage(bool useAdditionnal, sbyte statId, short boostPoint)
        {
            this.useAdditionnal = useAdditionnal;
            this.statId = statId;
            this.boostPoint = boostPoint;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(useAdditionnal);
            writer.WriteSByte(statId);
            writer.WriteVarShort(boostPoint);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            useAdditionnal = reader.ReadBoolean();
            statId = reader.ReadSByte();
            boostPoint = reader.ReadVarShort();
            if (boostPoint < 0)
                throw new Exception("Forbidden value on boostPoint = " + boostPoint + ", it doesn't respect the following condition : boostPoint < 0");
        }
        
    }
    
}