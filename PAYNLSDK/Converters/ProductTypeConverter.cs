using System;

namespace PayNLSdk.Converters;

internal class ProductTypeConverter : EnumConversionBase
{
    public override Type EnumType => typeof(Enums.ProductType);
}
