using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Core;
using DevExpress.Utils;

namespace RibbonControl_Ex {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            bFileName.Content = "Document 1";
            ((ComboBoxEditSettings)eFontSize.EditSettings).ItemsSource = (new FontSizes()).Items;
            eFontSize.EditValue = 10;
            bPosInfo.Content = "Line:1 Col:1";
        }

        private void eRibbonStyle_EditValueChanged(object sender, RoutedEventArgs e) {
            if (RibbonControl != null)
                RibbonControl.RibbonStyle = (RibbonStyle)this.eRibbonStyle.EditValue;
        }

        void eFontSize_EditValueChanged(object sender, RoutedEventArgs e) {
            //...
        }

        void OptionsButton_Click(object sender, RoutedEventArgs e) {
            (RibbonControl.ApplicationMenu as ApplicationMenuInfo).ClosePopup();
        }
        void ExitButton_Click(object sender, RoutedEventArgs e) {
            (RibbonControl.ApplicationMenu as ApplicationMenuInfo).ClosePopup();
        }

        void groupFile_CaptionButtonClick(object sender, EventArgs e) {
            MessageBox.Show("File Open Dialog");
        }

        void groupEdit_CaptionButtonClick(object sender, EventArgs e) {
            MessageBox.Show("Edit Settings Dialog");
        }

        private void bAbout_ItemClick(object sender, ItemClickEventArgs e) {
            MessageBox.Show("About Window");
        }

        #region #CustomPageCategory
        private void bShowHideCustomCategory_CheckedChanged(object sender, ItemClickEventArgs e) {
            categorySelection.IsVisible = (bool)bShowHideCustomCategory.IsChecked;
            RibbonControl.SelectedPage = categorySelection.Pages[0];
        }
        #endregion #CustomPageCategory

        #region #Gallery
        protected virtual void OnThemeDropDownGalleryInit(object sender, DropDownGalleryEventArgs e) {
            Gallery gallery = e.DropDownGallery.Gallery;
            gallery.AllowHoverImages = false;
            gallery.IsItemCaptionVisible = true;
            gallery.ItemGlyphLocation = Dock.Top;
            gallery.IsGroupCaptionVisible = DefaultBoolean.True;
        }

        protected virtual void OnThemeItemClick(object sender, GalleryItemEventArgs e) {
            string themeName = (string)e.Item.Tag;
            ThemeManager.ApplicationThemeName = themeName;
        }
        #endregion #Gallery
    }


    public class RecentItem {
        public int Number { get; set; }
        public string FileName { get; set; }
    }

    public class ButtonWithImageContent {
        public string ImageSource { get; set; }
        public object Content { get; set; }
    }

    public class FontSizes {
        public double[] Items {
            get {
                return new double[] { 
            3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0, 9.5, 
            10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0, 15.0,
            16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0,
            32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0, 60.0, 64.0, 68.0, 72.0, 76.0,
            80.0, 88.0, 96.0, 104.0, 112.0, 120.0, 128.0, 136.0, 144.0
            };
            }
        }
    }
}
