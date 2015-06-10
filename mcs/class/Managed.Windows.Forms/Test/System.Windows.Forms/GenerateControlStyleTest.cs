//
// This code generates the ControlStylesTest.cs test
//
// Author: Peter Dennis Bartok (pbartok@novell.com)
//


using System.Windows.Forms;
using System.Drawing;
using System;
using System.Reflection;
using System.IO;
using System.Text;

namespace TestApp {
	class MainForm {
		static Array style_values = Enum.GetValues(typeof(ControlStyles));
		static string[] style_names = Enum.GetNames(typeof(ControlStyles));
		static string TestHeader =	"//\n" +
						"// ControlStyleTest.cs (Auto-generated by GenerateControlStyleTest.cs).\n" +
						"//\n" +
						"// Author: \n" +
						"//   Peter Dennis Bartok (pbartok@novell.com)\n" +
						"//\n" +
						"// (C) 2005 Novell, Inc. (http://www.novell.com)\n" +
						"//\n" +
						"using System;\n" +
						"using System.Windows.Forms;\n" +
						"using System.Drawing;\n" +
						"using System.Reflection;\n" +
						"using NUnit.Framework;\n\n" +
						"namespace MonoTests.System.Windows.Forms {\n" +
						"\t[TestFixture]\n" + 
						"\tpublic class TestControlStyle {\n\n" +
						"\t\tstatic Array style_values = Enum.GetValues(typeof(ControlStyles));\n" + 
						"\t\tstatic string[] style_names = Enum.GetNames(typeof(ControlStyles));\n\n" + 
						"		public static string[] GetStyles(Control control) {\n" + 
						"			string[] result;\n\n" +
						"			result = new string[style_names.Length];\n\n" +
						"			for (int i = 0; i < style_values.Length; i++) {\n" +
						"				result[i] = style_names[i] + \"=\" + control.GetType().GetMethod(\"GetStyle\", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(control, new object[1] {(ControlStyles)style_values.GetValue(i)});\n" +
						"			}\n\n" +
						"			return result;\n" +
						"		}\n";
		static string TestFooter =	"\t}\n}\n";

		public static string[] GetStyles(Control control) {
			string[] result;

			result = new string[style_names.Length];

			for (int i = 0; i < style_values.Length; i++) {
				result[i] = style_names[i] + "=" + control.GetType().GetMethod("GetStyle", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(control, new object[1] {(ControlStyles)style_values.GetValue(i)});
			}

			return result;
		}

		public static void TestStyles(StreamWriter file, Control control, string name) {
			string[] results;

			results = GetStyles(control);

			file.WriteLine("\t\t[Test]");
			file.WriteLine("\t\tpublic void {0}StyleTest ()", name);
			file.WriteLine("\t\t{");

			file.WriteLine("\t\t\tstring[] {0}_want = {{", name);
			for (int i=0; i < results.Length; i++) {
				if ((i+1) != results.Length) {
					file.WriteLine("\t\t\t\t\"{0}\",", results[i]);
				} else {
					file.WriteLine("\t\t\t\t\"{0}\"", results[i]);
				}
			}
			file.WriteLine("\t\t\t};\n");
			file.WriteLine("\t\t\tAssert.AreEqual({0}_want, GetStyles(new {0}()), \"{0}Styles\");", name);
			file.WriteLine("\t\t}\n\n");
		}

		public static void Main(string[] args) {
			using (StreamWriter file = new StreamWriter("c:\\ControlStyleTest.cs", false, Encoding.ASCII, 1024)) {
				file.WriteLine(TestHeader);
				TestStyles(file, new Control(), "Control");
				TestStyles(file, new Button(), "Button");
				TestStyles(file, new CheckBox(), "CheckBox");
				TestStyles(file, new RadioButton(), "RadioButton");
				TestStyles(file, new DataGrid(), "DataGrid");
				TestStyles(file, new DateTimePicker(), "DateTimePicker");
				TestStyles(file, new GroupBox(), "GroupBox");
				TestStyles(file, new Label(), "Label");
				TestStyles(file, new LinkLabel(), "LinkLabel");
				TestStyles(file, new ComboBox(), "ComboBox");
				TestStyles(file, new ListBox(), "ListBox");
				TestStyles(file, new CheckedListBox(), "CheckedListBox");
				TestStyles(file, new ListView(), "ListView");
				TestStyles(file, new MdiClient(), "MdiClient");
				TestStyles(file, new MonthCalendar(), "MonthCalendar");
				TestStyles(file, new PictureBox(), "PictureBox");
				// Mono doesn't support yet
				//TestStyles(file, new PrintPreviewControl(), "PrintPreviewControl");
				TestStyles(file, new ProgressBar(), "ProgressBar");
				TestStyles(file, new ScrollableControl(), "ScrollableControl");
				TestStyles(file, new ContainerControl(), "ContainerControl");
				Form f = new Form ();
				f.ShowInTaskbar = false;
				TestStyles(file, f, "Form");
				f.Dispose ();
				TestStyles(file, new PropertyGrid(), "PropertyGrid");
				TestStyles(file, new DomainUpDown(), "DomainUpDown");
				TestStyles(file, new NumericUpDown(), "NumericUpDown");
				TestStyles(file, new UserControl(), "UserControl");
				TestStyles(file, new Panel(), "Panel");
				TestStyles(file, new TabPage(), "TabPage");
				TestStyles(file, new HScrollBar(), "HScrollBar");
				TestStyles(file, new VScrollBar(), "VScrollBar");
				TestStyles(file, new Splitter(), "Splitter");
				TestStyles(file, new StatusBar(), "StatusBar");
				TestStyles(file, new TabControl(), "TabControl");
				TestStyles(file, new RichTextBox(), "RichTextBox");
				TestStyles(file, new TextBox(), "TextBox");
				TestStyles(file, new DataGridTextBox(), "DataGridTextBox");
				TestStyles(file, new ToolBar(), "ToolBar");
				TestStyles(file, new TrackBar(), "TrackBar");
				TestStyles(file, new TreeView(), "TreeView");
				file.WriteLine(TestFooter);
			}
		}
	}

}
