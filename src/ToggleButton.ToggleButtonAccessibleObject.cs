namespace WinformsControls;

public partial class ToggleButton
{
    /// <summary>
    /// represents an <see cref="AccessibleObject"/> for <see cref="ToggleButton"/> class
    /// </summary>
    public class ToggleButtonAccessibleObject : CheckBoxAccessibleObject
    {
        /// <summary>
        /// creates a new instance of <see cref="ToggleButtonAccessibleObject"/> class
        /// </summary>
        /// <param name="owner">the owner control</param>
        /// <exception cref="ArgumentException">the owner is not a <see cref="ToggleButton"/> control</exception>
        public ToggleButtonAccessibleObject(Control owner)
            : base(owner is ToggleButton toggleButton ? toggleButton
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}