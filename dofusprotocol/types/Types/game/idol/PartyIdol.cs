

// Generated on 02/17/2017 01:53:02
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PartyIdol : Idol
    {
        public const short Id = 490;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public IEnumerable<long> ownersIds;
        
        public PartyIdol()
        {
        }
        
        public PartyIdol(short id, short xpBonusPercent, short dropBonusPercent, IEnumerable<long> ownersIds)
         : base(id, xpBonusPercent, dropBonusPercent)
        {
            this.ownersIds = ownersIds;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var ownersIds_before = writer.Position;
            var ownersIds_count = 0;
            writer.WriteShort(0);
            foreach (var entry in ownersIds)
            {
                 writer.WriteVarLong(entry);
                 ownersIds_count++;
            }
            var ownersIds_after = writer.Position;
            writer.Seek((int)ownersIds_before);
            writer.WriteShort((short)ownersIds_count);
            writer.Seek((int)ownersIds_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var ownersIds_ = new long[limit];
            for (int i = 0; i < limit; i++)
            {
                 ownersIds_[i] = reader.ReadVarLong();
                 if (ownersIds_[i] > 9007199254740990)
                     throw new Exception("Forbidden value on ownersIds_[i] = " + ownersIds_[i] + ", it doesn't respect the following condition : ownersIds_[i] > 9007199254740990");
            }
            ownersIds = ownersIds_;
        }
        
        
    }
    
}