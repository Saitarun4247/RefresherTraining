using System;
using System.Collections.Generic;

class QueryBuilder
{
    private List<string> conditions = new List<string>();

    public void AddWhereClause(string clause)
    {
        conditions.Add(clause);
    }

    public void AddWhereClause(params Action<QueryBuilder>[] nestedConditions)
    {
        QueryBuilder nestedBuilder = new QueryBuilder();

        foreach (Action<QueryBuilder> condition in nestedConditions)
        {
            condition(nestedBuilder);
        }

        int indentation = 1;
        string nestedSql = ProcessNested(nestedBuilder, ref indentation);

        conditions.Add("(\n" + nestedSql + "\n)");

        string ProcessNested(QueryBuilder builder, ref int indent)
        {
            List<string> formattedConditions = new List<string>();

            foreach (string condition in builder.conditions)
            {
                string spaces = new string(' ', indent * 4);

                formattedConditions.Add(spaces + condition);
            }

            return string.Join(
                "\n" + new string(' ', indent * 4) + "OR\n",
                formattedConditions
            );
        }
    }

    public string Build()
    {
        if (conditions.Count == 0)
        {
            return "";
        }

        string sql = "WHERE " + conditions[0];

        for (int i = 1; i < conditions.Count; i++)
        {
            sql += "\nAND " + conditions[i];
        }

        return sql;
    }
}

class Program
{
    static void Main()
    {
        QueryBuilder builder = new QueryBuilder();

        builder.AddWhereClause("Status = 'Active'");

        builder.AddWhereClause(
            b =>
            {
                b.AddWhereClause("Age > 18");
                b.AddWhereClause("Age < 65");
            }
        );

        Console.WriteLine(builder.Build());
    }
}