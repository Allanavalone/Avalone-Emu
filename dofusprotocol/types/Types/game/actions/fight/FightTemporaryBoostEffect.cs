

// Generated on 02/17/2017 01:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
    {
        public const short Id = 209;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short delta;
        
        public FightTemporaryBoostEffect()
        {
        }
        
        public FightTemporaryBoostEffect(int uid, double targetId, short turnDuration, sbyte dispelable, short spellId, int effectId, int parentBoostUid, short delta)
         : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid)
        {
            this.delta = delta;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(delta);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            delta = reader.ReadShort();
        }
        
        
    }
    
}