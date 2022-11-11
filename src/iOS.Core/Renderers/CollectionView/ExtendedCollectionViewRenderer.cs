using Bit.App.Controls;
using Bit.iOS.Core.Renderers.CollectionView;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Platform;

[assembly: ExportRenderer(typeof(ExtendedCollectionView), typeof(ExtendedCollectionViewRenderer))]
namespace Bit.iOS.Core.Renderers.CollectionView
{
    //TODO [MAUI-Migration] [Critical] https://github.com/dotnet/maui/wiki/Using-Custom-Renderers-in-.NET-MAUI
    public class ExtendedCollectionViewRenderer : GroupableItemsViewRenderer<ExtendedCollectionView, GroupableItemsViewController<ExtendedCollectionView>>
    {
        protected override GroupableItemsViewController<ExtendedCollectionView> CreateController(ExtendedCollectionView itemsView, ItemsViewLayout layout)
        {
            return new ExtendedGroupableItemsViewController<ExtendedCollectionView>(itemsView, layout);
        }
    }
}
