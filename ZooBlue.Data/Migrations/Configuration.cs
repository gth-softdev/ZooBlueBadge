namespace ZooBlue.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooBlue.Data.ApplicationDbContext>
    {
        public Configuration()
        {

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZooBlue.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Zoos.AddOrUpdate(
            z => z.ZooId,
            new Zoo() { ZooId = 1, ZooName = "Indianapolis Zoo", Location = "1200 West Washington St., Indianapolis, IN 46222", Admission = 24.50 },
            new Zoo() { ZooId = 2, ZooName = "Pittsburgh Zoo & PPG Aquarium", Location = "7370 Baker Street, Pittsburgh, PA 15206", Admission = 16.95 },
            new Zoo() { ZooId = 3, ZooName = "Cincinnati Zoo and Botanical Garden", Location = "3400 Vine St., Cincinnati, Ohio 45220", Admission = 23.00 },
            new Zoo() { ZooId = 4, ZooName = "Louisville Zoo", Location = "1100 Trevilian Way, Louisville, KY 40213", Admission = 19.50 },
            new Zoo() { ZooId = 5, ZooName = "Detroit Zoo", Location = "8450 W. 10 Mile Road, Royal Oak, MI 48067", Admission = 19.00 }
            );

            context.Attractions.AddOrUpdate(
                a => a.AttId,
                new Attraction() { AttId = 1, Animals = "Gila monster, Massasauga rattlesnake, Santa catalina rattlesnake, Spotted python, Green tree python, Hognose snake, Madagascar tree boa, Eyelash viper, Green iguana", Experiences = "Flamingo Feed Experience, Feed a Budgie or Lorikeet, Feed a Giraffe, Race - a - Cheetah, Kombo Family Coaster,  White River Junction Train Ride, Endangered Species Carousel, Skyline, Playground,    Tots Treehouse and Play Area", HasAquaticExhibit = true, HasGarden = true, ZooId = 1 },
                new Attraction() { AttId = 2, Animals = "Some of the most critically endangered big cats of Asia, including Amur leopards, and Siberian tigers", Experiences = "Kid's Kingdom, PPG Aquarium, Forest Passage, Tropical Forest, African Savanna, Bears, Water's Edge, The Islands, Jungle Odyssey", HasAquaticExhibit = true, HasGarden = false, ZooId = 2 },
                new Attraction() { AttId = 3, Animals = "Bobcat, Bonobo, Brazilian Porcupine, Brazilian Salmon Pink Birdeater, Brazilian White-knee tarantula, Brown Recluse Spider, Yellow-rumped cacique, Zebra Bug", Experiences = "Cheetah Encounter, Blakely’s Barnyard Bonanza, Wings of Wonder", HasAquaticExhibit = true, HasGarden = true, ZooId = 3 },
                new Attraction() { AttId = 4, Animals = "Addax, African lion, Hartmann's mountain zebra, Red ruffed lemur, Demoiselle crane, African pygmy falcon, Asian elephant, Snow leopard, Masai giraffe, Mhorr gazelle, Orangutan, Maned wolf, Jaguar, Peacock, Sumatran tiger, Southern white rhinoceros", Experiences = "Gorilla Forest, Herpaquarium, Wallaroo Walkabout, Lorikeet Landing, Glacier Run, Africa", HasAquaticExhibit = true, HasGarden = true, ZooId = 4 },
                new Attraction() { AttId = 5, Animals = "Bactrian camels, Red kangaroo, Ring-tailed lemur, African lion, Western lowland gorilla, White rhinoceros, Warthog, Common eland, Chimpanzees, American bison, Gray wolf, Grevy's zebras", Experiences = "Arctic Ring of Life, Australian Outback Adventure, Cotton Family Wolf Wilderness, Great Apes of Harambee, Holden Reptile Conservation Center, National Amphibian Conservation Center, Polk Penguin Conservation Center, Matilda Wilson Free-Flight Aviary", HasAquaticExhibit = true, HasGarden = true, ZooId = 5 }
                );

            context.Reviews.AddOrUpdate(
                r => r.ReviewId,
                new Review() { ReviewId = 1, Rating = 4, ReviewText = "The Indianapolis Zoo is a zoo located in White River State Park, in Indianapolis, Indiana, United States, housing more than 3,800 animals of more than 320 species and subspecies. The institution is accredited by the Association of Zoos and Aquariums (AZA) and the American Alliance of Museums as a zoo, an aquarium, and as a botanical garden. The zoo is a private non-profit organization, receiving no tax support and is supported entirely by membership fees, admissions, donations, sales, grants, and an annual fundraiser. ", ZooId = 1 },
                new Review() { ReviewId = 2, Rating = 2, ReviewText = "The Pittsburgh Zoo is one of only six major zoo and aquarium combinations in the United States. Located in Pittsburgh, Pennsylvania's Highland Park, the zoo sits on 77 acres (31 ha) of park land where it exhibits more than 4,000 animals representing 475 species, including 20 threatened or endangered species. The zoo's accredited membership of the Association of Zoos and Aquariums (AZA) was dropped in 2015.", ZooId = 2 },
                new Review() { ReviewId = 3, Rating = 5, ReviewText = "The Cincinnati Zoo & Botanical Garden is the second-oldest zoo in the United States, opening in 1875, after the Philadelphia Zoo (1874). It is located in the Avondale neighborhood of Cincinnati, Ohio. It originally began with 64.5 acres (26.5 ha) in the middle of the city, but has spread into the neighboring blocks and several reserves in Cincinnati's outer suburbs. It was appointed as a National Historic Landmark in 1987.", ZooId = 3 },
                new Review() { ReviewId = 4, Rating = 2, ReviewText = "The Louisville Zoo, or the Louisville Zoological Garden, is a 134-acre (54 ha) zoo in Louisville, Kentucky, situated in the city's Poplar Level neighborhood. Founded in 1969, the \"State Zoo of Kentucky\" currently exhibits over 1,700 animals in naturalistic and mixed animal settings representing both geographical areas and biomes or habitats.", ZooId = 4 },
                new Review() { ReviewId = 5, Rating = 3, ReviewText = "The Detroit Zoo is a zoo located in Royal Oak and Huntington Woods, Michigan, about 2 miles (3.2 km) north of the Detroit city limits, at the intersection of Woodward Avenue, 10 Mile Road, and Interstate 696. It is operated by the Detroit Zoological Society (DZS), a non-profit organization, along with the Belle Isle Nature Center, located within the city limits of Detroit on Belle Isle. The Detroit Zoo is one of Michigan's largest family attractions, hosting more than 1.5 million visitors annually. Situated on 125 acres of naturalistic exhibits, it is home to more than 2,400 animals representing 235 species.[8] The Detroit Zoo was the first zoo in the United States to use barless exhibits extensively. ", ZooId = 5 },
                 new Review() { ReviewId = 6, Rating = 5, ReviewText = "The mission of the Indianapolis Zoo is to empower people and communities, both locally and globally, to advance animal conservation. To this end, we see ourselves as a conservation organization that operates a zoo as a key engagement and outreach strategy. The Zoo provides engaging exhibits throughout five biomes (Oceans, Deserts, Forests, Plains and Encounters). Each new exhibit is designed to provide an up-close encounter with the animal, and information that will enlighten guests about current conservation issues, empowering them to take personal action.", ZooId = 1 },
                 new Review() { ReviewId = 7, Rating = 1, ReviewText = "Pittsburgh Zoo and its International Conservation Center (ICC) harm elephants in an unbroken pattern of negligence that defies even mainstream zoo norms,” reads an IDA report published on Jan. 23. “In Defense of Animals' investigations have exposed this Zoo's substandard elephant barn and found new information about its separation of three elephants who have been together for around a quarter of a century. Pittsburgh Zoo easily earned its place as the #1 worst zoo on this year's list of the 10 Worst Zoos for Elephants in North America.", ZooId = 2 },
                 new Review() { ReviewId = 8, Rating = 5, ReviewText = "This second oldest zoo in the U.S., considered one of the best in the country, is most renowned for its endangered species and birthing programs, particularly for gorillas and white tigers, and has a wonderful collection of felines and a delightful manatees exhibit.", ZooId = 3 },
                 new Review() { ReviewId = 9, Rating = 3, ReviewText = "Recent guests praised the zoo for its engaging guides and clean facilities and particularly note it's a good spot to take very young children (because Louisville Zoo is small, it's easily manageable for short legs to walk through). Travelers also described the zoo's atmosphere as relaxing and said that it never feels overly crowded thanks to its well-designed layout.", ZooId = 4 },
                 new Review() { ReviewId = 10, Rating = 4, ReviewText = "This a great facility & it has activities for the all family is the best value for the money;we have a family membership & every chance that we have we go out for a walk;my Kids love the new penguin exhibit & my wife & I love the out-doors gardens & the friendly & helpful staff;if you are in the Midwest you have to see the Detroit Zoo.", ZooId = 5 }
                );
        }
    }
}
