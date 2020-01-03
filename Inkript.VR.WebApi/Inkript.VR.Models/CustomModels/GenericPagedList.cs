using System.Collections.Generic;

namespace Inkript.VR.Models
{
    public class GenericPagedList<T>
    {
        public virtual int TotalRows { get; set; }
        public virtual IList<T> PagedList { get; set; }

        public GenericPagedList()
        {
            TotalRows = 0;
            PagedList = new List<T>();
        }

        public GenericPagedList(int totalRows, IList<T> result)
        {
            TotalRows = totalRows;
            PagedList = result;
        }
    }
}
