﻿using System.Windows;
using System.Windows.Controls;

namespace DS2_META
{
    public class METAControl : UserControl
    {
        public DS2Hook Hook
        {
            get { return (DS2Hook)GetValue(HookProperty); }
            set { SetValue(HookProperty, value); }
        }
        
        // Using a DependencyProperty as the backing store for Hook.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HookProperty =
            DependencyProperty.Register("Hook", typeof(DS2Hook), typeof(METAControl), new PropertyMetadata(default));

        public bool GameLoaded
        {
            get { return (bool)GetValue(GameLoadedProperty); }
            set { SetValue(GameLoadedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Loaded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameLoadedProperty =
            DependencyProperty.Register("GameLoaded", typeof(bool), typeof(METAControl), new PropertyMetadata(default));

        internal virtual void UpdateCtrl() { }
        internal virtual void ReloadCtrl() { }
        internal virtual void EnableCtrls(bool v) { }
        public virtual void InitTab() { }


    }
}