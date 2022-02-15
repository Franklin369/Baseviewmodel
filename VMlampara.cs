using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lampara.VistaModelo
{
    public class VMlampara:BaseViewModel
    {
        private bool isPlaying;
        string iconoon = "https://i.ibb.co/dj5xjKk/encendido-1.png";
        string iconoof = "https://i.ibb.co/HXDmkwp/encendido.png";
        string focoOn = "https://i.ibb.co/P16XJWL/bombilla.png";
        string focoOf = "https://i.ibb.co/TgkLynn/bombilla-1.png";
        #region VARIABLES
        public string OnOficon { get => isPlaying ? iconoof : iconoon; }
        public string OnOffoco { get => isPlaying ? focoOn : focoOf; }

        #endregion
        #region CONSTRUCTOR
        public VMlampara()
        {

        }
        #region Objetos
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(OnOficon));
                OnPropertyChanged(nameof(OnOffoco));
            }
        }
        #endregion
        #region PROCESOS
        public async Task Onluz()
        {
            Vibrar();
            await Flashlight.TurnOnAsync();
        }
        public async Task Ofluz()
        {
            await Flashlight.TurnOffAsync();
        }
        private void Vibrar()
        {
            Vibration.Vibrate();
            var duration = TimeSpan.FromSeconds(1);
            Vibration.Vibrate(duration);
        }
        private async Task OnOf()
        {
            if(isPlaying)
            {
IsPlaying = false;
                await Ofluz();
             
            }
            else
            {
                   IsPlaying = true;

              await  Onluz();
            }
        }
        #endregion
        #endregion
        #region COMANDOS
        public ICommand Oncommand => new Command(async () => await Onluz());
        public ICommand OnOfcommand => new Command(async () => await OnOf());
        #endregion
    }
}
