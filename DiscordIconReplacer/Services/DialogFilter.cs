using System;

namespace DiscordIconReplacer.Services;

internal static class DialogFilter
{
    public static string Build(string fileType, string extension)
    {
        if (string.IsNullOrWhiteSpace(fileType))
            throw new ArgumentException("File type must not be empty.", nameof(fileType));

        if (string.IsNullOrWhiteSpace(extension))
            throw new ArgumentException("Extension must not be empty.", nameof(extension));

        return $"{fileType} (*.{extension})|*.{extension}";
    }
}