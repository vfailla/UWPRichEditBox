using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPRichEditBox
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public FontFamily FONT_FAMILY = new FontFamily("Arial");
		public const int FONT_SIZE = 14;
		private static readonly Color FONT_FOREGROUND_COLOR = Color.FromArgb(255, 59, 52, 26);
		public static readonly SolidColorBrush FONT_FOREGROUND = new SolidColorBrush(FONT_FOREGROUND_COLOR);
		public const float LINE_SPACING = 20f;

		private string m_text = "From magazines to novels, reading forms a critical part of our lives. And beyond the relatively passive reading of a blog or newspaper, many reading tasks involve a richer interaction with the text. This interaction, known as active reading (AR) includes processes such as highlighting";

		private RichEditBox m_richEditBox;
		private RichTextBlock m_richTextBlock;


		public MainPage()
		{
			this.InitializeComponent();
			AddEditBox();
			AddTextBlock();
		}

		public void AddEditBox()
		{
			m_richEditBox = new RichEditBox
			{
				FontFamily = FONT_FAMILY,
				FontSize = FONT_SIZE,
				Padding = new Thickness(0),
				TextWrapping = TextWrapping.Wrap,
				Foreground = FONT_FOREGROUND,
				BorderThickness = new Thickness(0),
				AcceptsReturn = true,
				AllowFocusWhenDisabled = false,

				SelectionFlyout = null, // This is to hide the "Bold/Italic/Underlined" Flyout
				ContextFlyout = null, // This is to hide the Flyout appearing on mouse right click
			};

			m_richEditBox.Document.SetText(TextSetOptions.ApplyRtfDocumentDefaults, m_text);

			m_richEditBox.Margin = new Thickness(100, 100, 0, 0);
			m_richEditBox.Width = 300;
			m_richEditBox.Height = 300;

			Workspace.Children.Add(m_richEditBox);
		}

		public void AddTextBlock()
		{
			m_richTextBlock = new RichTextBlock
			{
				FontFamily = FONT_FAMILY,
				FontSize = FONT_SIZE,
				TextWrapping = TextWrapping.Wrap,
				Foreground = FONT_FOREGROUND,
				MaxLines = 0, //Let it use as many lines as it wants
				AllowFocusOnInteraction = false,
				IsHitTestVisible = false,
				//LineHeight = LINE_SPACING
			};

			// Create run and set text
			Run run = new Run
			{
				Text = m_text
			};

			// Create paragraph
			Paragraph paragraph = new Paragraph();

			// Add run to the paragraph
			paragraph.Inlines.Add(run);

			// Add paragraph to the rich text block
			m_richTextBlock.Blocks.Add(paragraph);

			m_richTextBlock.Margin = new Thickness(m_richEditBox.Margin.Left + m_richEditBox.Width + 50, m_richEditBox.Margin.Top, 0, 0);
			m_richTextBlock.Width = 300;
			m_richTextBlock.Height = 300;

			Workspace.Children.Add(m_richTextBlock);
		}

		private void Bt_changeFontToArial_OnClick(object sender, RoutedEventArgs e)
		{
			m_richEditBox.FontFamily = new FontFamily("Arial"); ;
			m_richTextBlock.FontFamily = new FontFamily("Arial"); ;
		}
		private void Bt_changeFontToCourier_OnClick(object sender, RoutedEventArgs e)
		{
			m_richEditBox.FontFamily = new FontFamily("Courier"); ;
			m_richTextBlock.FontFamily = new FontFamily("Courier"); ;
		}
	}
}
