namespace FrameworkFragments.Validation;

public enum ValidationType
{
  None = 0,
  Simple,
  Uniqueness,
  RequiredReference,
  RequiredValue,
  ValueLength,
  ValueRange,
  ValueType,
  BusinessLogic
}