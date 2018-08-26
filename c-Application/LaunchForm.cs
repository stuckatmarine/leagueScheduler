using System;
using System.Windows.Forms;
using System.Drawing;

namespace league
{
	public class LaunchForm : Form
	{
		public LaunchForm()
		{

			Text = "Launch Form";
			Size = new Size(250, 200);
			CenterToScreen();
		}

		/*	static public void Main()
	{
		Application.Run(new Simple());
	}
*/
	}
}

