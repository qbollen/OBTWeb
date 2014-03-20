using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace ORBITA.Model
{
    public class CollectionBase<T>:Collection<T>
    {
        public CollectionBase() : base(new List<T>()) { }

        public CollectionBase(IList<T> initialList) : base(initialList) { }

    }
}
