

// Generated on 02/17/2017 01:58:23
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;
using Stump.DofusProtocol.Types;

namespace Stump.DofusProtocol.Messages
{
    public class SetUpdateMessage : Message
    {
        public const uint Id = 5503;
        public override uint MessageId
        {
            get { return Id; }
        }
        
        public short setId;
        public IEnumerable<short> setObjects;
        public IEnumerable<ObjectEffect> setEffects;
        
        public SetUpdateMessage()
        {
        }
        
        public SetUpdateMessage(short setId, IEnumerable<short> setObjects, IEnumerable<ObjectEffect> setEffects)
        {
            this.setId = setId;
            this.setObjects = setObjects;
            this.setEffects = setEffects;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(setId);
            var setObjects_before = writer.Position;
            var setObjects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in setObjects)
            {
                 writer.WriteVarShort(entry);
                 setObjects_count++;
            }
            var setObjects_after = writer.Position;
            writer.Seek((int)setObjects_before);
            writer.WriteShort((short)setObjects_count);
            writer.Seek((int)setObjects_after);

            var setEffects_before = writer.Position;
            var setEffects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in setEffects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 setEffects_count++;
            }
            var setEffects_after = writer.Position;
            writer.Seek((int)setEffects_before);
            writer.WriteShort((short)setEffects_count);
            writer.Seek((int)setEffects_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            setId = reader.ReadVarShort();
            if (setId < 0)
                throw new Exception("Forbidden value on setId = " + setId + ", it doesn't respect the following condition : setId < 0");
            var limit = reader.ReadShort();
            var setObjects_ = new short[limit];
            for (int i = 0; i < limit; i++)
            {
                 setObjects_[i] = reader.ReadVarShort();
                 if (setObjects_[i] < 0)
                     throw new Exception("Forbidden value on setObjects_[i] = " + setObjects_[i] + ", it doesn't respect the following condition : setObjects_[i] < 0");
            }
            setObjects = setObjects_;
            limit = reader.ReadShort();
            var setEffects_ = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 setEffects_[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                 setEffects_[i].Deserialize(reader);
            }
            setEffects = setEffects_;
        }
        
    }
    
}