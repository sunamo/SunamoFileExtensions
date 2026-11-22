namespace SunamoFileExtensions.Tests;

/// <summary>
/// Tests for AllExtensionsHelper.BasicImageExtensions.
/// </summary>
public class BasicImageExtensionsTests
{
    /// <summary>
    /// Tests that the list of basic image extensions contains gif and webp next to the older formats.
    /// </summary>
    [Fact]
    public void BasicImageExtensions_ContainsAllCommonFormats()
    {
        Assert.Equal(new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" }, AllExtensionsHelper.BasicImageExtensions);
        Assert.Contains(".gif", AllExtensionsHelper.BasicImageExtensions);
        Assert.Contains(".webp", AllExtensionsHelper.BasicImageExtensions);
        Assert.DoesNotContain(".html", AllExtensionsHelper.BasicImageExtensions);
    }
}
