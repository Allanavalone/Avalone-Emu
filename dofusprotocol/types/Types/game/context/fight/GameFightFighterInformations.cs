

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightFighterInformations : GameContextActorInformations
    {
        public const short Id = 143;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte teamId;
        public sbyte wave;
        public bool alive;
        public GameFightMinimalStats stats;
        public IEnumerable<short> previousPositions;
        
        public GameFightFighterInformations()
        {
        }
        
        public GameFightFighterInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, IEnumerable<short> previousPositions)
         : base(contextualId, look, disposition)
        {
            this.teamId = teamId;
            this.wave = wave;
            this.alive = alive;
            this.stats = stats;
            this.previousPositions = previousPositions;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(teamId);
            writer.WriteSByte(wave);
            writer.WriteBoolean(alive);
            writer.WriteShort(stats.TypeId);
            stats.Serialize(writer);
            var previousPositions_before = writer.Position;
            var previousPositions_count = 0;
            writer.WriteShort(0);
            foreach (var entry in previousPositions)
            {
                 writer.WriteVarShort(entry);
                 previousPositions_count++;
            }
            var previousPositions_after = writer.Position;
            writer.Seek((int)previousPositions_before);
            writer.WriteShort((short)previousPositions_count);
            writer.Seek((int)previousPositions_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            teamId = reader.ReadSByte();
            wave = reader.ReadSByte();
            if (wave < 0)
                throw new Exception("Forbidden value on wave = " + wave + ", it doesn't respect the following condition : wave < 0");
            alive = reader.ReadBoolean();
            stats = Types.ProtocolTypeManager.GetInstance<GameFightMinimalStats>(reader.ReadShort());
            stats.Deserialize(reader);
            var limit = reader.ReadShort();
            var previousPositions_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 previousPositions_[i] = reader.ReadVarShort();
                 if (previousPositions_[i] > 559)
                     throw new Exception("Forbidden value on previousPositions_[i] = " + previousPositions_[i] + ", it doesn't respect the following condition : previousPositions_[i] > 559");
            }
            previousPositions = previousPositions_;
        }
        
        
    }
    
}