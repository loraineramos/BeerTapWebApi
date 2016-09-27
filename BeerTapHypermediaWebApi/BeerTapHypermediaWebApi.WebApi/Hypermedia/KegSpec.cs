using System.Collections.Generic;
using BeerTapHypermediaWebApi.Model;
using BeerTapHypermediaWebApi.Model.Enum;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class KegSpec : ResourceSpec<Keg, KegState, int>
    //SingleStateResourceSpec<Keg, int>
    {

        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Kegs({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Keg; }
        }


        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegId);
        }

        protected override IEnumerable<IResourceStateSpec<Keg, KegState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.New)
            {
                Links =
                    {
                        CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };

            yield return new ResourceStateSpec<Keg, KegState, int>(KegState.GoingDown)
            {
                Links =
                    {
                        CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.KegId)
                    },
                Operations = new StateSpecOperationsSource<Keg, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create,
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
                    InitialPost = ServiceOperations.Create,
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
                    InitialPost = ServiceOperations.Create,
                    Post = ServiceOperations.Update,
                    Delete = ServiceOperations.Delete,
                }
            };
        }
    }

}
