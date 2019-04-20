

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightStartingPositions
    {
        public const short Id = 513;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> positionsForChallengers;
        public IEnumerable<short> positionsForDefenders;
        
        public FightStartingPositions()
        {
        }
        
        public FightStartingPositions(IEnumerable<short> positionsForChallengers, IEnumerable<short> positionsForDefenders)
        {
            this.positionsForChallengers = positionsForChallengers;
            this.positionsForDefenders = positionsForDefenders;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            var positionsForChallengers_before = writer.Position;
            var positionsForChallengers_count = 0;
            writer.WriteShort(0);
            foreach (var entry in positionsForChallengers)
            {
                 writer.WriteVarShort(entry);
                 positionsForChallengers_count++;
            }
            var positionsForChallengers_after = writer.Position;
            writer.Seek((int)positionsForChallengers_before);
            writer.WriteShort((short)positionsForChallengers_count);
            writer.Seek((int)positionsForChallengers_after);

            var positionsForDefenders_before = writer.Position;
            var positionsForDefenders_count = 0;
            writer.WriteShort(0);
            foreach (var entry in positionsForDefenders)
            {
                 writer.WriteVarShort(entry);
                 positionsForDefenders_count++;
            }
            var positionsForDefenders_after = writer.Position;
            writer.Seek((int)positionsForDefenders_before);
            writer.WriteShort((short)positionsForDefenders_count);
            writer.Seek((int)positionsForDefenders_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var positionsForChallengers_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 positionsForChallengers_[i] = reader.ReadVarShort();
                 if (positionsForChallengers_[i] > 559)
                     throw new Exception("Forbidden value on positionsForChallengers_[i] = " + positionsForChallengers_[i] + ", it doesn't respect the following condition : positionsForChallengers_[i] > 559");
            }
            positionsForChallengers = positionsForChallengers_;
            limit = reader.ReadShort();
            var positionsForDefenders_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 positionsForDefenders_[i] = reader.ReadVarShort();
                 if (positionsForDefenders_[i] > 559)
                     throw new Exception("Forbidden value on positionsForDefenders_[i] = " + positionsForDefenders_[i] + ", it doesn't respect the following condition : positionsForDefenders_[i] > 559");
            }
            positionsForDefenders = positionsForDefenders_;
        }
        
        
    }
    
}