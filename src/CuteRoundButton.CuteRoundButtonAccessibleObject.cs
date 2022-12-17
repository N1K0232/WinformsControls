namespace WinformsControls;

public partial class CuteRoundButton
{
    public class CuteRoundButtonAccessibleObject : RoundButtonAccessibleObject
    {
        public CuteRoundButtonAccessibleObject(Control owner)
            : base(owner is CuteRoundButton button ? button
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
        }
    }
}