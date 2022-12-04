namespace WinformsControls;

public partial class CustomDateTimePicker
{
    /// <summary>
    /// defines an <see cref="AccessibleObject"/> for <see cref="CustomDateTimePicker"/> control
    /// </summary>
    public class CustomDateTimePickerAccessibleObject : DateTimePickerAccessibleObject
    {
        /// <summary>
        /// creates a new instance of the <see cref="CustomDateTimePickerAccessibleObject"/> class
        /// with the specified <see cref="Control"/>
        /// </summary>
        /// <param name="owner">the control object</param>
        /// <exception cref="ArgumentException">the control is not a <see cref="CustomDateTimePicker"/></exception>
        public CustomDateTimePickerAccessibleObject(Control owner)
            : base(owner is CustomDateTimePicker dateTimePicker ? dateTimePicker
                  : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}