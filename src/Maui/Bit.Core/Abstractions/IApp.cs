using Bit.App.Models;

namespace Bit.Core.Abstractions
{
    public interface IApp
    {
        AppOptions Options { get; }

        Task<string> DisplayActionSheetAsync(string title, string cancel, string destruction, params string[] buttons);
    }
}
