

// Generated on 02/19/2017 13:42:14
using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ItemCriterionOperator", "com.ankamagames.dofus.datacenter.items.criterion")]
    [Serializable]
    public class ItemCriterionOperator : IDataObject
    {
        public const String SUPERIOR = ">";
        public const String INFERIOR = "<";
        public const String EQUAL = "";
        public const String DIFFERENT = "!";
    }
}