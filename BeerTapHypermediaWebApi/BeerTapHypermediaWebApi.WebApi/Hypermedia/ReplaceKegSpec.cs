using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.CacheControl;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using IQ.Platform.Framework.WebApi.Rpc;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class ReplaceKegSpec : SingleStateResourceSpec<ReplaceKeg, int>
    {

        public static ResourceUriTemplate ReplaceKegUri = ResourceUriTemplate.Create("ReplaceKegs({id})");


        protected override IEnumerable<ResourceLinkTemplate<ReplaceKeg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, ReplaceKegUri, c => c.KegId);
        }

        public override IResourceStateSpec<ReplaceKeg, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<ReplaceKeg, int>
                    {
                        Links =
                        {
                            //CreateLinkTemplate(CommonLinkRelations.Self, ReplaceKegUri, c => c.KegId)
            },
                        Operations = new StateSpecOperationsSource<ReplaceKeg, int>
                        {
                            Get = ServiceOperations.Get,
                            InitialPost = ServiceOperations.Create,
                            Post = ServiceOperations.Update,
                            Delete = ServiceOperations.Delete,
                        }
                    };
            }
        }
    }
}