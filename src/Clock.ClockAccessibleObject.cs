namespace WinformsControls;

public partial class Clock
{
    public class ClockAccessibleObject : ControlAccessibleObject
    {
        private readonly Clock _owner;

        public ClockAccessibleObject(Control owner)
            : base(owner is Clock clock ? clock
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
            _owner = clock;
        }
    }
}