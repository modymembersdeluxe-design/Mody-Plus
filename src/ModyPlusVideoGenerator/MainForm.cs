using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModyPlusVideoGenerator;

public sealed class MainForm : Form
{
    private readonly ListBox _sourceList;
    private readonly CheckedListBox _styleList;
    private readonly CheckedListBox _remixList;
    private readonly CheckedListBox _outputList;
    private readonly TextBox _notesBox;

    public MainForm()
    {
        Text = "Mody+ Video Generator";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(960, 640);

        var rootLayout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 2,
            RowCount = 3,
            Padding = new Padding(16),
        };
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55));
        rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        rootLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        var header = new Label
        {
            Text = "Mody+ Remix Planner",
            Dock = DockStyle.Fill,
            Font = new Font(Font.FontFamily, 18, FontStyle.Bold),
        };
        rootLayout.Controls.Add(header, 0, 0);
        rootLayout.SetColumnSpan(header, 2);

        var leftPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 3,
        };
        leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
        leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30));
        leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25));

        _sourceList = new ListBox { Dock = DockStyle.Fill };
        _sourceList.Items.AddRange(new object[]
        {
            "Mody+ Channel Clips",
            "Vocal Hooks",
            "Signature Effects",
            "Callouts & Stingers",
        });

        _styleList = new CheckedListBox { Dock = DockStyle.Fill };
        _styleList.Items.AddRange(new object[]
        {
            "YTP (1990s VHS Glitch)",
            "YTP (2000s Flash Remix)",
            "YTPMV (2010s EDM Cut)",
            "YTP (2020s Hyper-edit)",
        });

        _remixList = new CheckedListBox { Dock = DockStyle.Fill };
        _remixList.Items.AddRange(new object[]
        {
            "Relax Loop",
            "Random Chop",
            "Speed Ramp",
            "Music Video",
            "Chaos Stack",
        });

        leftPanel.Controls.Add(BuildGroup("Source Material", _sourceList), 0, 0);
        leftPanel.Controls.Add(BuildGroup("YTP Styles", _styleList), 0, 1);
        leftPanel.Controls.Add(BuildGroup("Remix Flavors", _remixList), 0, 2);

        var rightPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 1,
            RowCount = 2,
        };
        rightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
        rightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 45));

        _outputList = new CheckedListBox { Dock = DockStyle.Fill };
        _outputList.Items.AddRange(new object[]
        {
            "Mody+ Only Render",
            "GitHub Release Bundle",
            "Sony Vegas Project",
            "3D Element Pass",
        });

        _notesBox = new TextBox
        {
            Dock = DockStyle.Fill,
            Multiline = true,
            ScrollBars = ScrollBars.Vertical,
            PlaceholderText = "Notes: transitions, memes, 3D inserts, audio cues...",
        };

        rightPanel.Controls.Add(BuildGroup("Outputs", _outputList), 0, 0);
        rightPanel.Controls.Add(BuildGroup("Session Notes", _notesBox), 0, 1);

        rootLayout.Controls.Add(leftPanel, 0, 1);
        rootLayout.Controls.Add(rightPanel, 1, 1);

        var buttonRow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            AutoSize = true,
        };

        var exportButton = new Button
        {
            Text = "Export Plan",
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6),
        };
        exportButton.Click += ExportButtonOnClick;

        var resetButton = new Button
        {
            Text = "Reset",
            AutoSize = true,
            Padding = new Padding(12, 6, 12, 6),
        };
        resetButton.Click += (_, _) => ResetSelections();

        buttonRow.Controls.Add(exportButton);
        buttonRow.Controls.Add(resetButton);

        rootLayout.Controls.Add(buttonRow, 0, 2);
        rootLayout.SetColumnSpan(buttonRow, 2);

        Controls.Add(rootLayout);
    }

    private static GroupBox BuildGroup(string title, Control inner)
    {
        var group = new GroupBox
        {
            Text = title,
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
        };
        inner.Dock = DockStyle.Fill;
        group.Controls.Add(inner);
        return group;
    }

    private void ResetSelections()
    {
        _styleList.ClearSelected();
        _remixList.ClearSelected();
        _outputList.ClearSelected();
        _notesBox.Clear();
        for (var i = 0; i < _styleList.Items.Count; i++)
        {
            _styleList.SetItemChecked(i, false);
        }
        for (var i = 0; i < _remixList.Items.Count; i++)
        {
            _remixList.SetItemChecked(i, false);
        }
        for (var i = 0; i < _outputList.Items.Count; i++)
        {
            _outputList.SetItemChecked(i, false);
        }
    }

    private void ExportButtonOnClick(object? sender, EventArgs e)
    {
        var selectionSummary = $"""
            Source Items: {string.Join(", ", _sourceList.SelectedItems.Cast<object>())}
            Styles: {string.Join(", ", _styleList.CheckedItems.Cast<object>())}
            Remix: {string.Join(", ", _remixList.CheckedItems.Cast<object>())}
            Outputs: {string.Join(", ", _outputList.CheckedItems.Cast<object>())}
            Notes: {_notesBox.Text.Trim()}
            """;

        MessageBox.Show(selectionSummary,
            "Export Plan",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
