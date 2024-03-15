using StorageSystem.Model;
using System.Collections.Generic;

namespace StorageSystem.ViewModel
{
    public static class Directories
    {
        public static List<DocumentType> DocumentTypes = new List<DocumentType>();
        public static List<DocumentStatus> DocumentStatuses = new List<DocumentStatus>();
        public static List<DocumentView> DocumentViews = new List<DocumentView>();
        public static List<WarehousehSortInfo> WarehousehSortInfos = new List<WarehousehSortInfo>();

        public static void SetwarehousehSortInfo(List<WarehousehSortInfo> warehousehSortInfos)
            => WarehousehSortInfos = warehousehSortInfos;
        public static void SetDocumentView(List<DocumentView> documentViews)
            => DocumentViews = documentViews;
        public static void SetDocumentType(List<DocumentType> documentTypes)
            => DocumentTypes = documentTypes;
        public static void SetDocumentStatus(List<DocumentStatus> documentStatuses)
            => DocumentStatuses = documentStatuses;
    }
}