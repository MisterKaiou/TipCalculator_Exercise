using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TipCalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            billInput.TextChanged += (s, e) => CalculateTip();
            roundDown.Clicked += (s, e) => CalculateTip(false, true);
            roundUp.Clicked += (s, e) => CalculateTip(true, false);

            tipPercentSlider.ValueChanged += (s, e) =>
            {
                double percent = Math.Round(e.NewValue);
                tipPercent.Text = percent + "%";
                CalculateTip();
            };
        }

        private void CalculateTip(bool roundUp = false, bool roundDown = false)
        {
            double total;
            if (Double.TryParse(billInput.Text, out total) && total > 0)
            {
                double percent = Math.Round(tipPercentSlider.Value);
                double tip = Math.Round(total * (percent / 100.0), 2);

                double final = total + tip;

                if (roundUp)
                {
                    final = Math.Ceiling(final);
                    tip = final - total;
                }
                else if (roundDown)
                {
                    final = Math.Floor(final);
                    tip = final - total;
                }

                tipOutput.Text = tip.ToString("C");
                totaOutput.Text = final.ToString("C");
            }
        }

        void OnNormalTip(object sender, EventArgs e) { tipPercentSlider.Value = 15; }
        void OnGenerousTip(object sender, EventArgs e) { tipPercentSlider.Value = 20; }
    }
}