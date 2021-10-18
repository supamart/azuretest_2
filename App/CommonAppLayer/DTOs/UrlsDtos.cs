using System.Collections.Generic;

namespace azuretest_2.App.CommonAppLayer.DTOs
{
    public class UrlsDtos
    {
        public ICollection<string> Urls { get; }
        public UrlsDtos(ICollection<string> urls)
        {
            Urls = urls;
        }
    }
}