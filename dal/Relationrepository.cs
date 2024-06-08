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
    public class Relationrepository : BaseRepository, IRelationRepository
    {
        public IEnumerable<Relation> OphalenRelations()
        {
            string sql = @"Select r.id,rt.*
,c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id as 'IdA',ar.tittle as 'tittleA'
,m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG'
,c1.id,c1.hometown,c1.occupation,c1.gender,c1.essential
,ar1.id as 'IdA',ar1.tittle as 'tittleA'
,m1.id as 'IdM',m1.[url] as 'UrlM',m1.url2 as 'Url2M',m1.CharacterBool as 'CharacterBoolM'
,g1.id as 'IdG',g1.tittle as 'tittleG',g1.Gamecode as 'GamecodeG'
from Layton.Relation as r left join Layton.Relationtype as rt on r.relationtype = rt.id
left join Layton.Character as c on r.character1 = c.id
left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Character as c1 on r.character2 = c1.id
left join Layton.ArticleSubject as ar1 on c1.articleSubjectId = ar1.id
left join Layton.Game as g1 on g1.id = ar1.firstGameAppearance
left join Layton.Media as m1 on m1.id = ar1.logo
;";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Relation, Relationtype, Charactermapper, Charactermapper, Relation>(
                    sql, (relation, relationtype, char1, char2) =>
                    {
                        Relation relation2 = MappingopperatieRelation(relation, relationtype, char1, char2);
                        return relation2;
                    });

                return invullen.ToList();
            }
        }

        public IEnumerable<Relation> OphalenRelationViaCharacter1en2(int char1id, int char2id)
        {
            string sql = @"Select r.id,rt.*
,c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id as 'IdA',ar.tittle as 'tittleA'
,m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG'
,c1.id,c1.hometown,c1.occupation,c1.gender,c1.essential
,ar1.id as 'IdA',ar1.tittle as 'tittleA'
,m1.id as 'IdM',m1.[url] as 'UrlM',m1.url2 as 'Url2M',m1.CharacterBool as 'CharacterBoolM'
,g1.id as 'IdG',g1.tittle as 'tittleG',g1.Gamecode as 'GamecodeG'
from Layton.Relation as r left join Layton.Relationtype as rt on r.relationtype = rt.id
left join Layton.Character as c on r.character1 = c.id
left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Character as c1 on r.character2 = c1.id
left join Layton.ArticleSubject as ar1 on c1.articleSubjectId = ar1.id
left join Layton.Game as g1 on g1.id = ar1.firstGameAppearance
left join Layton.Media as m1 on m1.id = ar1.logo
where c.id Like @ID1 and c1.id Like @ID2
;";

            // @ID1 en @ID2 moeten % zijn bij lege veldwaarden, lege veldwaarden zijn voor deze operatie -1
            string id1, id2;

            if (char1id == -1)
            {
                id1 = "%";
            }
            else
            {
                id1 = Convert.ToString(char1id);
            }
            if (char2id == -1)
            {
                id2 = "%";
            }
            else
            {
                id2 = Convert.ToString(char2id);
            }
            var parameters = new { @ID1 = id1, @ID2 = id2 };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Relation, Relationtype, Charactermapper, Charactermapper, Relation>(
                    sql, (relation, relationtype, char1, char2) =>
                    {
                        Relation relation2 = MappingopperatieRelation(relation, relationtype, char1, char2);
                        return relation2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Relation> OphalenRelationViaCharacter1en2RelationType(int char1id, int char2id, int relationid)
        {
            string sql = @"Select r.id,rt.*
,c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id as 'IdA',ar.tittle as 'tittleA'
,m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG'
,c1.id,c1.hometown,c1.occupation,c1.gender,c1.essential
,ar1.id as 'IdA',ar1.tittle as 'tittleA'
,m1.id as 'IdM',m1.[url] as 'UrlM',m1.url2 as 'Url2M',m1.CharacterBool as 'CharacterBoolM'
,g1.id as 'IdG',g1.tittle as 'tittleG',g1.Gamecode as 'GamecodeG'
from Layton.Relation as r left join Layton.Relationtype as rt on r.relationtype = rt.id
left join Layton.Character as c on r.character1 = c.id
left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Character as c1 on r.character2 = c1.id
left join Layton.ArticleSubject as ar1 on c1.articleSubjectId = ar1.id
left join Layton.Game as g1 on g1.id = ar1.firstGameAppearance
left join Layton.Media as m1 on m1.id = ar1.logo
where c.id Like @ID1 and c1.id Like @ID2 and rt.id Like @RT
;";

            // @ID1, @ID2 en @RT moeten % zijn bij lege veldwaarden, lege veldwaarden zijn voor deze operatie -1
            string id1, id2, rt;

            if (char1id == -1)
            {
                id1 = "%";
            }
            else
            {
                id1 = Convert.ToString(char1id);
            }
            if (char2id == -1)
            {
                id2 = "%";
            }
            else
            {
                id2 = Convert.ToString(char2id);
            }
            if (relationid == -1)
            {
                rt = "%";
            }
            else
            {
                rt = Convert.ToString(relationid);
            }
            var parameters = new { @ID1 = id1, @ID2 = id2, @RT = rt };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Relation, Relationtype, Charactermapper, Charactermapper, Relation>(
                    sql, (relation, relationtype, char1, char2) =>
                    {
                        Relation relation2 = MappingopperatieRelation(relation, relationtype, char1, char2);
                        return relation2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        private Relation MappingopperatieRelation(Relation relation, Relationtype relationtype, Charactermapper char1, Charactermapper char2)
        {
            //char1
            Game game = new Game();
            game.Id = char1.IdG;
            game.tittle = char1.tittleG;
            game.Gamecode = char1.GamecodeG;

            Media media = new Media();
            media.Id = char1.IdM;
            media.Url = char1.UrlM;
            media.Url2 = char1.Url2M;
            media.CharacterBool = char1.CharacterBoolM;

            ArticleSubject article = new ArticleSubject();
            article.Id = char1.IdA;
            article.tittle = char1.tittleA;
            article.logo = media;
            article.firstGameAppearance = game;

            Character character1 = new Character();
            character1.ID = char1.id;
            character1.Hometown = char1.Hometown;
            character1.Occupation = char1.Occupation;
            character1.Gender = char1.Gender;
            character1.Essential = char1.Essential;
            character1.articleSubjectID = article;

            //char2
            Game game1 = new Game();
            game1.Id = char2.IdG;
            game1.tittle = char2.tittleG;
            game1.Gamecode = char2.GamecodeG;

            Media media1 = new Media();
            media1.Id = char2.IdM;
            media1.Url = char2.UrlM;
            media1.Url2 = char2.Url2M;
            media1.CharacterBool = char2.CharacterBoolM;

            ArticleSubject article1 = new ArticleSubject();
            article1.Id = char2.IdA;
            article1.tittle = char2.tittleA;
            article1.logo = media1;
            article1.firstGameAppearance = game1;

            Character character12 = new Character();
            character12.ID = char2.id;
            character12.Hometown = char2.Hometown;
            character12.Occupation = char2.Occupation;
            character12.Gender = char2.Gender;
            character12.Essential = char2.Essential;
            character12.articleSubjectID = article1;

            relation.character1 = character1;
            relation.character2 = character12;
            relation.Relationtype = relationtype;

            return relation;
        }

        public bool DeleteRelation(Relation relation)
        {
            string sql = @"DELETE FROM Layton.Relation
                            where id = @ID;";
            var parameters = new
            {
                @ID = relation.ID,
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen >= 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool InsertRelation(Relation relation)
        {
            string sql = @"INSERT INTO Layton.Relation (character1,character2,relationtype)
                            VALUES (@C1,@C2,@RT);";

            var parameters = new
            {
                @C1 = relation.character1.ID,
                @C2 = relation.character2.ID,
                @RT = relation.Relationtype.ID
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateRelation(Relation relation)
        {
            string sql = @"UPDATE Layton.Relation SET character1 = @C1,character2 = @C2 ,relationtype = @RT
                            WHERE id = @ID";

            var parameters = new
            {
                @C1 = relation.character1.ID,
                @C2 = relation.character2.ID,
                @RT = relation.Relationtype.ID,
                @ID = relation.ID
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}