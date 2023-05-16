namespace WinformsControls;

public partial class ComboBlock
{
    public class ComboBlockAccessibleObject : ControlAccessibleObject
    {
        public ComboBlockAccessibleObject(Control owner)
            : base(owner is ComboBlock comboBlock ? comboBlock
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
        }
    }
}