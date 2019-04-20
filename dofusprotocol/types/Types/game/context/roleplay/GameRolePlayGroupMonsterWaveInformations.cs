

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
    {
        public const short Id = 464;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte nbWaves;
        public IEnumerable<GroupMonsterStaticInformations> alternatives;
        
        public GameRolePlayGroupMonsterWaveInformations()
        {
        }
        
        public GameRolePlayGroupMonsterWaveInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, bool keyRingBonus, bool hasHardcoreDrop, bool hasAVARewardToken, GroupMonsterStaticInformations staticInfos, double creationTime, int ageBonusRate, sbyte lootShare, sbyte alignmentSide, sbyte nbWaves, IEnumerable<GroupMonsterStaticInformations> alternatives)
         : base(contextualId, look, disposition, keyRingBonus, hasHardcoreDrop, hasAVARewardToken, staticInfos, creationTime, ageBonusRate, lootShare, alignmentSide)
        {
            this.nbWaves = nbWaves;
            this.alternatives = alternatives;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(nbWaves);
            var alternatives_before = writer.Position;
            var alternatives_count = 0;
            writer.WriteShort(0);
            foreach (var entry in alternatives)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 alternatives_count++;
            }
            var alternatives_after = writer.Position;
            writer.Seek((int)alternatives_before);
            writer.WriteShort((short)alternatives_count);
            writer.Seek((int)alternatives_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            nbWaves = reader.ReadSByte();
            if (nbWaves < 0)
                throw new Exception("Forbidden value on nbWaves = " + nbWaves + ", it doesn't respect the following condition : nbWaves < 0");
            var limit = reader.ReadShort();
            var alternatives_ = new GroupMonsterStaticInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 alternatives_[i] = Types.ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
                 alternatives_[i].Deserialize(reader);
            }
            alternatives = alternatives_;
        }
        
        
    }
    
}