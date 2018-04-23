Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.Ribbon
Imports DevExpress.Xpf.Editors.Settings
Imports DevExpress.Xpf.Core
Imports DevExpress.Utils

Namespace RibbonControl_Ex
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			bFileName.Content = "Document 1"
			CType(eFontSize.EditSettings, ComboBoxEditSettings).ItemsSource = (New FontSizes()).Items
			eFontSize.EditValue = 10
			bPosInfo.Content = "Line:1 Col:1"
		End Sub

		Private Sub eRibbonStyle_EditValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If RibbonControl IsNot Nothing Then
				RibbonControl.RibbonStyle = CType(Me.eRibbonStyle.EditValue, RibbonStyle)
			End If
		End Sub

		Private Sub eFontSize_EditValueChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'...
		End Sub

		Private Sub OptionsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			TryCast(RibbonControl.ApplicationMenu, ApplicationMenuInfo).ClosePopup()
		End Sub
		Private Sub ExitButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			TryCast(RibbonControl.ApplicationMenu, ApplicationMenuInfo).ClosePopup()
		End Sub

		Private Sub groupFile_CaptionButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			MessageBox.Show("File Open Dialog")
		End Sub

		Private Sub groupEdit_CaptionButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			MessageBox.Show("Edit Settings Dialog")
		End Sub

		Private Sub bAbout_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			MessageBox.Show("About Window")
		End Sub

		#Region "#CustomPageCategory"
		Private Sub bShowHideCustomCategory_CheckedChanged(ByVal sender As Object, ByVal e As ItemClickEventArgs)
			categorySelection.IsVisible = CBool(bShowHideCustomCategory.IsChecked)
			RibbonControl.SelectedPage = categorySelection.Pages(0)
		End Sub
		#End Region ' #CustomPageCategory

		#Region "#Gallery"
		Protected Overridable Sub OnThemeDropDownGalleryInit(ByVal sender As Object, ByVal e As DropDownGalleryEventArgs)
			Dim gallery As Gallery = e.DropDownGallery.Gallery
			gallery.AllowHoverImages = False
			gallery.IsItemCaptionVisible = True
			gallery.ItemGlyphLocation = Dock.Top
			gallery.IsGroupCaptionVisible = DefaultBoolean.True
		End Sub

		Protected Overridable Sub OnThemeItemClick(ByVal sender As Object, ByVal e As GalleryItemEventArgs)
			Dim themeName As String = CStr(e.Item.Tag)
			ThemeManager.ApplicationThemeName = themeName
		End Sub
		#End Region ' #Gallery
	End Class


	Public Class RecentItem
		Private privateNumber As Integer
		Public Property Number() As Integer
			Get
				Return privateNumber
			End Get
			Set(ByVal value As Integer)
				privateNumber = value
			End Set
		End Property
		Private privateFileName As String
		Public Property FileName() As String
			Get
				Return privateFileName
			End Get
			Set(ByVal value As String)
				privateFileName = value
			End Set
		End Property
	End Class

	Public Class ButtonWithImageContent
		Private privateImageSource As String
		Public Property ImageSource() As String
			Get
				Return privateImageSource
			End Get
			Set(ByVal value As String)
				privateImageSource = value
			End Set
		End Property
		Private privateContent As Object
		Public Property Content() As Object
			Get
				Return privateContent
			End Get
			Set(ByVal value As Object)
				privateContent = value
			End Set
		End Property
	End Class

	Public Class FontSizes
		Public ReadOnly Property Items() As Double()
			Get
				Return New Double() { 3.0, 4.0, 5.0, 6.0, 6.5, 7.0, 7.5, 8.0, 8.5, 9.0, 9.5, 10.0, 10.5, 11.0, 11.5, 12.0, 12.5, 13.0, 13.5, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 22.0, 24.0, 26.0, 28.0, 30.0, 32.0, 34.0, 36.0, 38.0, 40.0, 44.0, 48.0, 52.0, 56.0, 60.0, 64.0, 68.0, 72.0, 76.0, 80.0, 88.0, 96.0, 104.0, 112.0, 120.0, 128.0, 136.0, 144.0 }
			End Get
		End Property
	End Class
End Namespace
