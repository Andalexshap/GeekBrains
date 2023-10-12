using System.Linq;
using System.Runtime.InteropServices;

namespace HW1.Models
{
    internal class FamilyMember : Person
    {
        public FamilyMember Mother { get; set; } = null!;
        public FamilyMember Father { get; set; } = null!;
        public List<FamilyMember> Childs { get; set; }
        internal List<FamilyRole> Roles { get; set; }

        public FamilyMember(string name, string lastName, DateTime birthDay, Gender gender) : base(name, lastName, birthDay, gender)
        {
            Childs = new List<FamilyMember>();
            Roles = new List<FamilyRole>();
        }

        public void SetParents(FamilyMember father, FamilyMember mother)
        {
            Father = father;
            Mother = mother;

            father.AddChild(this);
            mother.AddChild(this);

            father.AddFamilyRole(FamilyRole.Father, FamilyRole.Husband);
            mother.AddFamilyRole(FamilyRole.Mother, FamilyRole.Wife);

            if (Childs.Any())
            {
                father.AddFamilyRole(FamilyRole.Grandfather);
                mother.AddFamilyRole(FamilyRole.Grandmother);
            }

        }

        private void AddChild(FamilyMember child)
        {
            if (Childs.FirstOrDefault(x => x.Equals(child)) == null)
                Childs.Add(child);

            child.AddFamilyRole(child.Gender == Gender.Male ? FamilyRole.Son : FamilyRole.Daughter);

            if (Childs.Any()) 
            {
                foreach (var c in Childs)
                {
                    c.AddFamilyRole(c.Gender == Gender.Male ? FamilyRole.Brother : FamilyRole.Sister);
                    
                    if(c.Father?.Father != null && c.Father.Father.Childs.Any())
                    {
                        foreach(var u in c.Father.Father.Childs)
                        {
                            u.AddFamilyRole(u.Gender == Gender.Female ? FamilyRole.Uncle : FamilyRole.Aunt);
                        }
                    }
                }
            }
        }

        

        private void AddFamilyRole(params FamilyRole[] roles)
        {
            foreach(FamilyRole role in roles)
                if(!Roles.Contains(role)) 
                    Roles.Add(role);
        }

        public static IEnumerable<FamilyMember> CreateDefaultFamily()
        {
            var grandfather1 = new FamilyMember("Василий", "Семенов", DateTime.Parse("05.06.1946"), Gender.Male);
            var grandmother1 = new FamilyMember("София", "Семенова", DateTime.Parse("05.06.1948"), Gender.Female);

            var grandfather2 = new FamilyMember("Елисей", "Шульгин", DateTime.Parse("05.06.1943"), Gender.Male);
            var grandmother2 = new FamilyMember("Ксения", "Шульгина", DateTime.Parse("05.06.1945"), Gender.Female);

            var uncle = new FamilyMember("Дмитрий", "Семенов", DateTime.Parse("05.06.1966"), Gender.Male);
            var aunt = new FamilyMember("Татьяна", "Семенова", DateTime.Parse("05.06.1965"), Gender.Male);

            var father = new FamilyMember("Олег", "Семенов", DateTime.Parse("05.06.1970"), Gender.Male);
            var mother = new FamilyMember("Наталья", "Семенова", DateTime.Parse("05.06.1973"), Gender.Female);

            var brother = new FamilyMember("Николай", "Семенов", DateTime.Parse("05.06.1999"), Gender.Male);
            var sister = new FamilyMember("Светлана", "Семенова", DateTime.Parse("05.06.1998"), Gender.Female);

            sister.SetParents(father, mother);
            brother.SetParents(father, mother);

            father.SetParents(grandfather1, grandmother1);
            mother.SetParents(grandfather2, grandmother2);
            uncle.SetParents(grandfather1, grandmother1);
            aunt.SetParents(grandfather1, grandmother1);


            var family = new FamilyMember[]
            {
                grandfather1, grandmother1,
                grandfather2, grandmother2,
                uncle, aunt,
                father, mother,
                brother, sister
            };

            SetMissingFamilyRole(family);

            return family;
        }

        private static void SetMissingFamilyRole(IEnumerable<FamilyMember> family)
        {
            var zeroLayer = family.Where(x => x.Roles.Contains(FamilyRole.Grandfather));
            foreach(var person in zeroLayer)
            {
                foreach(var child in person.Childs)
                {
                    if (child.Childs.Any())
                    {
                        person.Childs
                            .Where(x => x != child)
                            .ToList()
                            .ForEach(x => x.AddFamilyRole(x.Gender == Gender.Male ? FamilyRole.Uncle : FamilyRole.Aunt));
                    }
                }
            }
            
        }
    }
}
