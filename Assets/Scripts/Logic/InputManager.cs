﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic
{
    public class InputManager : MonoBehaviour
    {
        private static readonly Dictionary<string, KeyCode[]> CustomInput = new Dictionary<string, KeyCode[]>
        {
            {"RefreshMaps", new[] {KeyCode.LeftControl, KeyCode.R}}
        };
        /*{"Input1",      new[] {KeyCode.W}},
      {"Input2",      new[] {KeyCode.A}},
      {"Input3",      new[] {KeyCode.S}},
      {"Input4",      new[] {KeyCode.D}}*/

        public static bool MacroDown(string input) =>
            CustomInput[input].Take(CustomInput[input].Length - 1).All(UnityEngine.Input.GetKey) &&
            UnityEngine.Input.GetKeyDown(CustomInput[input][CustomInput.Count]);
    }
}