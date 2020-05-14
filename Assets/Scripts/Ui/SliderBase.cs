﻿using Ui.Scenes.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public abstract class SliderBase : SettingsBase
    {
        [SerializeField] private Slider slider;

        protected abstract float Value { get; set; }

        protected virtual void OnInputChange(float value) => this.Value = value;

        private void Start()
        {
            this.slider.onValueChanged.AddListener(this.OnInputChange);
            this.slider.value = this.Value;
        }
    }
}