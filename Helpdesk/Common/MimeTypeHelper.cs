namespace Helpdesk.Common
{
    public static class MimeTypeHelper
    {
        private static readonly Dictionary<string, string> MimeTypes = new()
    {
        { ".txt",  "text/plain" },
        { ".pdf",  "application/pdf" },
        { ".doc",  "application/msword" },
        { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { ".xls",  "application/vnd.ms-excel" },
        { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
        { ".jpg",  "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".png",  "image/png" },
        { ".gif",  "image/gif" },
        { ".zip",  "application/zip" },
        { ".rar",  "application/vnd.rar" },
        { ".7z",   "application/x-7z-compressed" },
        { ".csv",  "text/csv" },
        { ".xml",  "application/xml" },
        { ".json", "application/json" },
    };

        public static string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName)?.ToLowerInvariant();

            if (!string.IsNullOrEmpty(extension) && MimeTypes.TryGetValue(extension, out var mimeType))
            {
                return mimeType;
            }

            return "application/octet-stream"; // По подразбиране
        }
    }

}
