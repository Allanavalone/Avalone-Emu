

// Generated on 02/17/2017 01:53:00
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stump.Core.IO;

namespace Stump.DofusProtocol.Types
{
    public class ObjectItemToSellInBid : ObjectItemToSell
    {
        public const short Id = 164;
        public override short TypeId
        {
            get { return Id; }
        }
        
        public int unsoldDelay;
        
        public ObjectItemToSellInBid()
        {
        }
        
        public ObjectItemToSellInBid(short objectGID, IEnumerable<ObjectEffect> effects, int objectUID, int quantity, long objectPrice, int unsoldDelay)
         : base(objectGID, effects, objectUID, quantity, objectPrice)
        {
            this.unsoldDelay = unsoldDelay;
        }
        
        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(unsoldDelay);
        }
        
        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            unsoldDelay = reader.ReadInt();
            if (unsoldDelay < 0)
                throw new Exception("Forbidden value on unsoldDelay = " + unsoldDelay + ", it doesn't respect the following condition : unsoldDelay < 0");
        }
        
        
    }
    
}