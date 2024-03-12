using StorageSystem.Model;
using System.Collections.Generic;

namespace StorageSystem.ViewModel
{
    public static class Directorys
    {
        public static List<DocumentType> DocumentTypes = new List<DocumentType>();
        public static List<DocumentStatus> DocumentStatuses = new List<DocumentStatus>();
        public static void SetDocumentType(List<DocumentType> documentTypes)
            => DocumentTypes = documentTypes;
        public static void SetDocumentStatus(List<DocumentStatus> documentStatuses)
            => DocumentStatuses = documentStatuses;
    }
}