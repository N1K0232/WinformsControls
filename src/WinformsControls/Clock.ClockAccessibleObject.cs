namespace WinformsControls;

public partial class Clock
{
    /// <summary>
    /// defines an <see cref="AccessibleObject"/> for <see cref="Clock"/> user control
    /// </summary>
    public class ClockAccessibleObject : ControlAccessibleObject
    {
        private readonly Clock _owner;

        /// <summary>
        /// creates a new instance of <see cref="ClockAccessibleObject"/> class
        /// with the specified control
        /// </summary>
        /// <param name="owner">the control</param>
        /// <exception cref="ArgumentException"><paramref name="owner"/> is not a <see cref="Clock"/> control</exception>
        public ClockAccessibleObject(Control owner)
            : base(owner is Clock clock ? clock
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
            _owner = clock;
        }
    }
}