namespace Register.MobileApp.Helpers.Data;

using Smart.Data.Mapper.Handlers;

public sealed class DateTimeTypeHandler : TypeHandler<DateTime>
{
    public override void SetValue(IDbDataParameter parameter, DateTime value)
    {
        parameter.DbType = DbType.Int64;
        parameter.Value = value.Ticks;
    }

    public override DateTime Parse(object value)
    {
        return new((long)value);
    }
}
