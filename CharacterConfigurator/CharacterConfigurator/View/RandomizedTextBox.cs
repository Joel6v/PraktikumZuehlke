using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        private bool _suppress = false;

        public static readonly DependencyProperty IsRandomizationEnabledProperty =
            DependencyProperty.Register(nameof(IsRandomizationEnabled), typeof(bool), typeof(RandomizedTextBox),
                new PropertyMetadata(true, OnRandomizationToggled));

        public bool IsRandomizationEnabled
        {
            get => (bool)GetValue(IsRandomizationEnabledProperty);
            set => SetValue(IsRandomizationEnabledProperty, value);
        }

        private static void OnRandomizationToggled(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as RandomizedTextBox;
            control?.UpdateDisplayText();
        }

        public RandomizedTextBox()
        {
            _randomTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
            _randomTimer.Tick += RandomTimer_Tick;

            _stopTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _stopTimer.Tick += StopTimer_Tick;

            this.TextChanged += OnTextChanged;
            this.PreviewTextInput += OnPreviewTextInput;
            this.PreviewKeyDown += OnPreviewKeyDown;
        }

        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (this.SelectionLength > 0)
                _actualText = _actualText.Remove(this.SelectionStart, this.SelectionLength);

            _actualText = _actualText.Insert(this.CaretIndex, e.Text);
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            int caret = this.CaretIndex;

            switch (e.Key)
            {
                case Key.Back:
                    if (this.SelectionLength > 0)
                        _actualText = _actualText.Remove(this.SelectionStart, this.SelectionLength);
                    else if (caret > 0)
                        _actualText = _actualText.Remove(caret - 1, 1);
                    break;

                case Key.Delete:
                    if (this.SelectionLength > 0)
                        _actualText = _actualText.Remove(this.SelectionStart, this.SelectionLength);
                    else if (caret < _actualText.Length)
                        _actualText = _actualText.Remove(caret, 1);
                    break;
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isRandomizing || _suppress) return;

            if (!IsRandomizationEnabled)
            {
                UpdateDisplayText();
                return;
            }

            _randomTimer.Start();
            _stopTimer.Stop();
            _stopTimer.Start();
        }

        private void RandomTimer_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_actualText) || !IsRandomizationEnabled) return;

            _isRandomizing = true;

            string randomized = new string(_actualText.Select(c =>
                char.IsWhiteSpace(c) ? c : (char)_random.Next(33, 126)).ToArray());

            SetDisplayText(randomized);
            _isRandomizing = false;
        }

        private void StopTimer_Tick(object sender, EventArgs e)
        {
            _stopTimer.Stop();
            _randomTimer.Stop();

            _isRandomizing = true;

            UpdateDisplayText();

            _isRandomizing = false;
        }

        private void UpdateDisplayText()
        {
            if (IsRandomizationEnabled)
            {
                SetDisplayText(_actualText);
            }
            else
            {
                string masked = new string(_actualText.Select(c => char.IsWhiteSpace(c) ? c : '*').ToArray());
                SetDisplayText(masked);
            }
        }

        private void SetDisplayText(string text)
        {
            int caret = this.CaretIndex;

            _suppress = true;
            this.Text = text;
            this.CaretIndex = Math.Min(caret, this.Text.Length);
            _suppress = false;
        }

        public string GetActualText() => _actualText;
    }
}
