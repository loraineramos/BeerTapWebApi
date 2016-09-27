using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapHypermediaWebApi.Model;
using BeerTapHypermediaWebApi.Model.Enum;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class KegOfficeSpec : SingleStateResourceSpec<KegOffice, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("KegOffices({id})");
        public static ResourceUriTemplate UriKegAtOffice = ResourceUriTemplate.Create("KegOffices({id})/Kegs({kegId})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.KegOffice; }
        }
        protected override IEnumerable<ResourceLinkTemplate<KegOffice>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId);
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriKegAtOffice, c => c.KegOfficeId, c => c.Id);
        }
        public override IResourceStateSpec<KegOffice, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<KegOffice, int>
                  {
                      Links =
                      {
                           CreateLinkTemplate(LinkRelations.Keg ,KegSpec.Uri , r=> r.KegOfficeId),
                      },
                      Operations = new StateSpecOperationsSource<KegOffice, int>
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