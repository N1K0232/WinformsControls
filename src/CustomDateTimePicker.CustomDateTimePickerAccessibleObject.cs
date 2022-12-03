namespace WinformsControls;

public partial class CustomDateTimePicker
{
    public class CustomDateTimePickerAccessibleObject : DateTimePickerAccessibleObject
    {
        public CustomDateTimePickerAccessibleObject(Control owner)
            : base(owner is CustomDateTimePicker dateTimePicker ? dateTimePicker
                  : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}