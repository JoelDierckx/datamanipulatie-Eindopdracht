using models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;

namespace dal
{
    public class CharacterRepository : BaseRepository, ICharacterRepository
    {
        //nodig om characters in te vullen
        private IArticleSubjectRepository articleSubjectRepository = new ArticleSubjectRepository();

        //nodig om puzzles en relaties te deleten als characters verwijdert worden
        private IPuzzleRepository puzzleRepository = new PuzzleRepository();

        private IRelationRepository relationRepository = new Relationrepository();

        public IEnumerable<Character> OphalenCharacters()
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id,ar.tittle
,g.*,m.*
from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
;";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    });

                return invullen.ToList();
            }
        }

        public IEnumerable<Character> OphalenCharactersViaGivesPuzzleAsset(int puzzleassetid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
                        ,ar.id,ar.tittle
                        ,g.*,m.*
                        from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
                         left join Layton.Game as g on g.id = ar.firstGameAppearance
                        left join Layton.Media as m on m.id = ar.logo
                        where c.id in (
                        select p.givenById
                        from Layton.Puzzle as p
                        where p.puzzleAsset = @ID OR p.id = @ID
                        );";
            var parameters = new { @ID = puzzleassetid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Character> OphalenCharactersViaNaamHometownOccupation(string naam, string hometown, string occupation)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven

            //lege string moet ook null matchen
            string namenull = @" where (ar.tittle like '%' + @name + '%'";
            string homenull = @" (c.hometown like '%' + @hometown + '%' ";
            string occupationnull = @" (c.occupation like '%' + @occup + '%' ";

            if (naam == "")
            {
                namenull += @"OR ar.tittle is null";
            }
            if (hometown == "")
            {
                homenull += @"OR c.hometown is null";
            }
            if (occupation == "")
            {
                occupationnull += @"OR c.occupation is null";
            }

            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id,ar.tittle
,g.*,m.*
from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
 left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo" +
namenull + ") and" + homenull + ") and" + occupationnull + ");";

            var parameters = new { @name = naam, @hometown = hometown, @occup = occupation, };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Character> OphalenCharactersViaRelaties(int oorspronkelijkcharacterid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
,ar.id,ar.tittle
,g.*,m.*
from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
 left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
where c.id in (
select r.character2
from Layton.Relation as r
where r.character1 = @ID
)
or c.id in (
select r.character1
from Layton.Relation as r
where r.character2 = @ID
)
;";
            var parameters = new { @ID = oorspronkelijkcharacterid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Character> OphalenCharactersViaSolvesPuzzleAsset(int puzzleassetid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
                        ,ar.id,ar.tittle
                        ,g.*,m.*
                        from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
                         left join Layton.Game as g on g.id = ar.firstGameAppearance
                        left join Layton.Media as m on m.id = ar.logo
                        where c.id in (
                        select p.solvedById
                        from Layton.Puzzle as p
                        where p.puzzleAsset = @ID OR p.id = @ID
                        );";
            var parameters = new { @ID = puzzleassetid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Character> OphalenCharacterViaID(int characterid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select c.id,c.hometown,c.occupation,c.gender,c.essential
                        ,ar.id,ar.tittle
                        ,g.*,m.*
                        from Layton.[Character] as c left join Layton.ArticleSubject as ar on c.articleSubjectId = ar.id
                         left join Layton.Game as g on g.id = ar.firstGameAppearance
                        left join Layton.Media as m on m.id = ar.logo
                        where c.id  = @ID
                        ;";
            var parameters = new { @ID = characterid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var invullen = db.Query<Character, ArticleSubject, Game, Media, Character>(
                    sql, (character, article, game, media) =>
                    {
                        article.logo = media;
                        article.firstGameAppearance = game;
                        character.articleSubjectID = article;
                        return character;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public bool DeleteCharacter(Character character)
        {
            //verwijder verbonden puzzles
            List<Puzzle> puzzlelist = new List<Puzzle>();
            puzzlelist.AddRange(puzzleRepository.OphalenPuzzlesViaGivesPuzzles(Convert.ToInt32(character.ID)));
            puzzlelist.AddRange(puzzleRepository.OphalenPuzzlesViaSolvesPuzzles(Convert.ToInt32(character.ID)));

            foreach (Puzzle item in puzzlelist)
            {
                puzzleRepository.DeletePuzzle(item);
            }
            //verwijder verbonden relaties
            List<Relation> relations = new List<Relation>();
            relations.AddRange(relationRepository.OphalenRelationViaCharacter1en2(Convert.ToInt32(character.ID), -1));
            relations.AddRange(relationRepository.OphalenRelationViaCharacter1en2(-1, Convert.ToInt32(character.ID)));

            foreach (Relation item in relations)
            {
                relationRepository.DeleteRelation(item);
            }

            //verwijder character
            string sql = @"DELETE FROM Layton.[Character]
                            where id = @CHAR;
                           DELETE FROM Layton.Alias
                            where characterId = @CHAR;
                            DELETE FROM Layton.ArticleSubject
                            where id = @ART;
                            ";
            var parameters = new
            {
                @CHAR = character.ID,
                @ART = character.articleSubjectID.Id
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

        public bool InsertCharacter(Character character)
        {
            int rijen;

            //insert article subject
            string sql = @"INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES (@NAME,@MEDIA,@GAME);";

            var parameters = new
            {
                @NAME = character.articleSubjectID.tittle,
                @MEDIA = character.articleSubjectID.logo.Id,
                @GAME = character.articleSubjectID.firstGameAppearance.Id
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                rijen = db.Execute(sql, parameters);
            }

            //insert article mislukt = stoppen
            if (rijen < 1)
            {
                return false;
            }

            //id van article ophalen
            int articleID = articleSubjectRepository.OphalenarticleSubjectIDViaTittleMediaGame(character.articleSubjectID.tittle, Convert.ToInt32(character.articleSubjectID.logo.Id), Convert.ToInt32(character.articleSubjectID.firstGameAppearance.Id));

            //insert character
            string sql2 = @"INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential)
                            VALUES (@ID,@HOME,@OCCUP,@GENDER,@ESS);";

            var parameters2 = new
            {
                @ID = articleID,
                @HOME = character.Hometown,
                @OCCUP = character.Occupation,
                @GENDER = character.Gender,
                @ESS = 0
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen2 = db.Execute(sql2, parameters2);
                if (rijen2 == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateCharacter(Character character)
        {
            string sql = @"UPDATE Layton.ArticleSubject SET tittle = @NAME,logo = @MEDIA ,firstGameAppearance = @GAME
                            WHERE id = @ID";
            var parameters = new
            {
                @NAME = character.articleSubjectID.tittle,
                @MEDIA = character.articleSubjectID.logo.Id,
                @GAME = character.articleSubjectID.firstGameAppearance.Id,
                @ID = character.articleSubjectID.Id
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen != 1)
                {
                    return false;
                }
            }

            string sql2 = @"UPDATE Layton.[Character] SET articleSubjectId = @ARID,hometown = @HOME ,occupation = @OCCUP,gender = @GEN
                            WHERE id = @ID";

            var parameters2 = new
            {
                @ARID = character.articleSubjectID.Id,
                @HOME = character.Hometown,
                @OCCUP = character.Occupation,
                @GEN = character.Gender,
                @ID = character.ID
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql2, parameters2);
                if (rijen == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}