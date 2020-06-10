using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Base
{
    public interface IBaseModel
    {

    }
    public abstract class BaseModel : IBaseModel
    {
        public BaseModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
