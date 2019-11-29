using System.Collections.Generic;

namespace DimdexRegistration.Models
{
    public static class Country
    {
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
        public const string Denmark = nameof(Denmark);
        public const string Djibouti = nameof(Djibouti);
        public const string Dominica = nameof(Dominica);
        public const string DominicanRepublic = "Dominican Republic";
        public const string EastTimor = "East Timor";
        public const string Equador = nameof(Equador);
        public const string Egypt = nameof(Egypt);
        public const string ElSalvador = "El Salvador";
        public const string EquatorialGuinea = "Equatorial Guinea";
        public const string Eritrea = nameof(Eritrea);
        public const string Estonia = nameof(Estonia);
        public const string Eswatini = nameof(Eswatini);
        public const string Ethiopia = nameof(Ethiopia);
        public const string Fiji = nameof(Fiji);
        public const string Finland = nameof(Finland);
        public const string France = nameof(France);
        public const string Gabon = nameof(Gabon);
        public const string Gambia = nameof(Gambia);
        public const string Georgia = nameof(Georgia);
        public const string Germany = nameof(Germany);
        public const string Ghana = nameof(Ghana);
        public const string Greece = nameof(Greece);
        public const string Grenada = nameof(Grenada);
        public const string Guatemala = nameof(Guatemala);
        public const string Guinea = nameof(Guinea);
        public const string GuineaBissau = "Guinea-Bissau";
        public const string Guyana = nameof(Guyana);
        public const string Haiti = nameof(Haiti);
        public const string Honduras = nameof(Honduras);
        public const string Hungary = nameof(Hungary);
        public const string Iceland = nameof(Iceland);
        public const string India = nameof(India);
        public const string Indonesia = nameof(Indonesia);
        public const string Iran = nameof(Iran);
        public const string Iraq = nameof(Iraq);
        public const string Ireland = nameof(Ireland);
        public const string Israel = nameof(Israel);
        public const string Italy = nameof(Italy);
        public const string IvoryCoast = nameof(IvoryCoast);

        /// <summary>
        /// Represents the sovereign states around the world. This field is read-only.
        /// </summary>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_sovereign_states">List of sovereign states - Wikipedia</seealso>
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
            CzechRepublic,
            Denmark,
            Djibouti,
            Dominica,
            DominicanRepublic,
            EastTimor,
            Egypt,
            ElSalvador,
            Equador,
            EquatorialGuinea,
            Eritrea,
            Estonia,
            Eswatini,
            Ethiopia,
            Fiji,
            Finland,
            France,
            Gabon,
            Gambia,
            Georgia,
            Germany,
            Ghana,
            Greece,
            Grenada,
            Guatemala,
            Guinea,
            GuineaBissau,
            Guyana,
            Haiti,
            Honduras,
            Hungary,
            Iceland,
            India,
            Indonesia,
            Iran,
            Iraq,
            Ireland,
            Israel,
            Italy,
            IvoryCoast
        };

        /// <summary>
        /// Represents the country dial-in codes as telephone number prefixes. This field is read-only.
        /// </summary>
        /// <seealso href="https://en.wikipedia.org/wiki/List_of_country_calling_codes">List of country calling codes -
        /// Wikipedia</seealso>
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
            [CzechRepublic] = "+420",
            [Denmark] = "+45",
            [Djibouti] = "+253",
            [Dominica] = "+1",
            [DominicanRepublic] = "+1",
            [EastTimor] = "+670",
            [Egypt] = "+20",
            [ElSalvador] = "+503",
            [Equador] = "+593",
            [EquatorialGuinea] = "+240",
            [Eritrea] = "+291",
            [Estonia] = "+372",
            [Eswatini] = "+268",
            [Ethiopia] = "+251",
            [Fiji] = "+679",
            [Finland] = "+358",
            [France] = "+33",
            [Gabon] = "+241",
            [Gambia] = "+220",
            [Georgia] = "+995",
            [Germany] = "+49",
            [Ghana] = "+233",
            [Greece] = "+30",
            [Grenada] = "+1",
            [Guatemala] = "+502",
            [Guinea] = "+224",
            [GuineaBissau] = "+245",
            [Guyana] = "+592",
            [Haiti] = "+509",
            [Honduras] = "+504",
            [Hungary] = "+36",
            [Iceland] = "+354",
            [India] = "+91",
            [Indonesia] = "+62",
            [Iran] = "+98",
            [Iraq] = "+964",
            [Ireland] = "+353",
            [Israel] = "+972",
            [Italy] = "+39",
            [IvoryCoast] = "+225"
        };
    }
}
