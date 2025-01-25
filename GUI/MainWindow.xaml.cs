using Common.models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateComponents();
        }
        private void GenerateComponents()
        {
            List<KeySetting> actions = new List<KeySetting>
            {
                new KeySetting { Key = '1' },
                new KeySetting { Key = '2' },
                new KeySetting { Key = '3' },
                new KeySetting { Key = '4' },
                new KeySetting { Key = '5' },
                new KeySetting { Key = '6' },
                new KeySetting { Key = '7' },
                new KeySetting { Key = '8' },
                new KeySetting { Key = '9' },
                new KeySetting { Key = 'q' },
                new KeySetting { Key = 'e' },
            };

            for (int i = 0; i < actions.Count; i++)
            {
                int row = i + 1; // Start from row 1

                // Create TextBlock
                TextBlock textBlock = new TextBlock
                {
                    Text = $"Key '{actions[i].Key}'",
                    FontWeight = FontWeights.SemiBold,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                Grid.SetRow(textBlock, row);
                Grid.SetColumn(textBlock, 0);
                MainGrid.Children.Add(textBlock); 

                // Create ComboBox
                ComboBox comboBox = new ComboBox
                {
                    Name = $"ActionType{actions[i].Key}",
                    VerticalAlignment = VerticalAlignment.Top,
                    Height = 25,
                    Margin = new Thickness(0, 5, 5, 0)
                };
                comboBox.Items.Add(new ComboBoxItem { Content = "Press" });
                comboBox.Items.Add(new ComboBoxItem { Content = "Hold" });
                comboBox.Items.Add(new ComboBoxItem { Content = "Activate Skill" });
                Grid.SetRow(comboBox, row);
                Grid.SetColumn(comboBox, 1);
                MainGrid.Children.Add(comboBox);

                // Create TextBoxes
                for (int j = 2; j <= 6; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Name = $"Action{GetTextBoxName(j, actions[i].Key.ToString())}",
                        Margin = new Thickness(0, 5, 5, 0)
                    };
                    Grid.SetRow(textBox, row);
                    Grid.SetColumn(textBox, j);
                    MainGrid.Children.Add(textBox);
                }

                // Create CheckBox
                CheckBox checkBox = new CheckBox
                {
                    Name = $"ActionStatus{actions[i].Key}",
                    Margin = new Thickness(0, 5, 5, 0)
                };
                Grid.SetRow(checkBox, row);
                Grid.SetColumn(checkBox, 7);
                MainGrid.Children.Add(checkBox);
            }
        }

        private string GetTextBoxName(int index, string key)
        {
            switch (index)
            {
                case 2: return $"Delay{key}";
                case 3: return $"HoldInterval{key}";
                case 4: return $"CD{key}";
                case 5: return $"RandomIndex{key}";
                case 6: return $"RepeatTime{key}";
                default: return string.Empty;
            }
        }
    }
}