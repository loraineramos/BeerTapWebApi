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
    public class KegsAndKegOfficesSpec : SingleStateResourceSpec<KegAndKegOffice, int>
    {
        public static ResourceUriTemplate UriKegAtOffice = ResourceUriTemplate.Create("KegOffices({kegOfficeId})/Kegs({kegId})");

        protected override IEnumerable<ResourceLinkTemplate<KegAndKegOffice>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, UriKegAtOffice, c => c.Keg.KegOfficeId, c => c.Keg.KegId);
        }
        public override IResourceStateSpec<KegAndKegOffice, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<KegAndKegOffice, int>
                  {
                      Links =
                      {
                           //CreateLinkTemplate(LinkRelations.Keg ,KegSpec.Uri , r=> r.KegOfficeId),
                      },
                      Operations = new StateSpecOperationsSource<KegAndKegOffice, int>
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