

// Generated on 02/17/2017 01:53:04
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class PrismFightersInformation
    {
        public const short Id = 443;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public short subAreaId;
        public Types.ProtectedEntityWaitingForHelpInfo waitingForHelpInfo;
        public IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations;
        public IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations;
        
        public PrismFightersInformation()
        {
        }
        
        public PrismFightersInformation(short subAreaId, Types.ProtectedEntityWaitingForHelpInfo waitingForHelpInfo, IEnumerable<CharacterMinimalPlusLookInformations> allyCharactersInformations, IEnumerable<CharacterMinimalPlusLookInformations> enemyCharactersInformations)
        {
            this.subAreaId = subAreaId;
            this.waitingForHelpInfo = waitingForHelpInfo;
            this.allyCharactersInformations = allyCharactersInformations;
            this.enemyCharactersInformations = enemyCharactersInformations;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(subAreaId);
            waitingForHelpInfo.Serialize(writer);
            var allyCharactersInformations_before = writer.Position;
            var allyCharactersInformations_count = 0;
            writer.WriteShort(0);
            foreach (var entry in allyCharactersInformations)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 allyCharactersInformations_count++;
            }
            var allyCharactersInformations_after = writer.Position;
            writer.Seek((int)allyCharactersInformations_before);
            writer.WriteShort((short)allyCharactersInformations_count);
            writer.Seek((int)allyCharactersInformations_after);

            var enemyCharactersInformations_before = writer.Position;
            var enemyCharactersInformations_count = 0;
            writer.WriteShort(0);
            foreach (var entry in enemyCharactersInformations)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 enemyCharactersInformations_count++;
            }
            var enemyCharactersInformations_after = writer.Position;
            writer.Seek((int)enemyCharactersInformations_before);
            writer.WriteShort((short)enemyCharactersInformations_count);
            writer.Seek((int)enemyCharactersInformations_after);

        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            subAreaId = reader.ReadVarShort();
            if (subAreaId < 0)
                throw new Exception("Forbidden value on subAreaId = " + subAreaId + ", it doesn't respect the following condition : subAreaId < 0");
            waitingForHelpInfo = new Types.ProtectedEntityWaitingForHelpInfo();
            waitingForHelpInfo.Deserialize(reader);
            var limit = reader.ReadShort();
            var allyCharactersInformations_ = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 allyCharactersInformations_[i] = Types.ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
                 allyCharactersInformations_[i].Deserialize(reader);
            }
            allyCharactersInformations = allyCharactersInformations_;
            limit = reader.ReadShort();
            var enemyCharactersInformations_ = new CharacterMinimalPlusLookInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 enemyCharactersInformations_[i] = Types.ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadShort());
                 enemyCharactersInformations_[i].Deserialize(reader);
            }
            enemyCharactersInformations = enemyCharactersInformations_;
        }
        
        
    }
    
}