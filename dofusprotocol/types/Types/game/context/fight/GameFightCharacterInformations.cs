

// Generated on 02/17/2017 01:52:55
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightCharacterInformations : GameFightFighterNamedInformations
    {
        public const short Id = 46;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte level;
        public Types.ActorAlignmentInformations alignmentInfos;
        public sbyte breed;
        public bool sex;
        
        public GameFightCharacterInformations()
        {
        }
        
        public GameFightCharacterInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, IEnumerable<short> previousPositions, string name, Types.PlayerStatus status, sbyte level, Types.ActorAlignmentInformations alignmentInfos, sbyte breed, bool sex)
         : base(contextualId, look, disposition, teamId, wave, alive, stats, previousPositions, name, status)
        {
            this.level = level;
            this.alignmentInfos = alignmentInfos;
            this.breed = breed;
            this.sex = sex;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(level);
            alignmentInfos.Serialize(writer);
            writer.WriteSByte(breed);
            writer.WriteBoolean(sex);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
            alignmentInfos = new Types.ActorAlignmentInformations();
            alignmentInfos.Deserialize(reader);
            breed = reader.ReadSByte();
            sex = reader.ReadBoolean();
        }
        
        
    }
    
}