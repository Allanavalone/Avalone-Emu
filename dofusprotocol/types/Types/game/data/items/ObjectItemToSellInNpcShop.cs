

// Generated on 02/17/2017 01:53:01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
    {
        public const short Id = 352;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public long objectPrice;
        public string buyCriterion;
        
        public ObjectItemToSellInNpcShop()
        {
        }
        
        public ObjectItemToSellInNpcShop(short objectGID, IEnumerable<ObjectEffect> effects, long objectPrice, string buyCriterion)
         : base(objectGID, effects)
        {
            this.objectPrice = objectPrice;
            this.buyCriterion = buyCriterion;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(objectPrice);
            writer.WriteUTF(buyCriterion);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            objectPrice = reader.ReadVarLong();
            if (objectPrice < 0 || objectPrice > 9007199254740990)
                throw new Exception("Forbidden value on objectPrice = " + objectPrice + ", it doesn't respect the following condition : objectPrice < 0 || objectPrice > 9007199254740990");
            buyCriterion = reader.ReadUTF();
        }
        
        
    }
    
}