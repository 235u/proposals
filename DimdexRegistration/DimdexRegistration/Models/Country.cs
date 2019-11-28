using System.Collections.Generic;

namespace DimdexRegistration.Models
{
    public static class Country
    {
        // See: https://en.wikipedia.org/wiki/List_of_sovereign_states
        public const string Afghanistan = nameof(Afghanistan);
        public const string Albania = nameof(Albania);
        public const string Algeria = nameof(Algeria);
        public const string Andorra = nameof(Andorra);
        public const string Angola = nameof(Angola);
        public const string AntiguaAndBarbuda = "Antigua and Barbuda";
        public const string Argentina = nameof(Argentina);
        public const string Armenia = nameof(Armenia);
        public const string Australia = nameof(Australia);
        public const string Austria = nameof(Austria);
        public const string Azerbaijan = nameof(Azerbaijan);
        public const string Bahamas = nameof(Bahamas);
        public const string Bahrain = nameof(Bahrain);
        public const string Bangladesh = nameof(Bangladesh);
        public const string Barbados = nameof(Barbados);
        public const string Belarus = nameof(Belarus);
        public const string Belgium = nameof(Belgium);
        public const string Belize = nameof(Belize);
        public const string Benin = nameof(Benin);
        public const string Bhutan = nameof(Bhutan);
        public const string Bolivia = nameof(Bolivia);
        public const string BosniaAndHerzegovina = "Bosnia and Herzegovina";
        public const string Botswana = nameof(Botswana);
        public const string Brazil = nameof(Brazil);
        public const string Brunei = nameof(Brunei);
        public const string Bulgaria = nameof(Bulgaria);
        public const string BurkinaFaso = "Burkina Faso";
        public const string Burundi = nameof(Burundi);
        public const string Cambodia = nameof(Cambodia);
        public const string Cameroon = nameof(Cameroon);
        public const string Canada = nameof(Canada);
        public const string CapeVerde = "Cape Verde";
        public const string CentralAfricanRepublic = "Central African Republic";
        public const string Chad = nameof(Chad);
        public const string Chile = nameof(Chile);
        public const string China = nameof(China);
        public const string Colombia = nameof(Colombia);
        public const string Comoros = nameof(Comoros);
        public const string Congo = "Congo, Republic of the";
        public const string CongoDemocraticRepublic = "Congo, Democratic Republic of the";        
        public const string CostaRica = "Costa Rica";
        public const string Croatia = nameof(Croatia);
        public const string Cuba = nameof(Cuba);
        public const string Cyprus = nameof(Cyprus);
        public const string CzechRepublic = "Czech Republic";

        public static readonly List<string> Names = new List<string>()
        {
            Afghanistan,
            Albania,
            Algeria,
            Andorra,
            Angola,
            AntiguaAndBarbuda,
            Argentina,
            Armenia,
            Australia,
            Austria,
            Azerbaijan,
            Bahamas,
            Bahrain,
            Bangladesh,
            Barbados,
            Belarus,
            Belgium,
            Belize,
            Benin,
            Bhutan,
            Bolivia,
            BosniaAndHerzegovina,
            Botswana,
            Brazil,
            Brunei,
            Bulgaria,
            BurkinaFaso,
            Burundi,
            Cambodia,
            Cameroon,
            Canada,
            CapeVerde,
            CentralAfricanRepublic,
            Chad,
            Chile,
            China,
            Colombia,
            Comoros,
            Congo,
            CongoDemocraticRepublic,            
            CostaRica,
            Croatia,
            Cuba,
            Cyprus,
            CzechRepublic
        };

        // See: https://en.wikipedia.org/wiki/List_of_country_calling_codes
        public static readonly Dictionary<string, string> CallingCodes = new Dictionary<string, string>()
        {
            [Afghanistan] = "+93",
            [Albania] = "+355",
            [Algeria] = "+213",
            [Andorra] = "+376",
            [Angola] = "+244",
            [AntiguaAndBarbuda] = "+1",
            [Argentina] = "+54",
            [Armenia] = "+374",
            [Australia] = "+61",
            [Austria] = "+43",
            [Azerbaijan] = "+994",
            [Bahamas] = "+1",
            [Bahrain] = "+973",
            [Bangladesh] = "+880",
            [Barbados] = "+1",
            [Belarus] = "+375",
            [Belgium] = "+32",
            [Belize] = "+501",
            [Benin] = "+229",
            [Bhutan] = "+975",
            [Bolivia] = "+591",
            [BosniaAndHerzegovina] = "+387",
            [Botswana] = "+267",
            [Brazil] = "+55",
            [Brunei] = "+673",
            [Bulgaria] = "+359",
            [BurkinaFaso] = "+226",
            [Burundi] = "+257",
            [Cambodia] = "+855",
            [Cameroon] = "+237",
            [Canada] = "+1",
            [CapeVerde] = "+238",
            [CentralAfricanRepublic] = "+236",
            [Chad] = "+235",
            [Chile] = "+56",
            [China] = "+86",
            [Colombia] = "+57",
            [Comoros] = "+269",
            [Congo] = "+242",
            [CongoDemocraticRepublic] = "+243",            
            [CostaRica] = "+506",
            [Croatia] = "+385",
            [Cuba] = "+53",
            [Cyprus] = "+357",
            [CzechRepublic] = "+420"
        };
    }
}
