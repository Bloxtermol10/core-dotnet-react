using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class TableSchemaAttribute : Attribute
{
    public string Schema { get; }

    public TableSchemaAttribute(string schema)
    {
        Schema = schema;
    }
}