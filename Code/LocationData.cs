﻿
namespace FullerHelpers
{
    public static class LocationData
    {
        public class State
        {
            public string Name { get; set; }
            public string Abbreviation { get; set; }
        }

        public class Country
        {
            public string Name { get; set; }
            public string Abbreviation { get; set; }
            public int? SortOrder { get; set; }
        }

        public static readonly Country[] Countries =
        {
            new Country { Name = "Afghanistan" , Abbreviation = "AF" },
            new Country { Name = "Aland Islands" , Abbreviation = "AX" },
            new Country { Name = "Albania" , Abbreviation = "AL" },
            new Country { Name = "Algeria" , Abbreviation = "DZ" },
            new Country { Name = "American Samoa" , Abbreviation = "AS" },
            new Country { Name = "Andorra" , Abbreviation = "AD" },
            new Country { Name = "Angola" , Abbreviation = "AO" },
            new Country { Name = "Anguilla" , Abbreviation = "AI" },
            new Country { Name = "Antarctica" , Abbreviation = "AQ" },
            new Country { Name = "Antigua And Barbuda" , Abbreviation = "AG" },
            new Country { Name = "Argentina" , Abbreviation = "AR" },
            new Country { Name = "Armenia" , Abbreviation = "AM" },
            new Country { Name = "Aruba" , Abbreviation = "AW" },
            new Country { Name = "Australia" , Abbreviation = "AU" },
            new Country { Name = "Austria" , Abbreviation = "AT" },
            new Country { Name = "Azerbaijan" , Abbreviation = "AZ" },
            new Country { Name = "Bahamas" , Abbreviation = "BS" },
            new Country { Name = "Bahrain" , Abbreviation = "BH" },
            new Country { Name = "Bangladesh" , Abbreviation = "BD" },
            new Country { Name = "Barbados" , Abbreviation = "BB" },
            new Country { Name = "Belarus" , Abbreviation = "BY" },
            new Country { Name = "Belgium" , Abbreviation = "BE" },
            new Country { Name = "Belize" , Abbreviation = "BZ" },
            new Country { Name = "Benin" , Abbreviation = "BJ" },
            new Country { Name = "Bermuda" , Abbreviation = "BM" },
            new Country { Name = "Bhutan" , Abbreviation = "BT" },
            new Country { Name = "Bolivia" , Abbreviation = "BO" },
            new Country { Name = "Bonaire" , Abbreviation = "BQ" },
            new Country { Name = "Bosnia And Herzegovina" , Abbreviation = "BA" },
            new Country { Name = "Botswana" , Abbreviation = "BW" },
            new Country { Name = "Bouvet Island" , Abbreviation = "BV" },
            new Country { Name = "Brazil" , Abbreviation = "BR" },
            new Country { Name = "British Indian Ocean Territory" , Abbreviation = "IO" },
            new Country { Name = "Brunei Darussalam" , Abbreviation = "BN" },
            new Country { Name = "Bulgaria" , Abbreviation = "BG" },
            new Country { Name = "Burkina Faso" , Abbreviation = "BF" },
            new Country { Name = "Burundi" , Abbreviation = "BI" },
            new Country { Name = "Cambodia" , Abbreviation = "KH" },
            new Country { Name = "Cameroon" , Abbreviation = "CM" },
            new Country { Name = "Canada" , Abbreviation = "CA", SortOrder = 99 },
            new Country { Name = "Cape Verde" , Abbreviation = "CV" },
            new Country { Name = "Cayman Islands" , Abbreviation = "KY" },
            new Country { Name = "Central African Republic" , Abbreviation = "CF" },
            new Country { Name = "Chad" , Abbreviation = "TD" },
            new Country { Name = "Chile" , Abbreviation = "CL" },
            new Country { Name = "China" , Abbreviation = "CN" },
            new Country { Name = "Christmas Island" , Abbreviation = "CX" },
            new Country { Name = "Cocos (Keeling) Islands" , Abbreviation = "CC" },
            new Country { Name = "Colombia" , Abbreviation = "CO" },
            new Country { Name = "Comoros" , Abbreviation = "KM" },
            new Country { Name = "Congo" , Abbreviation = "CG" },
            new Country { Name = "Congo" , Abbreviation = "CD" },
            new Country { Name = "Cook Islands" , Abbreviation = "CK" },
            new Country { Name = "Costa Rica" , Abbreviation = "CR" },
            new Country { Name = "Cote D'ivoire" , Abbreviation = "CI" },
            new Country { Name = "Croatia" , Abbreviation = "HR" },
            new Country { Name = "Cuba" , Abbreviation = "CU" },
            new Country { Name = "Curacao" , Abbreviation = "CW" },
            new Country { Name = "Cyprus" , Abbreviation = "CY" },
            new Country { Name = "Czech Republic" , Abbreviation = "CZ" },
            new Country { Name = "Denmark" , Abbreviation = "DK" },
            new Country { Name = "Djibouti" , Abbreviation = "DJ" },
            new Country { Name = "Dominica" , Abbreviation = "DM" },
            new Country { Name = "Dominican Republic" , Abbreviation = "DO" },
            new Country { Name = "Ecuador" , Abbreviation = "EC" },
            new Country { Name = "Egypt" , Abbreviation = "EG" },
            new Country { Name = "El Salvador" , Abbreviation = "SV" },
            new Country { Name = "Equatorial Guinea" , Abbreviation = "GQ" },
            new Country { Name = "Eritrea" , Abbreviation = "ER" },
            new Country { Name = "Estonia" , Abbreviation = "EE" },
            new Country { Name = "Ethiopia" , Abbreviation = "ET" },
            new Country { Name = "Falkland Islands" , Abbreviation = "FK" },
            new Country { Name = "Faroe Islands" , Abbreviation = "FO" },
            new Country { Name = "Fiji" , Abbreviation = "FJ" },
            new Country { Name = "Finland" , Abbreviation = "FI" },
            new Country { Name = "France" , Abbreviation = "FR" },
            new Country { Name = "French Guiana" , Abbreviation = "GF" },
            new Country { Name = "French Polynesia" , Abbreviation = "PF" },
            new Country { Name = "French Southern Territories" , Abbreviation = "TF" },
            new Country { Name = "Gabon" , Abbreviation = "GA" },
            new Country { Name = "Gambia" , Abbreviation = "GM" },
            new Country { Name = "Georgia" , Abbreviation = "GE" },
            new Country { Name = "Germany" , Abbreviation = "DE" },
            new Country { Name = "Ghana" , Abbreviation = "GH" },
            new Country { Name = "Gibraltar" , Abbreviation = "GI" },
            new Country { Name = "Greece" , Abbreviation = "GR" },
            new Country { Name = "Greenland" , Abbreviation = "GL" },
            new Country { Name = "Grenada" , Abbreviation = "GD" },
            new Country { Name = "Guadeloupe" , Abbreviation = "GP" },
            new Country { Name = "Guam" , Abbreviation = "GU" },
            new Country { Name = "Guatemala" , Abbreviation = "GT" },
            new Country { Name = "Guernsey" , Abbreviation = "GG" },
            new Country { Name = "Guinea" , Abbreviation = "GN" },
            new Country { Name = "Guinea-Bissau" , Abbreviation = "GW" },
            new Country { Name = "Guyana" , Abbreviation = "GY" },
            new Country { Name = "Haiti" , Abbreviation = "HT" },
            new Country { Name = "Heard Island And Mcdonald Islands" , Abbreviation = "HM" },
            new Country { Name = "Holy See (Vatican City State)" , Abbreviation = "VA" },
            new Country { Name = "Honduras" , Abbreviation = "HN" },
            new Country { Name = "Hong Kong" , Abbreviation = "HK" },
            new Country { Name = "Hungary" , Abbreviation = "HU" },
            new Country { Name = "Iceland" , Abbreviation = "IS" },
            new Country { Name = "India" , Abbreviation = "IN" },
            new Country { Name = "Indonesia" , Abbreviation = "ID" },
            new Country { Name = "Iran" , Abbreviation = "IR" },
            new Country { Name = "Iraq" , Abbreviation = "IQ" },
            new Country { Name = "Ireland" , Abbreviation = "IE" },
            new Country { Name = "Isle Of Man" , Abbreviation = "IM" },
            new Country { Name = "Israel" , Abbreviation = "IL" },
            new Country { Name = "Italy" , Abbreviation = "IT" },
            new Country { Name = "Jamaica" , Abbreviation = "JM" },
            new Country { Name = "Japan" , Abbreviation = "JP" },
            new Country { Name = "Jersey" , Abbreviation = "JE" },
            new Country { Name = "Jordan" , Abbreviation = "JO" },
            new Country { Name = "Kazakhstan" , Abbreviation = "KZ" },
            new Country { Name = "Kenya" , Abbreviation = "KE" },
            new Country { Name = "Kiribati" , Abbreviation = "KI" },
            new Country { Name = "North Korea" , Abbreviation = "KP" },
            new Country { Name = "South Korea" , Abbreviation = "KR" },
            new Country { Name = "Kuwait" , Abbreviation = "KW" },
            new Country { Name = "Kyrgyzstan" , Abbreviation = "KG" },
            new Country { Name = "Lao People's Democratic Republic" , Abbreviation = "LA" },
            new Country { Name = "Latvia" , Abbreviation = "LV" },
            new Country { Name = "Lebanon" , Abbreviation = "LB" },
            new Country { Name = "Lesotho" , Abbreviation = "LS" },
            new Country { Name = "Liberia" , Abbreviation = "LR" },
            new Country { Name = "Libyan Arab Jamahiriya" , Abbreviation = "LY" },
            new Country { Name = "Liechtenstein" , Abbreviation = "LI" },
            new Country { Name = "Lithuania" , Abbreviation = "LT" },
            new Country { Name = "Luxembourg" , Abbreviation = "LU" },
            new Country { Name = "Macao" , Abbreviation = "MO" },
            new Country { Name = "Macedonia" , Abbreviation = "MK" },
            new Country { Name = "Madagascar" , Abbreviation = "MG" },
            new Country { Name = "Malawi" , Abbreviation = "MW" },
            new Country { Name = "Malaysia" , Abbreviation = "MY" },
            new Country { Name = "Maldives" , Abbreviation = "MV" },
            new Country { Name = "Mali" , Abbreviation = "ML" },
            new Country { Name = "Malta" , Abbreviation = "MT" },
            new Country { Name = "Marshall Islands" , Abbreviation = "MH" },
            new Country { Name = "Martinique" , Abbreviation = "MQ" },
            new Country { Name = "Mauritania" , Abbreviation = "MR" },
            new Country { Name = "Mauritius" , Abbreviation = "MU" },
            new Country { Name = "Mayotte" , Abbreviation = "YT" },
            new Country { Name = "Mexico" , Abbreviation = "MX" },
            new Country { Name = "Micronesia" , Abbreviation = "FM" },
            new Country { Name = "Moldova" , Abbreviation = "MD" },
            new Country { Name = "Monaco" , Abbreviation = "MC" },
            new Country { Name = "Mongolia" , Abbreviation = "MN" },
            new Country { Name = "Montenegro" , Abbreviation = "ME" },
            new Country { Name = "Montserrat" , Abbreviation = "MS" },
            new Country { Name = "Morocco" , Abbreviation = "MA" },
            new Country { Name = "Mozambique" , Abbreviation = "MZ" },
            new Country { Name = "Myanmar" , Abbreviation = "MM" },
            new Country { Name = "Namibia" , Abbreviation = "NA" },
            new Country { Name = "Nauru" , Abbreviation = "NR" },
            new Country { Name = "Nepal" , Abbreviation = "NP" },
            new Country { Name = "Netherlands" , Abbreviation = "NL" },
            new Country { Name = "New Caledonia" , Abbreviation = "NC" },
            new Country { Name = "New Zealand" , Abbreviation = "NZ" },
            new Country { Name = "Nicaragua" , Abbreviation = "NI" },
            new Country { Name = "Niger" , Abbreviation = "NE" },
            new Country { Name = "Nigeria" , Abbreviation = "NG" },
            new Country { Name = "Niue" , Abbreviation = "NU" },
            new Country { Name = "Norfolk Island" , Abbreviation = "NF" },
            new Country { Name = "Northern Mariana Islands" , Abbreviation = "MP" },
            new Country { Name = "Norway" , Abbreviation = "NO" },
            new Country { Name = "Oman" , Abbreviation = "OM" },
            new Country { Name = "Pakistan" , Abbreviation = "PK" },
            new Country { Name = "Palau" , Abbreviation = "PW" },
            new Country { Name = "Palestinian Territory, Occupied" , Abbreviation = "PS" },
            new Country { Name = "Panama" , Abbreviation = "PA" },
            new Country { Name = "Papua New Guinea" , Abbreviation = "PG" },
            new Country { Name = "Paraguay" , Abbreviation = "PY" },
            new Country { Name = "Peru" , Abbreviation = "PE" },
            new Country { Name = "Philippines" , Abbreviation = "PH" },
            new Country { Name = "Pitcairn" , Abbreviation = "PN" },
            new Country { Name = "Poland" , Abbreviation = "PL" },
            new Country { Name = "Portugal" , Abbreviation = "PT" },
            new Country { Name = "Puerto Rico" , Abbreviation = "PR" },
            new Country { Name = "Qatar" , Abbreviation = "QA" },
            new Country { Name = "Reunion" , Abbreviation = "RE" },
            new Country { Name = "Romania" , Abbreviation = "RO" },
            new Country { Name = "Russian Federation" , Abbreviation = "RU" },
            new Country { Name = "Rwanda" , Abbreviation = "RW" },
            new Country { Name = "Saint Barthelemy" , Abbreviation = "BL" },
            new Country { Name = "Saint Helena" , Abbreviation = "SH" },
            new Country { Name = "Saint Kitts And Nevis" , Abbreviation = "KN" },
            new Country { Name = "Saint Lucia" , Abbreviation = "LC" },
            new Country { Name = "Saint Martin (French Part)" , Abbreviation = "MF" },
            new Country { Name = "Saint Pierre And Miquelon" , Abbreviation = "PM" },
            new Country { Name = "Saint Vincent And The Grenadines" , Abbreviation = "VC" },
            new Country { Name = "Samoa" , Abbreviation = "WS" },
            new Country { Name = "San Marino" , Abbreviation = "SM" },
            new Country { Name = "Sao Tome And Principe" , Abbreviation = "ST" },
            new Country { Name = "Saudi Arabia" , Abbreviation = "SA" },
            new Country { Name = "Senegal" , Abbreviation = "SN" },
            new Country { Name = "Serbia" , Abbreviation = "RS" },
            new Country { Name = "Seychelles" , Abbreviation = "SC" },
            new Country { Name = "Sierra Leone" , Abbreviation = "SL" },
            new Country { Name = "Singapore" , Abbreviation = "SG" },
            new Country { Name = "Sint Maarten (Dutch Part)" , Abbreviation = "SX" },
            new Country { Name = "Slovakia" , Abbreviation = "SK" },
            new Country { Name = "Slovenia" , Abbreviation = "SI" },
            new Country { Name = "Solomon Islands" , Abbreviation = "SB" },
            new Country { Name = "Somalia" , Abbreviation = "SO" },
            new Country { Name = "South Africa" , Abbreviation = "ZA" },
            new Country { Name = "South Georgia And The South Sandwich Islands" , Abbreviation = "GS" },
            new Country { Name = "Spain" , Abbreviation = "ES" },
            new Country { Name = "Sri Lanka" , Abbreviation = "LK" },
            new Country { Name = "Sudan" , Abbreviation = "SD" },
            new Country { Name = "Suriname" , Abbreviation = "SR" },
            new Country { Name = "Svalbard And Jan Mayen" , Abbreviation = "SJ" },
            new Country { Name = "Swaziland" , Abbreviation = "SZ" },
            new Country { Name = "Sweden" , Abbreviation = "SE" },
            new Country { Name = "Switzerland" , Abbreviation = "CH" },
            new Country { Name = "Syrian Arab Republic" , Abbreviation = "SY" },
            new Country { Name = "Taiwan" , Abbreviation = "TW" },
            new Country { Name = "Tajikistan" , Abbreviation = "TJ" },
            new Country { Name = "Tanzania" , Abbreviation = "TZ" },
            new Country { Name = "Thailand" , Abbreviation = "TH" },
            new Country { Name = "Timor-Leste" , Abbreviation = "TL" },
            new Country { Name = "Togo" , Abbreviation = "TG" },
            new Country { Name = "Tokelau" , Abbreviation = "TK" },
            new Country { Name = "Tonga" , Abbreviation = "TO" },
            new Country { Name = "Trinidad And Tobago" , Abbreviation = "TT" },
            new Country { Name = "Tunisia" , Abbreviation = "TN" },
            new Country { Name = "Turkey" , Abbreviation = "TR" },
            new Country { Name = "Turkmenistan" , Abbreviation = "TM" },
            new Country { Name = "Turks And Caicos Islands" , Abbreviation = "TC" },
            new Country { Name = "Tuvalu" , Abbreviation = "TV" },
            new Country { Name = "Uganda" , Abbreviation = "UG" },
            new Country { Name = "Ukraine" , Abbreviation = "UA" },
            new Country { Name = "United Arab Emirates" , Abbreviation = "AE" },
            new Country { Name = "United Kingdom" , Abbreviation = "GB" },
            new Country { Name = "United States" , Abbreviation = "US", SortOrder = 100 },
            new Country { Name = "United States Minor Outlying Islands" , Abbreviation = "UM" },
            new Country { Name = "Uruguay" , Abbreviation = "UY" },
            new Country { Name = "Uzbekistan" , Abbreviation = "UZ" },
            new Country { Name = "Vanuatu" , Abbreviation = "VU" },
            new Country { Name = "Venezuela" , Abbreviation = "VE" },
            new Country { Name = "Viet Nam" , Abbreviation = "VN" },
            new Country { Name = "Virgin Islands, British" , Abbreviation = "VG" },
            new Country { Name = "Virgin Islands, U.S." , Abbreviation = "VI" },
            new Country { Name = "Wallis And Futuna" , Abbreviation = "WF" },
            new Country { Name = "Western Sahara" , Abbreviation = "EH" },
            new Country { Name = "Yemen" , Abbreviation = "YE" },
            new Country { Name = "Zambia" , Abbreviation = "ZM" },
            new Country { Name = "Zimbabwe" , Abbreviation = "ZW" }
        };

