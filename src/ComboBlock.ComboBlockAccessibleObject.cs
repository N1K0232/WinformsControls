namespace WinformsControls;

public partial class ComboBlock
{
    /// <summary>
    /// represents the <see cref="Control.ControlAccessibleObject"/> for
    /// <see cref="ComboBlock"/> control
    /// </summary>
    public class ComboBlockAccessibleObject : ControlAccessibleObject
    {
        public ComboBlockAccessibleObject(Control owner)
            : base(owner is ComboBlock comboBlock ? comboBlock
            : throw new ArgumentException("Invalid control", nameof(owner)))
        {
        }
    }
}