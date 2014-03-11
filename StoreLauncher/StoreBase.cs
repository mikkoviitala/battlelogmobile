using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreLauncher
{
    public abstract class StoreBase
    {
        public StoreBase()
        {

        }

        public abstract IAsyncOperationBase<ListingInformationBase> LoadListingInformationAsync();

        public abstract IAsyncOperationBase<string> RequestProductPurchaseAsync(string productId, bool includeReceipt);

        public abstract void ReportProductFulfillment(string productId);

        public abstract LicenseInformationBase LicenseInformation { get; }

        public abstract Guid AppId { get; }
    }

    public abstract class LicenseInformationBase
    {
        public abstract Dictionary<string, ProductLicenseBase> ProductLicenses { get; }
    }

    public abstract class IAsyncOperationBase<T>
    {
        public abstract T GetResults();

        public abstract Action<IAsyncOperationBase<T>, StoreAsyncStatus> Completed { set; }
    }

    public abstract class ListingInformationBase
    {
        public abstract Dictionary<string, ProductListingBase> ProductListings { get; }
    }

    public abstract class ProductLicenseBase
    {
        public abstract bool IsConsumable { get; set; }
        public abstract bool IsActive { get; set; }
        public abstract string ProductId { get; set; }
    }

    public abstract class ProductListingBase
    {
        public abstract string FormattedPrice { get; set; }
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public abstract List<string> Keywords { get; set; }
        public abstract string ProductId { get; set; }
        public abstract StoreProductType ProductType { get; set; }
        public abstract string Tag { get; set; }
        public abstract Uri ImageUri { get; set; }
    }

    public enum StoreAsyncStatus
    {
        // Summary:
        //     The operation has started.
        Started = 0,
        //
        // Summary:
        //     The operation has completed.
        Completed = 1,
        //
        // Summary:
        //     The operation was canceled.
        Canceled = 2,
        //
        // Summary:
        //     The operation has encountered an error.
        Error = 3,
    }

    public enum StoreProductType
    {
        // Summary:
        //     The product type is unknown.
        Unknown = 0,
        //
        // Summary:
        //     A durable product.
        Durable = 1,
        //
        // Summary:
        //     A consumable product.
        Consumable = 2,
    }
}
