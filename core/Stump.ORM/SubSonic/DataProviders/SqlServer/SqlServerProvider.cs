﻿using System;
using Stump.ORM.SubSonic.Linq.Structure;
using Stump.ORM.SubSonic.Query;
using Stump.ORM.SubSonic.Schema;

namespace Stump.ORM.SubSonic.DataProviders.SqlServer
{
    public class SqlServerProvider : DbDataProvider, IDataProvider
    {
        private string _insertionIdentityFetchString = "; SELECT SCOPE_IDENTITY() as new_id";
        public override string InsertionIdentityFetchString { get { return _insertionIdentityFetchString; } }

        public SqlServerProvider(string connectionString, string providerName) : base(connectionString, providerName)
        {}

        public override string QualifyTableName(ITable table)
        {
            string qualifiedTable;


            string qualifiedFormat = String.IsNullOrEmpty(table.SchemaName) ? "[{1}]" : "[{0}].[{1}]";
            qualifiedTable = String.Format(qualifiedFormat, table.SchemaName, table.Name);


            return qualifiedTable;
        }

        public override string QualifyColumnName(IColumn column)
        {
            string qualifiedFormat;
            qualifiedFormat = String.IsNullOrEmpty(column.SchemaName) ? "[{1}].[{2}]" : "[{0}].[{1}].[{2}]";
            return String.Format(qualifiedFormat, column.Table.SchemaName, column.Table.Name, column.Name);
        }

        public override ISchemaGenerator SchemaGenerator
        {
            get { return new Sql2005Schema(); }
        }

        public override ISqlGenerator GetSqlGenerator(SqlQuery query)
        {
            return new Sql2005Generator(query);
        }

        public override IQueryLanguage QueryLanguage { get { return new TSqlLanguage(this); } }
    }
}
