using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW1.Models;

namespace HW1.Extension
{
    static class Extensions
    {
        public static void PrintFamilyInfo(this IEnumerable<FamilyMember>? family)
        {
            Console.WriteLine("Grandmothers and grandfathers:");
            var grandLyer = family.Where(x =>
                    x.Roles.Contains(FamilyRole.Grandmother) ||
                    x.Roles.Contains(FamilyRole.Grandfather));

            foreach (var g in grandLyer)
                Console.WriteLine("\t" + g.ToString());

            Console.WriteLine();
            Console.WriteLine("Uncles and Aunts:");

            var uncleLyer = family.Where(x =>
                    (x.Roles.Contains(FamilyRole.Uncle) ||
                    x.Roles.Contains(FamilyRole.Aunt)) &&
                    !x.Roles.Contains(FamilyRole.Father) &&
                    !x.Roles.Contains(FamilyRole.Mother));

            foreach (var u in uncleLyer)
                Console.WriteLine("\t" + u.ToString());

            Console.WriteLine();
            Console.WriteLine("Fathers and Mothers:");

            var fatherLyer = family.Where(x =>
                    (x.Roles.Contains(FamilyRole.Father) ||
                    x.Roles.Contains(FamilyRole.Mother)) &&
                    !uncleLyer.Contains(x) &&
                    !grandLyer.Contains(x));

            foreach (var f in fatherLyer)
                Console.WriteLine("\t" + f.ToString());

            Console.WriteLine();
            Console.WriteLine("Childs:");

            var childLyer = family.Where(x =>
                    !uncleLyer.Contains(x) &&
                    !grandLyer.Contains(x) &&
                    !fatherLyer.Contains(x));

            foreach (var c in childLyer)
                Console.WriteLine("\t" + c.ToString());
        }

        public static void PrintTree(this IEnumerable<FamilyMember>? family)
        {
            var grandLyer = family.Where(x =>
                     x.Roles.Contains(FamilyRole.Grandmother) ||
                     x.Roles.Contains(FamilyRole.Grandfather));

            List<FamilyMember> first = new() { grandLyer.First() };
            first.Add(grandLyer.FirstOrDefault(x => x.Childs.Contains(first.First().Childs.FirstOrDefault()) && x != first.First()));

            List<FamilyMember> second = grandLyer.Where(x => !first.Contains(x)).ToList();

            var grandfather = first.FirstOrDefault(x => x.Roles.Contains(FamilyRole.Grandfather));
            var grandmother = first.FirstOrDefault(x => x.Roles.Contains(FamilyRole.Grandmother));

            Console.WriteLine(grandfather.GetFullName()+"\n"+ grandmother.GetFullName());
            Console.WriteLine("\tChilds:");

            foreach (var c in grandfather.Childs)
            {
                PrintChild(c,family);
            }
        }

        private static void PrintChild(FamilyMember familyMember, IEnumerable<FamilyMember>? family, int tab = 2)
        {
            var familyRoles = new List<FamilyRole>();
            if (familyMember.Roles.Contains(FamilyRole.Son)) familyRoles.Add(FamilyRole.Son);
            if (familyMember.Roles.Contains(FamilyRole.Daughter)) familyRoles.Add(FamilyRole.Daughter);
           
            var spouse = family.FirstOrDefault(x => x.Childs.Contains(familyMember.Childs.FirstOrDefault()) && x != familyMember);
            
            var spouseFamilyRoles = new List<FamilyRole>();
            if (spouse != null && spouse.Roles.Contains(FamilyRole.Wife)) spouseFamilyRoles.Add(FamilyRole.Wife);
            if (spouse != null && spouse.Roles.Contains(FamilyRole.Husband)) spouseFamilyRoles.Add(FamilyRole.Husband);

            Console.WriteLine(new string('\t', tab++)+ string.Join(",", familyRoles) + " " + familyMember.GetFullName());
            if (spouse != null)
            Console.WriteLine(new string('\t', tab-1) + string.Join(",", spouseFamilyRoles) + " " + spouse.GetFullName());
            if (familyMember.Childs.Any())
            {
                Console.WriteLine(new string('\t', tab++)+"Childs:");
                foreach(var child in familyMember.Childs)
                {
                    PrintChild(child,family, tab);
                }
            }

        }
    }
}
