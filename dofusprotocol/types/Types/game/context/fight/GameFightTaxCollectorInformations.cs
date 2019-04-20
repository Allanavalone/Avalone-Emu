

// Generated on 02/17/2017 01:52:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public const short Id = 48;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short firstNameId;
        public short lastNameId;
        public sbyte level;
        
        public GameFightTaxCollectorInformations()
        {
        }
        
        public GameFightTaxCollectorInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, sbyte teamId, sbyte wave, bool alive, GameFightMinimalStats stats, IEnumerable<short> previousPositions, short firstNameId, short lastNameId, sbyte level)
         : base(contextualId, look, disposition, teamId, wave, alive, stats, previousPositions)
        {
            this.firstNameId = firstNameId;
            this.lastNameId = lastNameId;
            this.level = level;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(firstNameId);
            writer.WriteVarShort(lastNameId);
            writer.WriteSByte(level);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            firstNameId = reader.ReadVarShort();
            if (firstNameId < 0)
                throw new Exception("Forbidden value on firstNameId = " + firstNameId + ", it doesn't respect the following condition : firstNameId < 0");
            lastNameId = reader.ReadVarShort();
            if (lastNameId < 0)
                throw new Exception("Forbidden value on lastNameId = " + lastNameId + ", it doesn't respect the following condition : lastNameId < 0");
            level = reader.ReadSByte();
            if (level < 0 || level > 255)
                throw new Exception("Forbidden value on level = " + level + ", it doesn't respect the following condition : level < 0 || level > 255");
        }
        
        
    }
    
}