

// Generated on 02/17/2017 01:52:54
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
    {
        public const short Id = 148;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public TaxCollectorStaticInformations identification;
        public sbyte guildLevel;
        public int taxCollectorAttack;
        
        public GameRolePlayTaxCollectorInformations()
        {
        }
        
        public GameRolePlayTaxCollectorInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, TaxCollectorStaticInformations identification, sbyte guildLevel, int taxCollectorAttack)
         : base(contextualId, look, disposition)
        {
            this.identification = identification;
            this.guildLevel = guildLevel;
            this.taxCollectorAttack = taxCollectorAttack;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(identification.TypeId);
            identification.Serialize(writer);
            writer.WriteSByte(guildLevel);
            writer.WriteInt(taxCollectorAttack);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            identification = Types.ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>(reader.ReadShort());
            identification.Deserialize(reader);
            guildLevel = reader.ReadSByte();
            if (guildLevel < 0 || guildLevel > 255)
                throw new Exception("Forbidden value on guildLevel = " + guildLevel + ", it doesn't respect the following condition : guildLevel < 0 || guildLevel > 255");
            taxCollectorAttack = reader.ReadInt();
        }
        
        
    }
    
}