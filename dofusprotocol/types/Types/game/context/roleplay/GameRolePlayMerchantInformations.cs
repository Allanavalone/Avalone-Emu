

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
    {
        public const short Id = 129;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public sbyte sellType;
        public IEnumerable<HumanOption> options;
        
        public GameRolePlayMerchantInformations()
        {
        }
        
        public GameRolePlayMerchantInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, string name, sbyte sellType, IEnumerable<HumanOption> options)
         : base(contextualId, look, disposition, name)
        {
            this.sellType = sellType;
            this.options = options;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(sellType);
            var options_before = writer.Position;
            var options_count = 0;
            writer.WriteShort(0);
            foreach (var entry in options)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 options_count++;
            }
            var options_after = writer.Position;
            writer.Seek((int)options_before);
            writer.WriteShort((short)options_count);
            writer.Seek((int)options_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            sellType = reader.ReadSByte();
            if (sellType < 0)
                throw new Exception("Forbidden value on sellType = " + sellType + ", it doesn't respect the following condition : sellType < 0");
            var limit = reader.ReadShort();
            var options_ = new HumanOption[limit];
            for (int i = 0; i < limit; i++)
            {
                 options_[i] = Types.ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
                 options_[i].Deserialize(reader);
            }
            options = options_;
        }
        
        
    }
    
}