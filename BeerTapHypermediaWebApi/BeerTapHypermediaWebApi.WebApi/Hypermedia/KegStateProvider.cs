using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.WebApi.Hypermedia
{
    public class KegStateProvider : KegStateProvider<Keg>
    {
    }

    public abstract class KegStateProvider<TKegResource> : ResourceStateProviderBase<TKegResource, KegState>
where TKegResource : IStatefulResource<KegState>, IStatefulKeg
    {
        public override KegState GetFor(TKegResource resource)
        {
            return resource.KegState;
        }

        protected override IDictionary<KegState, IEnumerable<KegState>> GetTransitions()
        {
            return new Dictionary<KegState, IEnumerable<KegState>>
            {
                // from, to
                {
                    KegState.New, new[]
                    {
                        KegState.Dry
                    }

                },
                {
                    KegState.GoingDown, new[]
                    {
                        KegState.New
                    }

                },
                {
                    KegState.AlmostEmpty, new[]
                    {
                        KegState.New
                    }

                },
                {
                    KegState.Dry, new[]
                    {
                        KegState.New
                    }

                }
            };
        }

        public override IEnumerable<KegState> All
        {
            get { return EnumEx.GetValuesFor<KegState>(); }
        }
    }
}