using PropertyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DS2_META
{
    internal class DS2ViewModel : ObservableObject
    {
        public DS2Hook Hook { get; private set; }
        public bool GameLoaded { get; set; }
        public bool Reading
        {
            get => DS2Hook.Reading;
            set => DS2Hook.Reading = value;
        }

        public DS2ViewModel()
        {
            Hook = new DS2Hook(5000, 5000);
            Hook.OnHooked += Hook_OnHooked;
            Hook.OnUnhooked += Hook_OnUnhooked;
            Hook.Start();
        }
        public Brush ForegroundID
        {
            get
            {
                if (Hook.ID != "Not Hooked")
                    return Brushes.GreenYellow;
                return Brushes.IndianRed;
            }
        }
        public string ContentLoaded
        {
            get
            {
                if (Hook.Loaded)
                    return "Yes";
                return "No";
            }
        }
        public Brush ForegroundLoaded
        {
            get
            {
                if (Hook.Loaded)
                    return Brushes.GreenYellow;
                return Brushes.IndianRed;
            }
        }
        public string ContentOnline
        {
            get
            {
                if (!Hook.Hooked)
                    return null;

                if (Hook.Online)
                    return "Yes";
                return "No";
            }
        }
        public Brush ForegroundOnline
        {
            get
            {
                if (!Hook.Hooked)
                    return null; 

                if (Hook.Online)
                    return Brushes.GreenYellow;
                return Brushes.IndianRed;
            }
        }

        public void UpdateMainProperties()
        {
            OnPropertyChanged(nameof(ForegroundID));
            OnPropertyChanged(nameof(ContentLoaded));
            OnPropertyChanged(nameof(ForegroundLoaded));
            OnPropertyChanged(nameof(ContentOnline));
            OnPropertyChanged(nameof(ForegroundOnline));
            OnPropertyChanged(nameof(GameLoaded));
        }

        private void Hook_OnHooked(object sender, PHEventArgs e)
        {
        }

        private void Hook_OnUnhooked(object sender, PHEventArgs e)
        {

        }
    }
}
