#region File Notice
// Created at: 2013/12/24 3:44 PM
// Last Update time: 2013/12/24 4:06 PM
// Last Updated by: Mohammad Mir mostafa
#endregion

using System;
using System.Windows;
using System.Windows.Interop;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Library40.Wpf.Windows.Dialogs
{
	public sealed class MsgBoxEx : Library40.Windows.Dialogs.Internals.MsgBoxEx
	{
		public static TaskDialog GetTaskDialog(string instructionText = null,
			string text = null,
			string caption = null,
			TaskDialogStandardIcon icon = TaskDialogStandardIcon.None,
			TaskDialogStandardButtons buttons = TaskDialogStandardButtons.None,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = true,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = null,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			if (window == null)
				window = Application.Current.MainWindow;
			return GetTaskDialog(instructionText,
				text,
				caption,
				icon,
				buttons,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				new WindowInteropHelper(window).Handle,
				controls);
		}

		public static TaskDialogResult Show(string instructionText = null,
			string text = null,
			string caption = null,
			TaskDialogStandardIcon icon = TaskDialogStandardIcon.None,
			TaskDialogStandardButtons buttons = TaskDialogStandardButtons.None,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = true,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = null,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			TaskDialogResult result;
			using (
				var dialog = GetTaskDialog(instructionText,
					text,
					caption,
					icon,
					buttons,
					detailsExpandedLabel,
					detailsExpandedText,
					cancelable,
					detailsCollapsedLabel,
					detailsExpanded,
					footerCheckBoxChecked,
					footerCheckBoxText,
					footerIcon,
					footerText,
					hyperlinksEnabled,
					startupLocation,
					progressBarState,
					progressbarMinValue,
					progressbarMaxValue,
					progressbarCurrValue,
					action,
					window,
					controls))
				result = dialog.Show();

			return result;
		}

		public static void Inform(string instructionText = null,
			string text = null,
			string caption = null,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = false,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = false,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			Show(instructionText,
				text,
				caption,
				TaskDialogStandardIcon.Information,
				TaskDialogStandardButtons.Ok,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				window,
				controls);
		}

		public static void Alert(string instructionText = null,
			string text = null,
			string caption = null,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = false,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = false,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			Show(instructionText,
				text,
				caption,
				TaskDialogStandardIcon.Warning,
				TaskDialogStandardButtons.Ok,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				window,
				controls);
		}

		public static TaskDialogResult AskWithWarn(string instructionText = null,
			string text = null,
			string caption = null,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = false,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = false,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			return Show(instructionText,
				text,
				caption,
				TaskDialogStandardIcon.Warning,
				TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				window,
				controls);
		}

		public static TaskDialogResult Ask(string instructionText = null,
			string text = null,
			string caption = null,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = false,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = false,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			return Show(instructionText,
				text,
				caption,
				TaskDialogStandardIcon.Information,
				TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				window,
				controls);
		}

		public static void Error(string instructionText = null,
			string text = null,
			string caption = null,
			string detailsExpandedLabel = null,
			string detailsExpandedText = null,
			bool cancelable = false,
			string detailsCollapsedLabel = null,
			bool detailsExpanded = false,
			bool? footerCheckBoxChecked = false,
			string footerCheckBoxText = null,
			TaskDialogStandardIcon footerIcon = TaskDialogStandardIcon.None,
			string footerText = null,
			bool hyperlinksEnabled = true,
			TaskDialogStartupLocation startupLocation = TaskDialogStartupLocation.CenterOwner,
			TaskDialogProgressBarState progressBarState = TaskDialogProgressBarState.None,
			int progressbarMinValue = 0,
			int progressbarMaxValue = 0,
			int? progressbarCurrValue = null,
			Action<TaskDialog> action = null,
			Window window = null,
			params TaskDialogControl[] controls)
		{
			Show(instructionText,
				text,
				caption,
				TaskDialogStandardIcon.Error,
				TaskDialogStandardButtons.Ok,
				detailsExpandedLabel,
				detailsExpandedText,
				cancelable,
				detailsCollapsedLabel,
				detailsExpanded,
				footerCheckBoxChecked,
				footerCheckBoxText,
				footerIcon,
				footerText,
				hyperlinksEnabled,
				startupLocation,
				progressBarState,
				progressbarMinValue,
				progressbarMaxValue,
				progressbarCurrValue,
				action,
				window,
				controls);
		}
	}
}