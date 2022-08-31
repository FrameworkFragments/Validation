using System;
using System.Linq;
using System.Resources;

namespace FrameworkFragments.Validation;

internal class ValidationMessageFactory
{
  private const string MultipleValueSeparator = ", ";
  private static readonly Lazy<ValidationMessageFactory> Instance = new(() => new ValidationMessageFactory());
  private readonly ResourceManager _resourceManager;
  internal static ValidationMessageFactory Singleton => Instance.Value;

  private ValidationMessageFactory()
  {
    _resourceManager = new ResourceManager("ValidationMessages", typeof(ValidationMessageFactory).Assembly);
  }

  internal string RequiredReferenceFailure(string referenceTypeName)
  {
    return string.Format(
      _resourceManager.GetString("RequiredReferenceFailure")!,
      referenceTypeName
    );
  }

  internal string UniquenessFailure(string[] nonUniqueValues)
  {
    return string.Format(
      _resourceManager.GetString("RequiredReferenceFailure")!,
      nonUniqueValues.Length,
      string.Join(MultipleValueSeparator, nonUniqueValues)
    );
  }

  internal string RequiredValueFailure(string valueName)
  {
    return string.Format(
      _resourceManager.GetString("RequiredValueFailure")!,
      valueName
    );
  }

  internal string ValueRangeFailure(string valueName, string minInclusive, string maxInclusive)
  {
    return string.Format(
      _resourceManager.GetString("ValueRangeFailure")!,
      valueName,
      minInclusive,
      maxInclusive
    );
  }

  internal string ValueLengthFailure(string valueName, string minLengthInclusive, string maxLengthInclusive)
  {
    return string.Format(
      _resourceManager.GetString("ValueLengthFailure")!,
      valueName,
      minLengthInclusive,
      maxLengthInclusive
    );
  }

  internal string ValueTypeFailure(string valueName, string expectedType)
  {
    return string.Format(
      _resourceManager.GetString("ValueTypeFailure")!,
      valueName,
      expectedType
    );
  }
}