﻿using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Remotion.Linq.Parsing.Structure;
using System.Reflection;

namespace Greenovative.Accounting.Framework.Extensions;

public static class IQueryableExtensions
{
    private static readonly TypeInfo QueryCompilerTypeInfo = typeof(QueryCompiler).GetTypeInfo();

    private static readonly FieldInfo QueryCompilerField = typeof(EntityQueryProvider).GetTypeInfo().DeclaredFields.First(x => x.Name == "_queryCompiler");

    private static readonly PropertyInfo NodeTypeProviderField = QueryCompilerTypeInfo.DeclaredProperties.Single(x => x.Name == "NodeTypeProvider");

    private static readonly MethodInfo CreateQueryParserMethod = QueryCompilerTypeInfo.DeclaredMethods.First(x => x.Name == "CreateQueryParser");

    private static readonly FieldInfo DataBaseField = QueryCompilerTypeInfo.DeclaredFields.Single(x => x.Name == "_database");

    private static readonly PropertyInfo DatabaseDependenciesField
        = typeof(Database).GetTypeInfo().DeclaredProperties.Single(x => x.Name == "Dependencies");

    public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
    {
        if (!(query is EntityQueryable<TEntity>) && !(query is InternalDbSet<TEntity>))
        {
            throw new ArgumentException("Invalid query");
        }

        var queryCompiler = (IQueryCompiler)QueryCompilerField.GetValue(query.Provider);
        var nodeTypeProvider = (INodeTypeProvider)NodeTypeProviderField.GetValue(queryCompiler);
        var parser = (IQueryParser)CreateQueryParserMethod.Invoke(queryCompiler, new object[] { nodeTypeProvider });
        var queryModel = parser.GetParsedQuery(query.Expression);
        var database = DataBaseField.GetValue(queryCompiler);
        var queryCompilationContextFactory = ((DatabaseDependencies)DatabaseDependenciesField.GetValue(database)).QueryCompilationContextFactory;
        var queryCompilationContext = queryCompilationContextFactory.Create(false);
        var queryExecutor = queryCompilationContext.CreateQueryExecutor<TEntity>(query.Expression);

        var sql = queryExecutor.ToString();
        return sql;
    }
}
