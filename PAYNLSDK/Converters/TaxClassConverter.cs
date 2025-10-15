using System;

namespace PayNLSdk.Converters;

internal class TaxClassConverter : EnumConversionBase
{
    public override Type EnumType
    {
        get { return typeof(Enums.TaxClass); }
    }

    public override bool CanConvert(Type objectType)
    {
        throw new NotImplementedException();
    }
}
