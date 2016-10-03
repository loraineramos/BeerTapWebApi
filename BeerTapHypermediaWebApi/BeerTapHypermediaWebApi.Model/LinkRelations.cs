namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string Keg = "iq:Keg";
        /// <summary>
        /// link relation to keg office
        /// </summary>
	    public const string Office = "iq:Office";

        /// <summary>
        /// 
        /// </summary>
        public static class ReplaceKegs
        {
            /// <summary>
            /// link relation to replace keg
            /// </summary>
            public const string PourKeg = "iq:PourKeg";

        }

    }
}
