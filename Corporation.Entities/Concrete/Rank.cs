using Corporation.Core.Abstract;
using System;

namespace Corporation.Core.Concrete
{
    public class Rank : IEntity
    {
        public int RankId { get; set; }
        public string RankName { get; set; }

        public override string ToString() =>
            $"{RankId,-5} {RankName,-35}";
    }
}
