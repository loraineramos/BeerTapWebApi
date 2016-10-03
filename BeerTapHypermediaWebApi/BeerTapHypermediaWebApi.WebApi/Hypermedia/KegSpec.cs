using System.Collections.Generic;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<Keg, KegState, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("KegOffices({kegOfficeId})/Kegs({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Keg; }
        }


        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId, c => c.KegId);
        }

        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                    {
                        CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.GoingDown)
            {
                Links =
                    {
                        CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegOfficeId, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.AlmostEmpty)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.ReplaceKegs.PourKeg, ReplaceKegSpec.ReplaceKegUri, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.Dry)
            {
                Links =
                    {
                        CreateLinkTemplate(LinkRelations.ReplaceKegs.PourKeg, ReplaceKegSpec.ReplaceKegUri, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {

                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
        }
    }

}
