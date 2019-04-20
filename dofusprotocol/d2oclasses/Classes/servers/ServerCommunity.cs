using System;
using System.Collections.Generic;
using Stump.DofusProtocol.D2oClasses;
using Stump.DofusProtocol.D2oClasses.Tools.D2o;

namespace Stump.DofusProtocol.D2oClasses
{
    [D2OClass("ServerCommunity", "com.ankamagames.dofus.datacenter.servers")]
    [Serializable]
    public class ServerCommunity : IDataObject, IIndexedData
    {
        public const String MODULE = "ServerCommunities";
        public int id;
        [I18NField]
        public uint nameId;
        public String shortId;
        public List<String> defaultCountries;
        public List<int> supportedLangIds;
        public int namingRulePlayerNameId;
        public int namingRuleGuildNameId;
        public int namingRuleAllianceNameId;
        public int namingRuleAllianceTagId;
        public int namingRulePartyNameId;
        public int namingRuleMountNameId;
        public int namingRuleNameGeneratorId;
        public int namingRuleAdminId;
        public int namingRuleModoId;
        int IIndexedData.Id
        {
            get { return (int)id; }
        }
        [D2OIgnore]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        [D2OIgnore]
        public uint NameId
        {
            get { return this.nameId; }
            set { this.nameId = value; }
        }
        [D2OIgnore]
        public String ShortId
        {
            get { return this.shortId; }
            set { this.shortId = value; }
        }
        [D2OIgnore]
        public List<String> DefaultCountries
        {
            get { return this.defaultCountries; }
            set { this.defaultCountries = value; }
        }
        [D2OIgnore]
        public List<int> SupportedLangIds
        {
            get { return this.supportedLangIds; }
            set { this.supportedLangIds = value; }
        }
        [D2OIgnore]
        public int NamingRulePlayerNameId
        {
            get { return this.namingRulePlayerNameId; }
            set { this.namingRulePlayerNameId = value; }
        }
        [D2OIgnore]
        public int NamingRuleGuildNameId
        {
            get { return this.namingRuleGuildNameId; }
            set { this.namingRuleGuildNameId = value; }
        }
        [D2OIgnore]
        public int NamingRuleAllianceNameId
        {
            get { return this.namingRuleAllianceNameId; }
            set { this.namingRuleAllianceNameId = value; }
        }
        [D2OIgnore]
        public int NamingRuleAllianceTagId
        {
            get { return this.namingRuleAllianceTagId; }
            set { this.namingRuleAllianceTagId = value; }
        }
        [D2OIgnore]
        public int NamingRulePartyNameId
        {
            get { return this.namingRulePartyNameId; }
            set { this.namingRulePartyNameId = value; }
        }
        [D2OIgnore]
        public int NamingRuleMountNameId
        {
            get { return this.namingRuleMountNameId; }
            set { this.namingRuleMountNameId = value; }
        }
        [D2OIgnore]
        public int NamingRuleNameGeneratorId
        {
            get { return this.namingRuleNameGeneratorId; }
            set { this.namingRuleNameGeneratorId = value; }
        }
        [D2OIgnore]
        public int NamingRuleAdminId
        {
            get { return this.namingRuleAdminId; }
            set { this.namingRuleAdminId = value; }
        }
        [D2OIgnore]
        public int NamingRuleModoId
        {
            get { return this.namingRuleModoId; }
            set { this.namingRuleModoId = value; }
        }
    }
}