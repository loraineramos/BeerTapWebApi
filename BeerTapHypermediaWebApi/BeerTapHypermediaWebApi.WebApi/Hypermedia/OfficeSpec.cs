using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");


        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId);
        }

        public override IResourceStateSpec<Office, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<Office, int>
                  {
                      Links =
                      {
                           //CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId),
                      },
                      Operations = new StateSpecOperationsSource<Office, int>
                      {
                          Get = ServiceOperations.Get,
                          InitialPost = ServiceOperations.Create,
                          Post = ServiceOperations.Update,
                          Delete = ServiceOperations.Delete,
                      },
                  };
            }
        }

    }
}