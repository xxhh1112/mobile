using Bit.App.Utilities;
using Bit.iOS.Core.Renderers;
using UIKit;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Graphics;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace Bit.iOS.Core.Renderers
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private bool _noSelectionStyle = false;

        public CustomViewCellRenderer()
        {
            _noSelectionStyle = ThemeManager.GetResourceColor("BackgroundColor") != Colors.White;
        }

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            if (_noSelectionStyle)
            {
                cell.SelectionStyle = UITableViewCellSelectionStyle.None;
            }
            return cell;
        }
    }
}
