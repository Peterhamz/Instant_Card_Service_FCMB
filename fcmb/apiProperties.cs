using System; 
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fcmb
{
    public class apiProperties
    {
        public string countryRes { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string dob { get; set; }
        public string bvn { get; set; }
        public string data { get; set; }
    }

    public class countries
    {
        public string[] count = { "Nigeria", "United Kingdom", "United States of America (U.S.A.)", "", "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cabo Verde", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "DR Congo", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Curacao", "Cyprus", "Czechia", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Holy See", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "North Korea", "Norway", "Oman", "Pakistan", "Palau", "Palestine", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Saint Maarten", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe" };

        public string[] state = { "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Benue", "Borno", "Bayelsa", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Federal Capital Territory", "Gombe", "Imo", "Jigawa", "Kaduna", "Kebbi", "Kogi", "Kano", "Katsina", "Kwara", "Lagos", "Niger", "Nasarawa", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara" };

        public string[] lga = { "ABA", "Aba North", "Aba South", "Abaji", "Abadan", "Abeokuta", "Abeokuta North", "Abeokuta South", "Abi", "Abuja", "Abak", "Abakaliki", "Abohmabaise", "Abua/Odial", "Abuloma", "Adavi", "Ado", "ADO-EKITI", "ADAMAWA", "ADOR", "Ado-Odo/ota", "Afijio", "AFIKPO", "Afikpo North", "Afikpo South", "AGASKI", "AGBARA", "AGEGE", "Agaie", "AGAJE", "AGO IWOYE", "AGWARA", "AGATU", "AGUATA", "AGO-IWOYE", "AHIAZUMBAISE", "AHOADA", "Ahoade East", "Ahoade West", "Aiyedade", "AIJUMU", "AIYEKIRE", "AJAH", "AJINGI", "AJAOKUTA", "AJEROMI/IFELODUN", "AKAMKPA", "AKPABUYO", "AKOKO-EDO", "AKOKO", "Akoko North East", "Akoko North West", "AKoko South East", "AKoko South West", "AKKO", "ANKPA", "AKURE", "Akure North", "AKure South", "AKUTE", "AKUKUTORU", "AKWANGA", "AKINYELE", "ALBASU", "Aleiro", "ALAGBADO", "ALIERO", "Alkaleri", "ALIMOSHO", "AMUWO ODOFIN", "ANAOCHA", "Anambra East", "Anambra West", "ANDONI/OPOBO", "ANIOCHA", "Aniocha South", "ANKA", "ANINRI", "APA", "APAPA", "ARDO KOLA", "ARGUNGU", "Arochukwu", "AREWA DANDI", "ASA", "ASABA", "ASHAKA", "ASKIRA/UBA", "ASARI TORU", "ATAKUMOSA", "Atakumosa East", "Atakumosa West", "ATIBA", "ATIGBO", "AUGIE", "AUYO", "AWE", "AWKA", "Awka North", "Awka South", "AYAMELUM", "AYEDIRE", "AYEDAADE", "AIYEPE", "BABURA", "BADE", "BAGWAI", "BAKORI", "BALI", "BAMA", "BARUTEN", "BASSA", "BAUCHI", "Baure", "BAYO", "BIDA", "BADAGRY", "BINDAWA", "BEBEJI", "Bende", "BEKWARA", "BENIN CITY", "OBAFEMI/OWODE", "BUNGUDU", "BAGUDO", "BININ GWARI", "BIASE", "BICHI", "BILLIRI", "BINNIWA", "Birni-Gwari", "Biriniwa", "Birni Kudu", "Birni Magaji", "BIU", "BIRNIN KEBBI", "BOKKOS", "Bakura", "BAKASSI", "ABEOKUTA", "BALANGA", "BANGALORE", "BOMADI", "BINJI", "BORNO", "BUNZA", "BODINGA", "Bogoro", "BOKKOS", "Boki", "Boluwaduro", "BONNY", "BORSARI", "BOSUWA", "Brass", "BORGU", "BIRNIN KUDU", "BARAKIN/LADI", "Boripe", "BURUTU", "BOSSO", "BATAGARAWA", "BATSARI", "BUJI", "BUKKUYUM", "BUNKURE", "BURUKU", "Bursari", "Bwari", "CALABAR", "Calabar Muncipality", "Calabar South", "Cassol", "CHANCHAGE", "Central South", "Chanchaga", "CHAFE", "CHIBOK", "Chikun", "CHRANCHI", "CHUKUN", "Dambatta South", "Dandume", "DALA", "DAMBOA", "Dan Musa", "Darazo", "Dange-shnsi", "DAURA", "DAWAKIN KUDU", "DAMBARTA", "DAMATURU", "DEGEMA", "DEKINA", "Demsa", "ODOGBOLU", "DOGUWA", "DIKWA", "DAWKIN TOFA", "damban", "DANMUSA", "DANDI", "DANGE/SHUNTE", "DANJA", "DANUME", "DOKA/KAWO", "DOMA", "DONGA", "DUSTINMA", "DUTSE", "DUJJU", "Dukku", "DUNUKOFIA", "DUTSE", "Dutsin-Ma", "DAWAKIN TOFA", "EASTERN OBOLO", "Ebonyi", "EDATI", "EDE", "Ede North", "Ede South", "EDU", "Etim Ekpo", "EFON", "EGBADO", "Egbado North", "Egbado South", "EGBEDA", "EGOR", "EGBEDORE", "EHIMEMBANO", "EJIGBO", "EKET", "Ekiti South West", "Ekiti East", "Ekiti West", "Ekeremor", "Ekiti", "EKWUSIGO", "ELEME", "EMOHUA", "EMURE/ISE/ORUN", "ENUGU", "Enugu East", "Enugu North", "Enugu South", "EPE", "EPEATANI", "Esit Eket", "ESAN", "Esan Central", "Esan North-East", "Esan South East", "Esan West", "Ese Odo", "ESSIENUDIM", "EAST YAGBA", "ETCHE", "ETHIOPE", "Ethiope East", "Ethiope West", "ETIN EKPO", "Etinan", "ETSAKO", "ETINAM", "ETIOSA", "ETUNG", "EWEKORO", "EZEAGU", "EZINHITE", "Ezinihitte", "EZZA", "Ezza South", "FAGGE", "Fakai", "FASKARI", "FIKA", "FUNAKAYE", "FUNTUA", "Fufore", "FUNE", "GABASAWA", "GADA", "Gagarawa", "Ganjuwa", "Ganaye", "GARKI", "GASHAKA", "Gawabawa", "GAYA", "GBAKO", "GBONGAN", "GBOKO", "Gbonyin", "GEIDAM", "GEZAWA", "Giade", "Gireri", "GIWA", "GUMA", "GUMEL", "Gombi", "GOGARAM", "GOKANA", "GOMBE", "GORONYO", "GARKO", "GARUN MALLAM", "GURARA", "GASSOL", "GUBIO", "GUDU", "GUJBA", "GULANI", "GUMMI", "GURI", "GUSAU", "Guyuk", "GUZAMALA", "GWADA BAWA", "Gwandu", "GWER", "Gwer East", "Gwer West", "GWAGWALADA", "GWIWA", "GWALE", "GWOZA", "GWARAM", "GWARZO", "HADEJIA", "HAWUL", "Hong", "IBAJI", "IBADAN", "Ibadan North", "Ibadan North West", "Ibadan South East", "Ibadan South West", "Ibadan Central", "IBENO", "IBI", "IBEJU LEKKI", "IBOKUN", "IBIONO IBON", "IBARAPA", "Ibarapa Central", "Ibarapa East", "Ibarapa North", "IBESIKPO ASUTAN", "IDARAPO", "IDEATO", "Ideato North", "Ideato South", "IDAH", "IDIMU", "IDEMILI", "Idemili North", "Idemili south", "IDO", "IDANRE", "IDO/OSI", "IFEDORE", "ifedayo", "ILE-IFE", "Ife central", "Ife East", "Ife North", "Ife South", "IFELOJU", "IFAKO/IJAYE", "IFELODUN", "IFO", "IFEDAPO", "IGALAMELA", "IGBABI", "Igbo-Ekiti", "IGBAJO", "Igalamela-Odolu", "IGANMU", "IGBOETITI", "IGUEBEN", "IGBOEZE", "igboeze North", "Igboeze South", "IHIALA", "IHITTE/UBOMA", "IJEBU-ODE", "Ijebu East", "Ijebu North", "Ijebu North East", "ILAJE", "IJEBU-IGBO", "IJERO-EKITI", "Ijumu", "IKARA", "Ika North East", "Ika South", "IKPOBA", "IKORODU", "IKENNE", "IKIRUN", "IKEJA", "IKA", "IKOLE", "IKOM", "IKONO", "IKORODU", "IKOT EKPENE", "IKERE-EKITI", "IKOT ABASI", "IKEDURU", "IKWO", "ikwuano", "IKOYI", "ILA-ORANGUN", "ILESHA", "Ilesha East", "Ilesha West", "Ile Oluji", "ILUGUN ALARO", "ILEJEMEJE", "ILLELA", "ILORIN", "ILORIN", "ilorin East", "ilorin west", "ILORA", "ILISHAN", "IMEKO AFON", "INGAWA", "INI", "IEPODUN", "IPOKIA", "IPERU", "IREPODUN", "IRELE", "IREPO", "ISARA", "ISA", "ISEYIN", "Ise/Orun", "ISHIELU", "ISIALA", "Isiala-Ngwa North", "Isiala-Ngwa south", "ISIN", "ISOKO", "Isoko North", "Isoko South", "isokan", "Isuikwato", "ISOLO", "Isiala mbano", "ISEYIN", "ISARA", "ISU", "ISANYAWA", "ISIUZO", "Itas/Gadau", "ITU", "IVO", "IWAJOWA", "IWO", "IYIGBO", "IYAMAPO/OLORUNDOGO", "JABA", "Jada", "JAHUN", "JAKUSKO", "JALINGO", "Jama`are", "Jibia", "Jega", "JEMAA", "JERE", "JIBIYA", "JALINGO", "JOS", "Jos East", "Jos North", "Jos South", "KABBA", "Kabba/Bunu", "KACHIA", "KADUNA", "Kaduna1", "Kaduna2", "KAFIN HAUSA", "KAGA", "KAIAMA", "KAJOLA", "Kankia", "KALA/BALGE", "KANAM", "KARU", "KATSINA ALA", "Katagum", "KAURA", "Karawa", "KARAYE", "KAZAURE", "KABBA", "KABO", "Kubau", "KIBLYA", "KEANA", "KEBBE", "KEFFI", "KAFUR", "KAUGAMA", "Kaugama Kazaure", "KALTUNGO", "KAGARKO", "KHANA", "Kibiya", "Kirfi", "KIRIKISAMMA", "KIYAWAKIYAWA", "Kajuru", "Koko/Besse", "KANKIYA", "Kalgo", "KUMBOTSO", "KARIMLAMIDO", "KANKE", "KANO", "KNODUGA", "Konduga", "Kogi", "Kontagora", "KOKONA", "Kolokuma/Opokuma", "KONSHISHATSE", "KURA", "KURFI", "KANKARA", "Karin-Lamido", "KAURA-NAMODA", "IKWERRE", "KARASUWA", "KIRU", "KUSADA", "KOSOFE", "KAITA", "KATCHA", "KONTANGORA", "KETU", "KUBAN", "KUDAN", "Kuje", "KUKAWA", "KUNCHI", "KURMI", "KAURU", "KWANDE", "IKWERE", "Kwali", "KWAMI", "KWARE", "KWAYAKUSAR", "KIYAWA", "LAFIA", "LAGOS", "Lagos Island", "Lagos Mainland", "Lamurde", "Langtang North", "Langtang South", "LAPAI", "ILARO", "LAU", "Lavun", "LAWUN", "LERE", "ILESHA", "LAGELU", "Lagelu Ogbomosho", "LOGO", "LOKOJA", "LAGOS", "LANTANG", "OLUYOLE", "MACHINA", "MADAGA", "Madagali", "MAFA", "MAGUMERI", "MAIHA", "MAI ADUWA", "MAKURDI", "MALAMMADURI", "MARADUN", "Mariga", "MASHEGU", "Matazuu", "Maiyama", "MBAITOLU", "MOBBAR", "MBO", "MADOB", "MAIDUGURI", "MAGAMA", "MAIGATARI", "MICHIKA", "MIGA", "MIKANG", "Misau", "MAKODA", "MAKARFI", "MKPATENIN", "MAINLAND", "MALUMFASHI", "MINNA", "MANGU", "MANI", "MINJIBIR", "MOBA", "MOKWA", "MONGUNO", "MOPAMURO MOPA", "MORO", "MOWE", "MIRAGA", "MARTE", "MARU", "MASHI", "MUSAWA", "MATAZU", "MUBI", "Mubi North", "Mubi South", "MUSHIN", "MUYA", "NOT APPLICABLE", "NAFADA/BAJOGA", "NDOKWA", "Ndokwa East", "Ndokwa West", "Nembe", "NGALA", "NGANZAI", "NGOR OKPALA", "Ngaski", "NGURU", "Ngwa", "Ningi", "NJABA", "NJIKOKA", "NKANU", "Nkanu East", "Nkwerre", "NKWANGELE", "NNEWI", "Nnewi North", "Nnewi South", "NANGERE", "Nsit Atai", "NASSARAWA/EGGON", "NSITUBIUM", "Nsit Ibom", "NSUKKA", "NASARAWA", "NSITIBON", "NUMAN", "Nwangele", "OBI", "OBUDU", "Obia/Akpor", "OBOT AKARA", "Obokun", "OBANLIKU", "Obi Nwa", "OBIO/AKPOR", "OBUBRA", "OBOWO", "ODEDA", "ODIGBA", "Odigbo", "ODOOTIN", "ODUKPANI", "OFFA", "OFU", "OGBA/IJAIYE", "OGBA/EGBEMA NDONI", "Ogbia", "OGBADIBO", "OGOJA", "OGO OLUWA", "OGBOMOSHO", "Ogbomosho South", "OGORI/MAGONGO", "OGBARU", "OGUTA", "OGU/BOLO", "OGUN WATER SIDE", "OHAOZARA", "Ohafia", "OHIMINI", "OHAJI EGBEMA", "OHAUKWU", "OJI RIVER", "OJO", "OJOO", "OJU", "Okobo", "OKEHI", "OKIGWE", "OKEHO", "Okeigbo", "OKRIKA", "OKENE", "OKOH", "OKPE", "OKRIKA", "Oke-Ero", "OKITIPUPA", "OMALA", "OLAMABORRO", "OLORUNDA", "Olorunsogo", "OLAOLUWA", "OMUMMA", "Ona-Ara", "Ondo East", "Ondo west", "ONICHA", "ONIKAN", "ONNA", "ONAARA", "ONUIMO", "OPOBO/NKORO", "OKPOKWU", "ORUMBA", "Orumba North", "Orumba South", "ORIADE", "OREDO", "ORHIONWON", "ORIKANAM", "Ori ire", "Oruk Anam", "ORLU", "ORON", "OROLU", "ORELOPE", "ORIRE", "ORSU", "ORU", "Oru EAst", "Oru West", "OSHODI", "OSE", "OSHOGBO", "ONITSHA", "Onitsha North", "Onitsha South", "OSIN", "Osisioma", "OSHIMILI", "Oshimili North", "OSHODIISOLO", "OTTA", "OTUKPO", "Oturkpo", "OTUKPO", "OVIA", "Ovia South East", "Ovia South West", "OWAN", "OWERRI", "Owerri North", "Owerri West", "Owerri Municipal", "OWO", "OYE", "OYI", "OYIGBO", "OYUN", "Oyo East", "Oyo West", "PAIKORO", "PATEGI", "PORTHARCOURT", "PANKSHIN", "POTISKUM", "PATANI", "QUAAN PAN", "RABAH", "RAFI", "RASSA", "RAURE", "Remo North", "ROGO", "RIJUA", "RIMI", "RINGIM", "RIMIN GADO", "RANO", "RONI", "IREPODUN", "IREWOLE", "RIYOM", "SABUWA", "SAFANA", "sanga", "SAPELE", "SARDAUNA", "SABONGARI", "SABONBIRNI", "SANDAMU", "Sagbama", "SAGAMU", "SABONGIDA", "SHANI", "SHENDAM", "SHELLENG", "SHAGARI", "Shira", "SHANONO", "SHOMGOM", "SHIRORO", "Sakaba", "SHINKAFI", "SAKI", "Saki East", "Saki West", "SOKOTO", "Suleja", "SILAME", "SURULERE", "SULE TANKARKAR", "SHOMOLU", "SUMAILA", "SHANGA", "SOBA", "Southern Ijaw", "ISOKO", "Sokoto North", "Sokoto South", "SONG", "SAPELE", "SURULERE", "SULEIJA", "SURU", "Tafa", "TAI", "TAKAI", "TARMUA", "TAURA", "TAWA", "TAMBUWAL", "TUDUN WADA", "TOFA", "Tafawa-Balewa", "TANGAZA", "Takali", "Takum", "TAKUN", "TALATA/MAFARA", "TUDUNWADA", "Toro", "TOTO", "TOUNGO", "TARKA", "TARAUNI", "Tsanyawa", "Tsafe", "ITESIWAJU", "TURETA", "UDENU", "UDUNG UKO", "Ughelli North", "Ughelli SOuth", "UDI", "Udi Agwu", "UDU", "UGEP", "UGHELLI", "Ugwunagbo", "UHUNMWONDE", "UKANEFUN", "Ukpoba", "UKUM", "UKWUANI", "Ukwa East", "Ukwa West", "Umu-Neochi", "UMUAHIA", "Umuahia North", "Umuahia South", "UNGOGO", "UQUI IBENO", "URAN", "URUE OFFONG ORUKO", "Ushonga", "USSA", "UVWIE", "UYO", "UZOUWANI", "VANDEIKYA", "VICTORIA ISLAND", "WAMBA", "WARRI", "Warri Central", "Warri North", "Warri South", "Warji", "WASUGU", "Wasagu/Danko", "WUDIL", "WAMAKKO", "WARAWA", "WASE", "WEST YAGBA", "WUKARI", "WURNO", "WUSHISHI", "WUSE II", "Yagba East", "Yakur", "YALA", "YAMATU/DEBA", "YANKWASIU", "YARKURR", "YAURI", "YABO", "YENEGOA", "YOLA", "Yola North", "Yola South", "YORRO", "YUNUSARI", "YUSUFARI", "Zaki", "ZANGO KATAF", "ZARIA", "ZANGO", "ZING", "ZURMI", "ZURU" };
    }

    public class BVNRespMessage
    {
        public string data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
        public string ReferenceNo { get; set; }
        public string BVNNumber { get; set; }
        public string BranchCode { get; set; }
        public string AccountType { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MaritalStatus { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string AlertMode { get; set; }
        public string StateOfResidence { get; set; }
        public string Title { get; set; }
        public string Gender { get; set; }
        public string LevelOfAccount { get; set; }
        public string LgaOfOrigin { get; set; }
        public string LgaOfResidence { get; set; }
        public string NameOnCard { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string ResidentialAddress { get; set; }
        public string StateOfOrigin { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }

        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
    }

    public class AccountOpeningRequest
    {
        public string ReferenceNo { get; set; }//required
        public string Complete { get; set; }//required default = "YES" 
        public string BVNNumber { get; set; }
        public string FirstName { get; set; }//required
        public string MiddleName { get; set; }
        public string LastName { get; set; }//required
        public string DateOfBirth { get; set; }//required
        public string DateOfBirth2 { get; set; }//required
        public string MotherMaidenName { get; set; }//required
        public string Email { get; set; }//required
        public string Gender { get; set; }//required
        public string ResidentialAddress { get; set; }//required
        public string LgaOfOrigin { get; set; }
        public string LgaOfResidence { get; set; }
        public string MaritalStatus { get; set; }//required
        public string Nationality { get; set; }//required
        public string SchemeCode { get; set; } //required
        public string PhoneNumber { get; set; }//required
        public string Channel_Id { get; set; } //required
        public string PreferredBranch { get; set; }//required
        public string City { get; set; }//required
        public string Resident { get; set; }
        public string CountryCode { get; set; }//required
        public string BirthCert { get; set; }
        public string ParentPhoto { get; set; }
        public string How_You_Heard { get; set; }
        public string State { get; set; }//required
        public string Title { get; set; }//required
        public string TrusteeTitle { get; set; }
        public string TrusteeCountry { get; set; }
        public string TrusteeCity { get; set; }
        public string TrusteeState { get; set; }
        public string TrusteeMaritalStatus { get; set; }
        public string TrusteeAddr1 { get; set; }
        public string TrusteeAddr2 { get; set; }
        public string TrsuteeDob { get; set; }
        public string TrsuteeFname { get; set; }
        public string TrsuteeLname { get; set; }
        public string TrusteeMname { get; set; }
        public string TrusteePhoneNo { get; set; }
        public string TrusteeEmail { get; set; }
        public string Photo { get; set; }//(base64string)
        public string Signature { get; set; }//(base64string)
    }

    public class WalletCreationDetResponse
    {
         public string ResponseMessage { get; set; }
         public string ResponseCode { get; set; }
    }
    public class SendAccountCreationDetResponse
    {
        public string accountNumberField { get; set; }
        public string cifIdField { get; set; }
        public string errorMessageField { get; set; }
        public string responseCodeField { get; set; }
        public string responseMessageField { get; set; }
    }

    public class BVNSingleRequest
    {
        public string BVNNumber { get; set; }
    }

    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string ResponseCode { get; set; }
        public string ReferenceNo { get; set; }
        public string BVN { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string LevelOfAccount { get; set; }
        public string LgaOfOrigin { get; set; }
        public string LgaOfResidence { get; set; }
        public string MaritalStatus { get; set; }
        public string NameOnCard { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string ResidentialAddress { get; set; }
        public string StateOfOrigin { get; set; }
        public string StateOfResidence { get; set; }
        public string Title { get; set; }

    }

    public class BiometricRequest
    {

        public string AccountNunmber { get; set; }
        public string DeviceId { get; set; }
        public FingerImage FingerImage { get; set; }
        public  string AppId { get; set; }
        public string AppKey { get; set; }
    }

    public class FingerImage
    {
        public string type { get; set; }
        public string position { get; set; }
        public string nist_impression_type { get; set; }
        public string value { get; set; }
    }


    public class Data
    {
        public string responseCode { get; set; }
        public string bvn { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateOfBirth { get; set; }
        public string registrationDate { get; set; }
        public string enrollmentBank { get; set; }
        public string enrollmentBranch { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string levelOfAccount { get; set; }
        public string lgaOfOrigin { get; set; }
        public string lgaOfResidence { get; set; }
        public string maritalStatus { get; set; }
        public string nin { get; set; }
        public string nameOnCard { get; set; }
        public string nationality { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string residentialAddress { get; set; }
        public string stateOfOrigin { get; set; }
        public string stateOfResidence { get; set; }
        public string title { get; set; }
        public string watchListed { get; set; }
        public string base64Image { get; set; }
    }


    public class BVNRoot
    {
        public string code { get; set; }
        public string description { get; set; }
        public Data data { get; set; }
    }
}
