using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlayStream
{
    /// <summary>
    /// Lógica de interacción para WindowConfig.xaml
    /// </summary>
    public partial class CambiarIdioma : Window
    {
        const string LANG_ENG = "en_US";
        const string LANG_ES = "es_ES";

        public CambiarIdioma()
        {
            InitializeComponent();
            
            Config.GetInstance().Load();

            var lang = Config.GetInstance().lang;

            if (lang != null)
            {
                if (lang.Equals(LANG_ES))
                {
                    rbLangES.IsChecked = true;
                }
                else if (lang.Equals(LANG_ENG))
                {
                    rbLangENG.IsChecked = true;
                }
            }

           

        }

        public void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void BtnAceptar_Click(object sender, RoutedEventArgs e) 
        {
            Close();
            if ((bool)rbLangES.IsChecked)
            {
                Config.GetInstance().lang = LANG_ES;
            }
            else if ((bool)rbLangENG.IsChecked)
            {
                Config.GetInstance().lang = LANG_ENG;
            }


           

            Config.GetInstance().save();
        }
    }
}
