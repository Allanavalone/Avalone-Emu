

// Generated on 02/17/2017 01:57:48
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class GameFightResumeMessage : GameFightSpectateMessage
    {
        public const uint Id = 6067;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.GameFightSpellCooldown> spellCooldowns;
        public sbyte summonCount;
        public sbyte bombCount;
        
        public GameFightResumeMessage()
        {
        }
        
        public GameFightResumeMessage(IEnumerable<Types.FightDispellableEffectExtendedInformations> effects, IEnumerable<Types.GameActionMark> marks, short gameTurn, int fightStart, IEnumerable<Types.Idol> idols, IEnumerable<Types.GameFightSpellCooldown> spellCooldowns, sbyte summonCount, sbyte bombCount)
         : base(effects, marks, gameTurn, fightStart, idols)
        {
            this.spellCooldowns = spellCooldowns;
            this.summonCount = summonCount;
            this.bombCount = bombCount;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var spellCooldowns_before = writer.Position;
            var spellCooldowns_count = 0;
            writer.WriteShort(0);
            foreach (var entry in spellCooldowns)
            {
                 entry.Serialize(writer);
                 spellCooldowns_count++;
            }
            var spellCooldowns_after = writer.Position;
            writer.Seek((int)spellCooldowns_before);
            writer.WriteShort((short)spellCooldowns_count);
            writer.Seek((int)spellCooldowns_after);

            writer.WriteSByte(summonCount);
            writer.WriteSByte(bombCount);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var limit = reader.ReadShort();
            var spellCooldowns_ = new Types.GameFightSpellCooldown[limit];
            for (int i = 0; i < limit; i++)
            {
                 spellCooldowns_[i] = new Types.GameFightSpellCooldown();
                 spellCooldowns_[i].Deserialize(reader);
            }
            spellCooldowns = spellCooldowns_;
            summonCount = reader.ReadSByte();
            if (summonCount < 0)
                throw new Exception("Forbidden value on summonCount = " + summonCount + ", it doesn't respect the following condition : summonCount < 0");
            bombCount = reader.ReadSByte();
            if (bombCount < 0)
                throw new Exception("Forbidden value on bombCount = " + bombCount + ", it doesn't respect the following condition : bombCount < 0");
        }
        
    }
    
}