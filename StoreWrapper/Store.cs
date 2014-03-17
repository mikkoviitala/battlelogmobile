using System;
using System.Collections.Generic;
using StoreLauncher;
using Windows.ApplicationModel.Store;
using Windows.Foundation;

namespace StoreWrapper
{
    public class Store : StoreBase
    {
        public override IAsyncOperationBase<ListingInformationBase> LoadListingInformationAsync()
        {
            return new ApolloIAsyncOperation<ListingInformationBase, ListingInformation>(CurrentApp.LoadListingInformationAsync(),
                (r) =>
                {
                    r.Result = new ApolloListingInformation(r.ConvertFrom);
                });
        }

        public override IAsyncOperationBase<string> RequestProductPurchaseAsync(string productId, bool includeReceipt)
        {
            return new ApolloIAsyncOperation<string, string>(CurrentApp.RequestProductPurchaseAsync(productId, includeReceipt),
                (r) =>
                {
                    r.Result = r.ConvertFrom;
                });
        }

        public override void ReportProductFulfillment(string productId)
        {
            CurrentApp.ReportProductFulfillment(productId);
        }

        public override LicenseInformationBase LicenseInformation
        {
            get
            {
                return new ApolloLicenseInformation(CurrentApp.LicenseInformation);
            }
        }

        public override Guid AppId
        {
            get { return CurrentApp.AppId; }
        }
    }

    public class ApolloIAsyncOperationConvertResult<T, Y>
    {
        public Y ConvertFrom { get; set; }

        public T Result { get; set; }
    }

    public class ApolloIAsyncOperation<T, Y> : IAsyncOperationBase<T>
    {
        private IAsyncOperation<Y> _result;
        private Action<ApolloIAsyncOperationConvertResult<T, Y>> _converter;

        public ApolloIAsyncOperation(IAsyncOperation<Y> result, Action<ApolloIAsyncOperationConvertResult<T, Y>> converter)
        {
            _result = result;
            _converter = converter;
        }

        public override T GetResults()
        {
            var convertFrom = _result.GetResults();

            var convertResult = new ApolloIAsyncOperationConvertResult<T, Y>() { ConvertFrom = convertFrom };
            _converter(convertResult);

            return convertResult.Result;
        }

        public override Action<IAsyncOperationBase<T>, StoreAsyncStatus> Completed
        {
            set
            {
                if (value != null)
                {
                    _result.Completed = (o, s) =>
                    {
                        value(this, (StoreAsyncStatus)s);
                    };
                }
            }
        }
    }

    public class ApolloLicenseInformation : LicenseInformationBase
    {
        private LicenseInformation _licenseInformation;

        public ApolloLicenseInformation(LicenseInformation licenseInformation)
        {
            _licenseInformation = licenseInformation;
        }

        public override Dictionary<string, ProductLicenseBase> ProductLicenses
        {
            get
            {
                var productLicenses = new Dictionary<string, ProductLicenseBase>();

                foreach (var kvp in _licenseInformation.ProductLicenses)
                {
                    productLicenses.Add(kvp.Key, new ApolloProductLicense(kvp.Value));
                }

                return productLicenses;
            }
        }
    }

    public class ApolloListingInformation : ListingInformationBase
    {
        private ListingInformation _listingInformation;

        public ApolloListingInformation(ListingInformation listingInformation)
        {
            _listingInformation = listingInformation;
        }

        public override Dictionary<string, ProductListingBase> ProductListings
        {
            get
            {
                var productListings = new Dictionary<string, ProductListingBase>();

                foreach (var kvp in _listingInformation.ProductListings)
                {
                    productListings.Add(kvp.Key, new ApolloProductListing(kvp.Value));
                }

                return productListings;
            }
        }
    }

    public class ApolloProductLicense : ProductLicenseBase
    {
        private ProductLicense _productLicense;

        public ApolloProductLicense(ProductLicense productLicense)
        {
            _productLicense = productLicense;
        }

        public override bool IsConsumable
        {
            get
            {
                return _productLicense.IsConsumable;
            }
            set
            {

            }
        }

        public override bool IsActive
        {
            get
            {
                return _productLicense.IsActive;
            }
            set
            {

            }
        }

        public override string ProductId
        {
            get
            {
                return _productLicense.ProductId;
            }
            set
            {

            }
        }
    }

    public class ApolloProductListing : ProductListingBase
    {
        private ProductListing _productListing;

        public ApolloProductListing(ProductListing productListing)
        {
            _productListing = productListing;
        }

        public override string FormattedPrice
        {
            get
            {
                return _productListing.FormattedPrice;
            }
            set
            {

            }
        }

        public override string Name
        {
            get
            {
                return _productListing.Name;
            }
            set
            {

            }
        }

        public override string Description
        {
            get
            {
                return _productListing.Description;
            }
            set
            {

            }
        }

        public override List<string> Keywords
        {
            get
            {
                return new List<string>(_productListing.Keywords);
            }
            set
            {

            }
        }

        public override string ProductId
        {
            get
            {
                return _productListing.ProductId;
            }
            set
            {

            }
        }

        public override StoreProductType ProductType
        {
            get
            {
                return (StoreProductType)_productListing.ProductType;
            }
            set
            {

            }
        }

        public override string Tag
        {
            get
            {
                return _productListing.Tag;
            }
            set
            {

            }
        }

        public override Uri ImageUri
        {
            get
            {
                return _productListing.ImageUri;
            }
            set
            {

            }
        }
    }
}
