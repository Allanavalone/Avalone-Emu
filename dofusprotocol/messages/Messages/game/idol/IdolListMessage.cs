

// Generated on 02/17/2017 01:58:12
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class IdolListMessage : Message
    {
        public const uint Id = 6585;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public IEnumerable<short> chosenIdols;
        public IEnumerable<short> partyChosenIdols;
        public IEnumerable<PartyIdol> partyIdols;
        
        public IdolListMessage()
        {
        }
        
        public IdolListMessage(IEnumerable<short> chosenIdols, IEnumerable<short> partyChosenIdols, IEnumerable<PartyIdol> partyIdols)
        {
            this.chosenIdols = chosenIdols;
            this.partyChosenIdols = partyChosenIdols;
            this.partyIdols = partyIdols;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            var chosenIdols_before = writer.Position;
            var chosenIdols_count = 0;
            writer.WriteShort(0);
            foreach (var entry in chosenIdols)
            {
                 writer.WriteVarShort(entry);
                 chosenIdols_count++;
            }
            var chosenIdols_after = writer.Position;
            writer.Seek((int)chosenIdols_before);
            writer.WriteShort((short)chosenIdols_count);
            writer.Seek((int)chosenIdols_after);

            var partyChosenIdols_before = writer.Position;
            var partyChosenIdols_count = 0;
            writer.WriteShort(0);
            foreach (var entry in partyChosenIdols)
            {
                 writer.WriteVarShort(entry);
                 partyChosenIdols_count++;
            }
            var partyChosenIdols_after = writer.Position;
            writer.Seek((int)partyChosenIdols_before);
            writer.WriteShort((short)partyChosenIdols_count);
            writer.Seek((int)partyChosenIdols_after);

            var partyIdols_before = writer.Position;
            var partyIdols_count = 0;
            writer.WriteShort(0);
            foreach (var entry in partyIdols)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 partyIdols_count++;
            }
            var partyIdols_after = writer.Position;
            writer.Seek((int)partyIdols_before);
            writer.WriteShort((short)partyIdols_count);
            writer.Seek((int)partyIdols_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            var limit = reader.ReadShort();
            var chosenIdols_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 chosenIdols_[i] = reader.ReadVarShort();
                 if (chosenIdols_[i] < 0)
                     throw new Exception("Forbidden value on chosenIdols_[i] = " + chosenIdols_[i] + ", it doesn't respect the following condition : chosenIdols_[i] < 0");
            }
            chosenIdols = chosenIdols_;
            limit = reader.ReadShort();
            var partyChosenIdols_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 partyChosenIdols_[i] = reader.ReadVarShort();
                 if (partyChosenIdols_[i] < 0)
                     throw new Exception("Forbidden value on partyChosenIdols_[i] = " + partyChosenIdols_[i] + ", it doesn't respect the following condition : partyChosenIdols_[i] < 0");
            }
            partyChosenIdols = partyChosenIdols_;
            limit = reader.ReadShort();
            var partyIdols_ = new PartyIdol[limit];
            for (int i = 0; i < limit; i++)
            {
                 partyIdols_[i] = Types.ProtocolTypeManager.GetInstance<PartyIdol>(reader.ReadShort());
                 partyIdols_[i].Deserialize(reader);
            }
            partyIdols = partyIdols_;
        }
        
    }
    
}