

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ObjectItemMinimalInformation : Item
    {
        public const short Id = 124;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public short objectGID;
        public IEnumerable<ObjectEffect> effects;
        
        public ObjectItemMinimalInformation()
        {
        }
        
        public ObjectItemMinimalInformation(short objectGID, IEnumerable<ObjectEffect> effects)
        {
            this.objectGID = objectGID;
            this.effects = effects;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(objectGID);
            var effects_before = writer.Position;
            var effects_count = 0;
            writer.WriteShort(0);
            foreach (var entry in effects)
            {
                 writer.WriteShort(entry.TypeId);
                 entry.Serialize(writer);
                 effects_count++;
            }
            var effects_after = writer.Position;
            writer.Seek((int)effects_before);
            writer.WriteShort((short)effects_count);
            writer.Seek((int)effects_after);

        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectGID = reader.ReadVarShort();
            if (objectGID < 0)
                throw new Exception("Forbidden value on objectGID = " + objectGID + ", it doesn't respect the following condition : objectGID < 0");
            var limit = reader.ReadShort();
            var effects_ = new ObjectEffect[limit];
            for (int i = 0; i < limit; i++)
            {
                 effects_[i] = Types.ProtocolTypeManager.GetInstance<ObjectEffect>(reader.ReadShort());
                 effects_[i].Deserialize(reader);
            }
            effects = effects_;
        }
        
        
    }
    
}