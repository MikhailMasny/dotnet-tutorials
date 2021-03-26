using System.Collections.Generic;

namespace Masny.DotNet.Crud.Models
{
    public class ParentModel
    {
        public int Id { get; set; }

        public string StringVar { get; set; }


        /// <summary>
        /// Navigation to ChildModels.
        /// </summary>
        public ICollection<ChildModel> ChildModels { get; set; }
    }
}
