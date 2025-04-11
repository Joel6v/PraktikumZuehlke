using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CharacterConfigurator.View.Controls
{
    public class RandomizedTextBox : TextBox
    {
        private string _actualText = "";
        private DispatcherTimer _randomTimer;
        private DispatcherTimer _stopTimer;
        private Random _random = new Random();
        private bool _isRandomizing = false;

        public RandomizedTextBox()
        {
            _randomTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            _randomTimer.Tick += RandomTimer_Tick;

            _stopTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _stopTimer.Tick += StopTimer_Tick;

            this.TextChanged += RandomizedTextBox_TextChanged;
        }

        private void RandomizedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isRandomizing) return;

            _actualText = this.Text;

            _randomTimer.Start();
            _stopTimer.Stop();
            _stopTimer.Start();
        }

        private void RandomTimer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_actualText)) return;

            _isRandomizing = true;

            int caretIndex = this.CaretIndex;

            string randomText = new string(_actualText.Select(c => (char)_random.Next(33, 126)).ToArray());
            this.Text = randomText;

            this.CaretIndex = Math.Min(caretIndex, this.Text.Length);
            _isRandomizing = false;
        }

        private void StopTimer_Tick(object sender, EventArgs e)
        {
            _randomTimer.Stop();
            _stopTimer.Stop();
        }

        public string GetActualText() => _actualText;
    }
}
