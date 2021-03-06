﻿
using System.Windows;
using WinHue3.Philips_Hue.BridgeObject;
using WinHue3.Philips_Hue.HueObjects.Common;
using WinHue3.Utils;

namespace WinHue3.Functions.Renaming
{
  
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Form_RenameObject : Window
    {
        private readonly Bridge _bridge;
        private readonly IHueObject _obj;
        public Form_RenameObject(Bridge bridge,IHueObject obj)
        {

            InitializeComponent();
            _bridge = bridge;
            _obj = obj;
            Title = string.Format(Title,  obj.name);
            TbNewName.Text = obj.name;

        }

        private void btnRename_Click(object sender, RoutedEventArgs e)
        {
            _obj.name = TbNewName.Text;
            bool result = !_bridge.Virtual ? _bridge.RenameObject(_obj) : true;
            
            if (result)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBoxError.ShowLastErrorMessages(_bridge);
            }
 
        }

        public string GetNewName()
        {
            return TbNewName.Text;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
