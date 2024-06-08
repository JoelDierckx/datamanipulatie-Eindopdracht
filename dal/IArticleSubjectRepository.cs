using System;
using System.Collections.Generic;
using System.Text;

namespace dal
{
    public interface IArticleSubjectRepository
    {
        public int OphalenarticleSubjectIDViaTittleMediaGame(string tittle, int mediaid, int gameid);
    }
}