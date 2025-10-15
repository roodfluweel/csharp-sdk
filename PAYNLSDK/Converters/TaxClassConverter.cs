using System;

namespace PayNLSdk.Converters;

internal class TaxClassConverter : EnumConversionBase
{
    public override Type EnumType => typeof(Enums.TaxClass);
}
