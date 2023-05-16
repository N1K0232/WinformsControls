namespace WinformsControls;

public partial class CuteButton : Button
{
    /// <summary>
    /// defines an <see cref="AccessibleObject"/> for <see cref="CuteButton"/> control
    /// </summary>
    public class CuteButtonAccessibleObject : ButtonBaseAccessibleObject
    {
        private readonly CuteButton _owner;

        /// <summary>
        /// creates a new instance of <see cref="CuteButtonAccessibleObject"/> class
        /// </summary>
        /// <param name="owner">the owner control</param>
        /// <exception cref="ArgumentException">the control is not a <see cref="CuteButton"/> control</exception>
        public CuteButtonAccessibleObject(Control owner)
            : base(owner is CuteButton button ? button
            : throw new ArgumentException("invalid control", nameof(owner)))
        {
            _owner = button;
        }
    }
}