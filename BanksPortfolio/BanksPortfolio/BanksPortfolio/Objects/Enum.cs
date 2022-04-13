using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BanksPortfolio.Objects
{
    public class Enum
    {
    }
    public enum eCategories
    {
        [Display(Description = "NONE")]
        NONE = 0,
        [Display(Description = "EXPIRED")]
        EXPIRED = 1,
        [Display(Description = "HIGHRISK")]
        HIGHRISK = 2,
        [Display(Description = "MEDIUMRISK")]
        MEDIUMRISK = 3
    }
}
