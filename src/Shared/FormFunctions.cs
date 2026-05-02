using FF7Scarlet.Shared.Controls;
using Shojy.FF7.Elena.Attacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace FF7Scarlet.Shared
{
    public static class FormFunctions
    {
        /// <summary>
        /// Recursively enables or disables controls for a control and all of its children.
        /// </summary>
        /// <param name="group">The parent control</param>
        /// <param name="enabled">Whether to enable or disable controls</param>
        /// <param name="ignoreList">A list of controls to ignore when enabling</param>
        public static void EnableOrDisableInner(Control group, bool enabled, ReadOnlyCollection<Control>? ignoreList)
        {
            for (int i = 0; i < group.Controls.Count; ++i)
            {
                var c = group.Controls[i];
                if (c != null)
                {
                    //check if control is ignored
                    if (ignoreList != null && ignoreList.Contains(c))
                    {
                        //if (!(c is ListBox)) { c.Enabled = false; }
                    }
                    else
                    {
                        if (c is AttackFormControl) //get inner tabs
                        {
                            var atkForm = c as AttackFormControl;
                            if (atkForm != null)
                            {
                                atkForm.EnableOrDisableControls(enabled, false);
                            }
                        }

                        else if (c is TabControl) //get inner tabs
                        {
                            var innerTab = c as TabControl;
                            if (innerTab != null)
                            {
                                for (int j = 0; j < innerTab.TabCount; ++j)
                                {
                                    EnableOrDisableInner(innerTab.TabPages[j], enabled, ignoreList);
                                }
                            }
                        }
                        else if (c is GroupBox) //get controls in group box
                        {
                            var groupBox = c as GroupBox;
                            if (groupBox != null)
                            {
                                EnableOrDisableInner(groupBox, enabled, ignoreList);
                            }
                        }
                        else { c.Enabled = enabled; }
                    }
                }
            }
        }

        /// <summary>
        /// Recursively updates all inner controls.
        /// </summary>
        /// <param name="ctrl">The control to update.</param>
        public static void ForceUpdate(Control ctrl)
        {
            ctrl.Update();
            foreach (Control c in ctrl.Controls)
            {
                ForceUpdate(c);
            }
            if (ctrl is TabControl) //get inner tabs
            {
                var innerTab = ctrl as TabControl;
                if (innerTab != null)
                {
                    for (int j = 0; j < innerTab.TabCount; ++j)
                    {
                        ForceUpdate(innerTab.TabPages[j]);
                    }
                }
            }
        }

        public static byte ValidateHexByte(string text, byte current)
        {
            if (text.Length == 2)
            {
                byte newID;
                if (byte.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                {
                    return newID;
                }
                else { SystemSounds.Exclamation.Play(); }
            }
            return current;
        }

        public static ushort ValidateHexShort(string text, ushort current)
        {
            if (text.Length == 4)
            {
                ushort newID;
                if (ushort.TryParse(text, NumberStyles.HexNumber, HexParser.CultureInfo, out newID))
                {
                    return newID;
                }
                else { SystemSounds.Exclamation.Play(); }
            }
            return current;
        }
    }
}
