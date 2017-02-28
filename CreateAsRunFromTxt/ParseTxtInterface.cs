using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAsRunFromTxt
{
    public enum EventType
    {
        None,
        Primary,
        NonPrimary,
        Unknown
    }
    public enum NonPrimaryEventName
    {
        None,
        CG,
        DVE,
        EXSUB, // External Subtitler
        GPI,
        LOGO,
        ROUTE, // Router Event
        SUB, // Internal Subtitler 
        VO, // Voice Over/Secondary Audio
        VANC, // SCTE-104
        VCHIP,
        Unknown
    }
}
