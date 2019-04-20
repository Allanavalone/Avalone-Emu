

// Generated on 02/17/2017 01:52:52
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class FightTriggeredEffect : AbstractFightDispellableEffect
    {
        public const short Id = 210;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int arg1;
        public int arg2;
        public int arg3;
        public short delay;
        
        public FightTriggeredEffect()
        {
        }
        
        public FightTriggeredEffect(int uid, double targetId, short turnDuration, sbyte dispelable, short spellId, int effectId, int parentBoostUid, int arg1, int arg2, int arg3, short delay)
         : base(uid, targetId, turnDuration, dispelable, spellId, effectId, parentBoostUid)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
            this.delay = delay;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(arg1);
            writer.WriteInt(arg2);
            writer.WriteInt(arg3);
            writer.WriteShort(delay);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            arg1 = reader.ReadInt();
            arg2 = reader.ReadInt();
            arg3 = reader.ReadInt();
            delay = reader.ReadShort();
        }
        
        
    }
    
}