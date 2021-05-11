using System.Collections.Generic;

namespace RestAspNet5.Hypermedia.Abstract
{
    public interface ISupportHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}