        public static readonly State[] US_STATES = 
        {
            new State { Name = "Alabama",Abbreviation = "AL" },
            new State { Name = "Alaska",Abbreviation = "AK" },
            new State { Name = "Arizona",Abbreviation = "AZ" },
            new State { Name = "Arkansas",Abbreviation = "AR" },
            new State { Name = "California",Abbreviation = "CA" },
            new State { Name = "Colorado",Abbreviation = "CO" },
            new State { Name = "Connecticut",Abbreviation = "CT" },
            new State { Name = "Delaware",Abbreviation = "DE" },
            new State { Name = "District of Columbia",Abbreviation = "DC" },
            new State { Name = "Florida",Abbreviation = "FL" },
            new State { Name = "Georgia",Abbreviation = "GA" },
            new State { Name = "Hawaii",Abbreviation = "HI" },
            new State { Name = "Idaho",Abbreviation = "ID" },
            new State { Name = "Illinois",Abbreviation = "IL" },
            new State { Name = "Indiana",Abbreviation = "IN" },
            new State { Name = "Iowa",Abbreviation = "IA" },
            new State { Name = "Kansas",Abbreviation = "KS" },
            new State { Name = "Kentucky",Abbreviation = "KY" },
            new State { Name = "Louisiana",Abbreviation = "LA" },
            new State { Name = "Maine",Abbreviation = "ME" },
            new State { Name = "Maryland",Abbreviation = "MD" },
            new State { Name = "Massachusetts",Abbreviation = "MA" },
            new State { Name = "Michigan",Abbreviation = "MI" },
            new State { Name = "Minnesota",Abbreviation = "MN" },
            new State { Name = "Mississippi",Abbreviation = "MS" },
            new State { Name = "Missouri",Abbreviation = "MO" },
            new State { Name = "Montana",Abbreviation = "MT" },
            new State { Name = "Nebraska",Abbreviation = "NE" },
            new State { Name = "Nevada",Abbreviation = "NV" },
            new State { Name = "New Hampshire",Abbreviation = "NH" },
            new State { Name = "New Jersey",Abbreviation = "NJ" },
            new State { Name = "New Mexico",Abbreviation = "NM" },
            new State { Name = "New York",Abbreviation = "NY" },
            new State { Name = "North Carolina",Abbreviation = "NC" },
            new State { Name = "North Dakota",Abbreviation = "ND" },
            new State { Name = "Ohio",Abbreviation = "OH" },
            new State { Name = "Oklahoma",Abbreviation = "OK" },
            new State { Name = "Oregon",Abbreviation = "OR" },
            new State { Name = "Pennsylvania",Abbreviation = "PA" },
            new State { Name = "Rhode Island",Abbreviation = "RI" },
            new State { Name = "South Carolina",Abbreviation = "SC" },
            new State { Name = "South Dakota",Abbreviation = "SD" },
            new State { Name = "Tennessee",Abbreviation = "TN" },
            new State { Name = "Texas",Abbreviation = "TX" },
            new State { Name = "Utah",Abbreviation = "UT" },
            new State { Name = "Vermont",Abbreviation = "VT" },
            new State { Name = "Virginia",Abbreviation = "VA" },
            new State { Name = "Washington",Abbreviation = "WA" },
            new State { Name = "West Virginia",Abbreviation = "WV" },
            new State { Name = "Wisconsin",Abbreviation = "WI" },
            new State { Name = "Wyoming",Abbreviation = "WY" }
        };
    }
}