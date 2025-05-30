using System;
using System.Windows;          // Для Window    
using System.Windows.Media;    // Для работы с цветами

namespace PointApp
{
    public partial class MainWindow : Window
    {
        private Point currentPoint;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void BtnCreatePoint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = txtCoordinates.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    ShowError("Введите координаты точки!");
                    return;
                }

                string[] coords = input.Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (coords.Length != 2)
                {
                    ShowError("Нужно ввести 2 числа через пробел или точку с запятой!");
                    return;
                }

                if (!double.TryParse(coords[0], out double x) || !double.TryParse(coords[1], out double y))
                {
                    ShowError("Введите корректные числа!");
                    return;
                }

                currentPoint = new Point(x, y);
                UpdateUI();
                ShowResult($"Создана точка: {currentPoint}");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void BtnIncrement_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPointCreated())
            {
                currentPoint = ++currentPoint;
                UpdateUI();
                ShowResult($"После ++: {currentPoint}");
            }
        }

        private void BtnDecrement_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPointCreated())
            {
                currentPoint = --currentPoint;
                UpdateUI();
                ShowResult($"После --: {currentPoint}");
            }
        }

        private void BtnExplicitCast_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPointCreated())
            {
                ShowResult($"Явное приведение X к int: {(int)currentPoint.X}");
            }
        }

        private void BtnImplicitCast_Click(object sender, RoutedEventArgs e)
        {
            if (CheckPointCreated())
            {
                double yCoord = currentPoint.Y;
                ShowResult($"Неявное приведение Y к double: {yCoord}");
            }
        }

        private void BtnDistance_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckPointCreated()) return;

            try
            {
                string input = txtSecondPoint.Text.Trim();
                string[] coords = input.Split(new[] { ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (coords.Length != 2 || !double.TryParse(coords[0], out double x) || !double.TryParse(coords[1], out double y))
                {
                    ShowError("Введите 2 числа через пробел или точку с запятой!");
                    return;
                }

                Point secondPoint = new Point(x, y);
                double distance = currentPoint.DistanceTo(secondPoint);
                ShowResult($"Расстояние между {currentPoint} и {secondPoint}: {distance:F2}");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void BtnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckPointCreated()) return;

            try
            {
                string input = txtNumber.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    ShowError("Введите число!");
                    return;
                }

                if (!int.TryParse(input, out int num))
                {
                    ShowError("Введите целое число!");
                    return;
                }

                Point newPoint = currentPoint + num;
                ShowResult($"Точка {currentPoint} + {num} по X = {newPoint}");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private void BtnSubtractNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckPointCreated()) return;

            try
            {
                string input = txtSubtractNumber.Text.Trim();
                if (string.IsNullOrEmpty(input))
                {
                    ShowError("Введите число!");
                    return;
                }

                if (!int.TryParse(input, out int num))
                {
                    ShowError("Введите целое число!");
                    return;
                }

                Point newPoint = currentPoint - num;
                ShowResult($"Точка {currentPoint} - {num} по X = {newPoint}");
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка: {ex.Message}");
            }
        }

        private bool CheckPointCreated()
        {
            if (currentPoint == null)
            {
                ShowError("Сначала создайте точку!");
                return false;
            }
            return true;
        }

        private void UpdateUI()
        {
            if (currentPoint != null)
            {
                txtCurrentPoint.Text = currentPoint.ToString();
                txtCurrentPoint.FontWeight = FontWeights.Bold;
                txtCurrentPoint.Foreground = Brushes.DarkBlue;
            }
            else
            {
                txtCurrentPoint.Text = "Точка не создана";
                txtCurrentPoint.FontWeight = FontWeights.Normal;
                txtCurrentPoint.Foreground = Brushes.Black;
            }
        }

        private void ShowResult(string message)
        {
            txtResult.Text = message;
            txtResult.Foreground = System.Windows.Media.Brushes.Blue;
        }

        private void ShowError(string message)
        {
            txtResult.Text = message;
            txtResult.Foreground = System.Windows.Media.Brushes.Red;
        }
    }
}
