﻿public class PreferredFps : InputFieldBase
{
    protected override string Input
    {
        get => Assets.Instance.Settings.PreferredFps.ToString();
        set
        {
            int.TryParse(value, out int val);
            Assets.Instance.Settings.PreferredFps = val;
        }
    }
}