#region File Notice
// Created at: 2013/12/24 3:44 PM
// Last Update time: 2013/12/24 4:02 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Windows.Forms;
using Library40.Validation;

namespace Library40.Win.Forms.Validation
{
	public static class FormValidator
	{
		public static void AssertNotNull(this TextBox textBox, string name)
		{
			try
			{
				var validator = new Validator();
				validator.AssertNotNull(textBox.Text, name);
			}
			catch (Exception)
			{
				textBox.Focus();
				throw;
			}
		}

		public static void AssertEqual(this TextBox textBox1, string name1, TextBox textBox2, string name2)
		{
			try
			{
				var validator = new Validator();
				validator.AssertEqual(textBox1.Text, name1, textBox2.Text, name2);
			}
			catch (Exception)
			{
				textBox1.Focus();
				throw;
			}
		}

		public static void AssertNotNull(this MaskedTextBox textBox, string name)
		{
			try
			{
				var validator = new Validator();
				validator.AssertNotNull(textBox.Text, name);
			}
			catch (Exception)
			{
				textBox.Focus();
				throw;
			}
		}

		public static void AssertNotNull(this ComboBox comboBox, string name)
		{
			try
			{
				var validator = new Validator();
				validator.AssertNotNull(comboBox.Text, name);
			}
			catch (Exception)
			{
				comboBox.Focus();
				throw;
			}
		}

		public static void AssertNotNull(this ListBox listBox, string name)
		{
			try
			{
				var validator = new Validator();
				validator.AssertNotNull(listBox.Items, name);
			}
			catch (Exception)
			{
				listBox.Focus();
				throw;
			}
		}
	}
}