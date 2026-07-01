using UnityEngine;

[CreateAssetMenu(fileName = "Text", menuName = "Scriptable Objects/Text")]
public class Text : ScriptableObject
{
    public class information {
        public string information_Text;
        public string Information_giver;
        public string Exit_text;
       public information(string information, string giver, string exitText)
        {
            information_Text = information;
            Information_giver = giver;
            Exit_text = exitText;
        }
    }
    public static string takahe_text = "The South Island takahe is a rare relict of the flightless, vegetarian bird fauna which once ranged New Zealand." +
         " Four specimens were collected from Fiordland between 1849 and 1898, after which takahē were considered to be extinct until famously rediscovered in the Murchison Mountains," +
         " west of Lake Te Anau, in 1948. Until the 1980s, takahē were confined in the wild to the Murchison Mountains." +
         " They have since been translocated to seven islands and several mainland sites, making them more accessible to many New Zealanders." +
         " Conservation work by the Department Of Conservation and community groups aims to prevent extinction and restore takahē to sites throughout their original range." +
         " The success of DOC’s Takahē Recovery Programme relies heavily on a partnership with Mitre 10 who through Mitre 10 Takahē Rescue is helping to ensure the long-term survival of this treasured species." +
         "\r\n\r\nIdentification" +
         "\r\nThe South Island takahe is the largest living rail in the world." +
         " An enormous gallinule, it has deep blue on the head, neck and underparts, olive green on the wings and back, and a white undertail," +
         " The huge conical bill is bright red, paler towards the tip, and extends on to the forehead as a red frontal shield." +
         " The stout legs are red, with orange underneath. Juveniles are duller with a blackish-orange beak and dull pink-brown legs." +
         "\r\n\r\nVoice: the main calls of takahē are a loud shriek, a quiet hooting contact call, and a muted boom indicating alarm." +
         "\r\n\r\nSimilar species: the extinct North Island takahe was taller and more slender." +
         " Pūkeko can fly, and are smaller and more slender, with relatively longer legs, and black on the wings and back." +
         "\r\n\r\nDistribution and habitat" +
         "\r\nSouth Island takahe originally occurred throughout the South Island. Hunting, predation and habitat loss resulted in a remnant population in the mountains of Fiordland." +
         " The modern conservation programme has set up additional populations; a captive breeding and rearing facility at Burwood Bush near Te Anau," +
         " plus free-ranging populations on wildlife reserves in the North and South Island and several offshore islands including Tiritiri Matangi and Motutapu (Hauraki Gulf)," +
         " Kapiti and Mana (Wellington) and Maud (Marlborough Sounds)." +
         "\r\n\r\nTakahē inhabit grasslands predominantly, using shrubs for shelter." +
         " In Fiordland, alpine tussock grasslands and the red tussock river flats are preferred." +
         " When winter snow covers these areas, birds move into adjacent beech forest." +
         " At other sites the vegetation is regenerating farm pasture in various stages of reversion to mixed native lowland forest." +
         " Some now have substantial forested areas." +
         " At these sites takahē prefer the grassland areas with scattered shrubs, although they do spend some time under forest." +
         "\r\n\r\nPopulation" +
         "\r\nThe South Island takahe population in 2011-12 was approximately 276 birds, with ~110 in Fiordland, ~107 at restoration sites, 11 at captive display sites, and 48 at the captive breeding site." +
         "\r\n\r\nThreats and conservation\r\nNatural hazards influencing the Fiordland takahē population include avalanches and cold climate." +
         " Modern threats include predation by introduced stoats, and competition for food from introduced red deer." +
         " Deer numbers have been controlled to low levels since 1980, allowing tussock grasslands to slowly recover their original size and nutrients." +
         " Stoat predation impact is relatively low in most years but when environmental conditions conspire, stoat populations increase significantly, and have greater impact on takahē survival." +
         " The Fiordland takahē population is under a recently extended stoat trapping programme." +
         "\r\n\r\nFrom 1986 - 2009," +
         " takahē in Fiordland were managed by captive-rearing wild eggs, releasing yearlings back into the wild." +
         " Artificial incubation and puppet-rearing were used to maximise productivity." +
         " From 1986-1991, yearlings were released outside of the source population in an attempt to extend the range." +
         " From 1991-2009 there was a change to releasing among the source population which improved survival of released birds." +
         "\r\n\r\nAlso, from 1984, captive-reared birds were used to establish breeding populations on predator-free offshore islands and predator-proofed mainland reserves." +
         " Now that the island/reserves population is well established, eggs for captive rearing are no longer removed from Fiordland." +
         " Since 2010, rather than augment the Fiordland population, captive-reared yearlings have been used to establish populations at new sites and expand the captive breeding population." +
         "\r\n\r\nNumbers on island/mainland reserves are managed by the removal of surplus young. This activity both limits population density to a suitable level and avoids inbreeding by mixing genetic lines between different sites." +
         " At the captive breeding facility, puppet rearing is redundant and artificial incubation is minimised." +
         " Instead, the enlarged breeding group is intensively managed through egg and chick fostering, ensuring each pair is laying, incubating good eggs or raising chicks. " +
         "Genetic lines are managed to ensure none is over-represented." +
         "\r\n\r\nBreeding" +
         "\r\nTakahē in Fiordland lay late October-January. In the lower altitude sites nesting begins in September." +
         " One to three eggs (usually two) are laid two days apart;" +
         " male and female share incubation and chick rearing equally. " +
        "Eggs are pale buff colour with reddish-purplish blotches (c. 74 x 48 mm, and 95 g when fresh). Incubation takes 30 days, with chicks hatching two days apart." +
         " Chicks stay in the nest for about a week, as they become stronger they climb out and follow their parents begging for food. Chicks are brooded in the nest in cold or wet weather." +
         " Parents provide tussock shoots for the chicks with the tougher outer leaves peeled off." +
        " Parents move the family to access a fresh feeding area as soon as the chicks are able, repeating as necessary." +
         " If the first clutch fails, takahē may lay a second. They can lay a third in an intensively managed situation." +
        "\r\n\r\nBehaviour and ecology\r\nTakahē live in pairs or small family groups." +
         " Young stay with parents until just before the next breeding season, or stay for a second year." +
        " Unusual cases of breeding trios or greater (two females laying) have been observed. " +
         "Pairs defend their breeding territory by calling, or fighting if necessary, returning to the same areas each year." +
         "\r\n\r\nFood\r\nFiordland takahē feed mainly on leaf bases of tussock grasses (Chionochloa spp)." +
        " Sedges (Uncinia spp, Carex coriacea), rushes (Juncus spp) and Aciphylla spp are sometimes taken. " +
         "Smaller grasses are grazed from the tips down, this being the staple on islands and lowland reserves. " +
        "When available, grass seeds are stripped from the stem while still attached." +
         " In Fiordland winter (forest) habitat, alternative carbohydrate is found by grubbing starchy rhizomes of a fern Hypolepis millefolium and the rhizomes of the sedge Carex coriacea." +
         " In other sites the diet does not vary as much seasonally - pasture grasses are available all year round." +
         " Takahē opportunistically take a protein in the form of large insects (moths, beetles, weta), or very rarely will take ducklings or lizards." +
         "\r\n\r\nWeblinks\r\nTakahē Recovery website \r\n\r\nDepartment of Conservation’s website, takahē" +
         "\r\n\r\nWikipedia\r\n\r\nReferences\r\nGrueber, C.E.; Maxwell, J.M.; Jamieson, I.G.  2012. " +
         "Are introduced takahe populations on offshore islands at carrying capacity? Implications for genetic management." +
        " New Zealand Journal of Ecology 36: 223-227.\r\n\r\nHegg, D.; Greaves, G.; Maxwell, J.M.; MacKenzie, D.I.; Jamieson, I.G. 2012." +
         " Demography of takahe (Porphyrio hochstetteri) in Fiordland: environmental factors and management affect survival and breeding success." +
        " New Zealand Journal of Ecology 36: 75-89." +
         "\r\n\r\nLee, W.G.; Fenner, M.; Loughnan, A.; Lloyd, K.M. 2000." +
        " Long-term effects of defoliation: incomplete recovery of a New Zealandalpine tussock grass, Chionochloa pallens, after 20 years." +
         " Journal of Applied Ecology 37: 348-355.\r\n\r\nMaxwell, J.M. 2001. Fiordland takahe: population trends, dynamics and problems. " +
        "Pp 61-79 in Lee, W.G.; Jamieson, I.G. (eds)  The takahe – fifty years of conservation management and research. " +
         "University of Otago Press, Dunedin.  \r\n\r\nMiskelly, C.M.; Powlesland, R.G. 2013. Conservation translocations of New Zealand birds, 1863-2012. " +
        "Notornis 60: 3-28.\r\n\r\nRobertson, H.A; Baird, K.; Elliott, G.P.;" +
         " Hitchmough, R.A.; McArthur, N.J.; Makan, T.; Miskelly, C.M.; O’Donnell, C.F.J.; Sagar, P.M.; Scofield, R.P.; Taylor, G.A.; Michel, P. 2021." +
         " Conservation status of birds in Aotearoa New Zealand birds, 2021. New Zealand Threat Classification Series 36. Wellington, Department of Conservation. 43p." +
         "\r\n\r\nTrewick, S.A.; Worthy T.H. 2001. Origins and prehistoric ecology of takahe based on morphometric, molecular and fossil data. " +
        "Pp 31-48 in Lee, W.G.; Jamieson, I.G. (eds)  The takahe – fifty years of conservation management and research." +
         " University of Otago Press, Dunedin.\r\n\r\nRecommended citation\r\nMaxwell, J.M. 2013 [updated 2025]." +
         " South Island takahe | takahē. In Miskelly, C.M. (ed.) New Zealand Birds Online. www.nzbirdsonline.org.nz";
   public  static string quest = "Please go and capture all of the rats in this area to help protect the Takahe ";
    
    public information TakaheInfo = new information(takahe_text,"Takahe","Continue ");
    public information Quest = new information(quest, "Conservation Scientist Lady "," Accept Quest ");
    public information InformationDisplay = new information("Testing","tests","Exit");

    public void SetText(information Set)
    {
        InformationDisplay = Set;
    }



}
