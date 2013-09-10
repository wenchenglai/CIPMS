using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPMSBC.ApplicationQuestions
{
    public enum Questions
    {
        Q0003IsFirtTimer = 3,
        Q0006Grade = 6,
        Q0007KindofSchool,
        Q0008SchoolName,
        Q0030WereYouReferredBySynOrJcc = 30,
        Q0031SelectSynaJcc = 31,
        Q1002SynagogueName = 1002,
        Q1040MemberOfYouth = 1040,
        Q1041ParticipateMarchLiving,
        Q1042ParticipateTaglit,
        Q1043BeenToIsrael,
        Q1044ReferByType,
        Q1045ReferBy,
        Q1046TasteOfCamp
    }

    public enum SynagogueJCCOther
    {
        Synagogue = 1,
        Other = 2,
        JCC = 3
    }

    public enum SynagogueMemberDropdown
    {
        RabbiCantor = 1,
        IDoNotRember,
        Other
    }

    public struct QuestionsDelimiters
    {
        public const string QuestionSeparator = "|";
        public const string FieldSeparator = "~";
    }
}
