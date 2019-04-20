

// Generated on 02/17/2017 01:57:56
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class AccountHouseMessage : Message
    {
        public const uint Id = 6315;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<Types.AccountHouseInformations> houses;
        
        public AccountHouseMessage()
        {
        }
        
        public AccountHouseMessage(IEnumerable<Types.AccountHouseInformations> houses)
        {
            this.houses = houses;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var houses_before = writer.Position;
            var houses_count = 0;
            writer.WriteShort(0);
            foreach (var entry in houses)
            {
                 entry.Serialize(writer);
                 houses_count++;
            }
            var houses_after = writer.Position;
            writer.Seek((int)houses_before);
            writer.WriteShort((short)houses_count);
            writer.Seek((int)houses_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var houses_ = new Types.AccountHouseInformations[limit];
            for (int i = 0; i < limit; i++)
            {
                 houses_[i] = new Types.AccountHouseInformations();
                 houses_[i].Deserialize(reader);
            }
            houses = houses_;
        }
        
    }
    
}