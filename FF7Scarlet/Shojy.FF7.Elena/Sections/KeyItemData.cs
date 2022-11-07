using Shojy.FF7.Elena.Items;
using System.Collections.Generic;

namespace Shojy.FF7.Elena.Sections
{
    public class KeyItemData
    {
        #region Public Constructors

        public KeyItemData(IReadOnlyList<string> names, IReadOnlyList<string> descriptions)
        {
            var items = new List<KeyItem>();
            for (var i = 0; i < names.Count; ++i)
            {
                var item = new KeyItem
                {
                    Index = i,
                    Name = names[i],
                    Description = descriptions[i]
                };

                items.Add(item);
            }

            this.KeyItems = items.ToArray();
        }

        #endregion Public Constructors

        #region Public Properties

        public KeyItem[] KeyItems { get; }

        #endregion Public Properties
    }
}