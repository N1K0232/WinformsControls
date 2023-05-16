namespace WinformsControls;

public partial class RoundButton
{
    /// <summary>
    /// defines an <see cref="AccessibleObject"/> for <see cref="RoundButton"/> class
    /// </summary>
    public class RoundButtonAccessibleObject : ButtonBaseAccessibleObject
    {
        /// <summary>
        /// creates a new instance of <see cref="RoundButtonAccessibleObject"/> class
        /// </summary>
        /// <param name="owner">the owner control</param>
        /// <exception cref="ArgumentException">the control is not a <see cref="RoundButton"/></exception>
        public RoundButtonAccessibleObject(Control owner)
            : base(owner is RoundButton button ? button
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
        }
    }
}