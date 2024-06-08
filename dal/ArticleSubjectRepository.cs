using models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace dal
{
    public class ArticleSubjectRepository : BaseRepository, IArticleSubjectRepository
    {
        public int OphalenarticleSubjectIDViaTittleMediaGame(string tittle, int mediaid, int gameid)
        {
            string sql = @"Select ar.id,ar.tittle,m.*,g.*
                        from Layton.ArticleSubject as ar left join Layton.Media as m on m.id = ar.logo
                        left join Layton.Game as g on g.id = ar.firstGameAppearance
                        where ar.tittle like @TITLE and g.id = @GAME and m.id = @MEDIA
                        ;";
            var parameters = new { @TITLE = tittle, @GAME = gameid, @MEDIA = mediaid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<ArticleSubject, Media, Game, ArticleSubject>(
                    sql, (article, media, game) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        return article;
                    }, parameters);
                List<ArticleSubject> invullen2 = invullen.ToList();

                int id = Convert.ToInt32(invullen2[invullen2.Count() - 1].Id);

                return id;
            }
        }
    }
}