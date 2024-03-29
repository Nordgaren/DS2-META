﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DS2_META
{
    internal class DS2ItemCategory
    {
        public string Name;
        public List<DS2Item> Items;

        private static Regex ItemEntryRx = new Regex(@"^(?<id>\S+) (?<show>\S+) (?<path>\S+) (?<name>.+)$");
        private DS2ItemCategory(string name, int type, string itemList, bool showIDs)
        {
            Name = name;
            Items = new List<DS2Item>();
            foreach (string line in GetTxtResourceClass.RegexSplit(itemList, "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                    Items.Add(new DS2Item(line, type, showIDs));
            };
            Items.Sort();
        }
        private DS2ItemCategory(string config)
        {
            Match itemEntry = ItemEntryRx.Match(config);
            Name = itemEntry.Groups["name"].Value;
            Items = new List<DS2Item>();
            foreach (string line in GetTxtResourceClass.RegexSplit(GetTxtResourceClass.GetTxtResource(itemEntry.Groups["path"].Value), "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                    Items.Add(new DS2Item(line, Convert.ToInt32(itemEntry.Groups["id"].Value), bool.Parse(itemEntry.Groups["show"].Value)));
            };
            Items.Sort();
        }
        public override string ToString()
        {
            return Name;
        }
        static DS2ItemCategory()
        {
            foreach (string line in GetTxtResourceClass.RegexSplit(GetTxtResourceClass.GetTxtResource("Resources/Equipment/DS2ItemCategories.txt"), "[\r\n]+"))
            {
                if (GetTxtResourceClass.IsValidTxtResource(line)) //determine if line is a valid resource or not
                    All.Add(new DS2ItemCategory(line));
            };
        }

        public static List<DS2ItemCategory> All = new List<DS2ItemCategory>();
    }
}
