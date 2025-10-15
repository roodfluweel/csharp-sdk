using System;

namespace PayNLSdk.Converters;

internal class GenderConverter : EnumConversionBase
{
    public override Type EnumType => typeof(Enums.Gender);
}
