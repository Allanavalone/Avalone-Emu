

// Generated on 02/17/2017 01:52:57
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
    {
        public const short Id = 159;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public HumanInformations humanoidInfo;
        public int accountId;
        
        public GameRolePlayHumanoidInformations()
        {
        }
        
        public GameRolePlayHumanoidInformations(double contextualId, Types.EntityLook look, EntityDispositionInformations disposition, string name, HumanInformations humanoidInfo, int accountId)
         : base(contextualId, look, disposition, name)
        {
            this.humanoidInfo = humanoidInfo;
            this.accountId = accountId;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(humanoidInfo.TypeId);
            humanoidInfo.Serialize(writer);
            writer.WriteInt(accountId);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            humanoidInfo = Types.ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadShort());
            humanoidInfo.Deserialize(reader);
            accountId = reader.ReadInt();
            if (accountId < 0)
                throw new Exception("Forbidden value on accountId = " + accountId + ", it doesn't respect the following condition : accountId < 0");
        }
        
        
    }
    
}