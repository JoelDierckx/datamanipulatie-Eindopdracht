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
    public class PuzzleRepository : BaseRepository, IPuzzleRepository
    {
        //nodig om puzzles in te vullen
        private IArticleSubjectRepository articleSubjectRepository = new ArticleSubjectRepository();

        public IEnumerable<Puzzle> OphalenPuzzles()
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
;";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    });

                return invullen.ToList();
            }
        }

        public IEnumerable<Puzzle> OphalenPuzzlesViaGivesPuzzles(int characterid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where c1.id = @ID
;";
            var parameters = new { @ID = characterid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Puzzle> OphalenPuzzlesViaIsPuzzleAsset()
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where p.puzzleAsset is null
;";

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    });

                return invullen.ToList();
            }
        }

        public IEnumerable<Puzzle> OphalenPuzzlesViaNaamPuzzleassetPicarats(string naam, int puzzleassetid, int picarats)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where ar.tittle like '%' + @NAAM + '%' and p.picarats Like @PICA  and (p.puzzleAsset Like @ASSET or p.id Like @ASSET)
;";
            // @asset en @pica moeten % zijn bij lege veldwaarden, lege veldwaarden zijn voor deze operatie -1
            string pica, asset;

            if (picarats == -1)
            {
                pica = "%";
            }
            else
            {
                pica = Convert.ToString(picarats);
            }
            if (puzzleassetid == -1)
            {
                asset = "%";
            }
            else
            {
                asset = Convert.ToString(puzzleassetid);
            }
            var parameters = new { @NAAM = naam, @PICA = pica, @ASSET = asset };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Puzzle> OphalenPuzzlesViaOnvoltooid(int accountid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where p.id not in(
select pa.puzzleId
from Layton.Account as ac left join Layton.PuzzleAccount as pa on ac.id = pa.accountId
where ac.id = @ID and pa.solved = 1
)
;";
            var parameters = new { @ID = accountid };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public IEnumerable<Puzzle> OphalenPuzzlesViaSolvesPuzzles(int characterid)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where c2.id = @ID
;";
            var parameters = new { @ID = characterid };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    }, parameters);

                return invullen.ToList();
            }
        }

        public Puzzle OphalenPuzzleViaID(int id)
        {
            //foreign keys zijn niet nodig om in te vullen; deze zitten ook in de objecten als ze zijn ingevuld,
            //vereist wel dat enkel de nodige kolommen worden uitgeschreven
            string sql = @"Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
,ar.id,ar.tittle
,g.id as 'IdG',g.tittle as 'tittleG',g.Gamecode as 'GamecodeG', m.id as 'IdM',m.[url] as 'UrlM',m.url2 as 'Url2M',m.CharacterBool as 'CharacterBoolM'
,p2.id as 'IDP',p2.inputType as 'InputTypeP',p2.puzzleText as 'PuzzleTextP',p2.solutionOptions as 'SolutionOptionsP',p2.solution as 'SolutionP',p2.solutionText as 'SolutionTextP',p2.picarats as 'picaratsP'
,ar2.id as 'Id1',ar2.tittle as 'tittle1'
,g2.id as 'IdG1',g2.tittle as 'tittleG1',g2.Gamecode as 'GamecodeG1', m2.id as 'IdM1',m2.[url] as 'UrlM1',m2.url2 as 'Url2M1',m2.CharacterBool as 'CharacterBoolM1'
,ac.id as 'IDA',ac.[name] as 'nameA',ac.refID as 'RefIdA'
,c1.id as 'IDC',c1.hometown as 'HometownC',c1.occupation as 'OccupationC',c1.gender as 'GenderC',c1.essential as 'EssentialC'
,arc.id as 'Id2',arc.tittle as 'tittle2'
,gc.id as 'IdG2',gc.tittle as 'tittleG2',gc.Gamecode as 'GamecodeG2', mc.id as 'IdM2',mc.[url] as 'UrlM2',mc.url2 as 'Url2M2',mc.CharacterBool as 'CharacterBoolM2'
,c2.id as 'IDC2',c2.hometown as 'HometownC2',c2.occupation as 'OccupationC2',c2.gender as 'GenderC2',c2.essential as 'EssentialC2'
,arc2.id as 'Id3',arc2.tittle as 'tittle3'
,gc2.id as 'IdG3',gc2.tittle as 'tittleG3',gc2.Gamecode as 'GamecodeG3', mc2.id as 'IdM3',mc2.[url] as 'UrlM3',mc2.url2 as 'Url2M3',mc2.CharacterBool as 'CharacterBoolM3'
from Layton.Puzzle as p left join Layton.ArticleSubject as ar on p.articleSubjectId = ar.id
left join Layton.Game as g on g.id = ar.firstGameAppearance
left join Layton.Media as m on m.id = ar.logo
left join Layton.Puzzle as p2 on p2.id = p.puzzleAsset
left join Layton.ArticleSubject as ar2 on ar2.id = p2.articleSubjectId
left join Layton.Game as g2 on g2.id = ar2.firstGameAppearance
left join Layton.Media as m2 on m2.id = ar2.logo
left join Layton.Account as ac on ac.id = p.madeById
left join Layton.[Character] as c1 on c1.id = p.givenById
left join Layton.ArticleSubject as arc on c1.articleSubjectId = arc.id
left join Layton.Game as gc on gc.id = arc.firstGameAppearance
left join Layton.Media as mc on mc.id = arc.logo
left join Layton.[Character] as c2 on c2.id = p.solvedById
left join Layton.ArticleSubject as arc2 on c2.articleSubjectId = arc2.id
left join Layton.Game as gc2 on gc2.id = arc2.firstGameAppearance
left join Layton.Media as mc2 on mc2.id = arc2.logo
where p.id = @ID
;";
            var parameters = new { @ID = id };
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                //dapper kan maar x aantal classen als input mapping nemen, tussenklasse puzzlemapper dient om dit te overkomen
                var invullen = db.Query<Puzzle, Puzzlemapper, Puzzle>(
                    sql, (puzzle, mapper) =>
                    {
                        Puzzle puzzle2 = MappingOperatiePuzzle(puzzle, mapper);

                        return puzzle2;
                    }, parameters);

                // één object teruggeven; querySingleOrDefault werkt niet met de huidige opstelling
                var invullen2 = invullen.ToList();

                if (invullen2.Count >= 1)
                {
                    return invullen2[0];
                }
                else
                {
                    return null;
                }
            }
        }

        //mapping function voor puzzles
        public Puzzle MappingOperatiePuzzle(Puzzle puzzle, Puzzlemapper mapper)
        {
            // indidvidueel aanmaken objecten
            Game game = new Game();
            game.Id = mapper.IdG;
            game.tittle = mapper.tittleG;
            game.Gamecode = mapper.GamecodeG;

            Game gamep = new Game();
            gamep.Id = mapper.IdG1;
            gamep.tittle = mapper.tittleG1;
            gamep.Gamecode = mapper.GamecodeG1;

            Game gamec = new Game();
            gamec.Id = mapper.IdG2;
            gamec.tittle = mapper.tittleG2;
            gamec.Gamecode = mapper.GamecodeG2;

            Game gamec2 = new Game();
            gamec2.Id = mapper.IdG3;
            gamec2.tittle = mapper.tittleG3;
            gamec2.Gamecode = mapper.GamecodeG3;

            Media media = new Media();
            media.Id = mapper.IdM;
            media.Url = mapper.UrlM;
            media.Url2 = mapper.Url2M;
            media.CharacterBool = mapper.CharacterBoolM;

            Media mediap = new Media();
            mediap.Id = mapper.IdM1;
            mediap.Url = mapper.UrlM1;
            mediap.Url2 = mapper.Url2M1;
            mediap.CharacterBool = mapper.CharacterBoolM1;

            Media mediac = new Media();
            mediac.Id = mapper.IdM2;
            mediac.Url = mapper.UrlM2;
            mediac.Url2 = mapper.Url2M2;
            mediac.CharacterBool = mapper.CharacterBoolM2;

            Media mediac2 = new Media();
            mediac2.Id = mapper.IdM3;
            mediac2.Url = mapper.UrlM3;
            mediac2.Url2 = mapper.Url2M3;
            mediac2.CharacterBool = mapper.CharacterBoolM3;

            ArticleSubject articleSubject = new ArticleSubject();
            articleSubject.Id = mapper.Id;
            articleSubject.tittle = mapper.tittle;
            articleSubject.logo = media;
            articleSubject.firstGameAppearance = game;

            ArticleSubject articleSubject2 = new ArticleSubject();
            articleSubject2.Id = mapper.Id1;
            articleSubject2.tittle = mapper.tittle1;
            articleSubject2.logo = mediap;
            articleSubject2.firstGameAppearance = gamep;

            ArticleSubject articleSubjectc = new ArticleSubject();
            articleSubjectc.Id = mapper.Id2;
            articleSubjectc.tittle = mapper.tittle2;
            articleSubjectc.logo = mediac;
            articleSubjectc.firstGameAppearance = gamec;

            ArticleSubject articleSubjectc2 = new ArticleSubject();
            articleSubjectc2.Id = mapper.Id3;
            articleSubjectc2.tittle = mapper.tittle3;
            articleSubjectc2.logo = mediac2;
            articleSubjectc2.firstGameAppearance = gamec2;

            Puzzle puzzle2 = new Puzzle();
            puzzle2.ID = mapper.IDP;
            puzzle2.InputType = mapper.InputTypeP;
            puzzle2.PuzzleText = mapper.PuzzleTextP;
            puzzle2.SolutionOptions = mapper.SolutionOptionsP;
            puzzle2.Solution = mapper.SolutionP;
            puzzle2.SolutionText = mapper.SolutionTextP;
            puzzle2.picarats = mapper.picaratsP;
            puzzle2.ArticleSubjectId = articleSubject2;

            Account account = new Account();
            account.ID = mapper.IDA;
            account.name = mapper.nameA;
            account.RefId = mapper.RefIdA;

            Character character1 = new Character();
            character1.ID = mapper.IDC;
            character1.Hometown = mapper.HometownC;
            character1.Occupation = mapper.OccupationC;
            character1.Gender = mapper.GenderC;
            character1.Essential = mapper.EssentialC;
            character1.articleSubjectID = articleSubjectc;

            Character character2 = new Character();
            character2.ID = mapper.IDC2;
            character2.Hometown = mapper.HometownC2;
            character2.Occupation = mapper.OccupationC2;
            character2.Gender = mapper.GenderC2;
            character2.Essential = mapper.EssentialC2;
            character2.articleSubjectID = articleSubjectc2;

            puzzle.ArticleSubjectId = articleSubject;
            puzzle.PuzzleAsset = puzzle2;
            puzzle.GivenById = character1;
            puzzle.SolvedById = character2;
            puzzle.MadeByID = account;

            return puzzle;
        }

        public bool DeletePuzzle(Puzzle puzzle)
        {
            string sql = @"DELETE FROM Layton.Puzzle
                            where id = @PUZ;
                           DELETE FROM Layton.PuzzleAccount
                            where puzzleId = @PUZ;
                            DELETE FROM Layton.ArticleSubject
                            where id = @ART;
                            ";
            var parameters = new
            {
                @PUZ = puzzle.ID,
                @ART = puzzle.ArticleSubjectId.Id
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

        public bool InsertPuzzle(Puzzle puzzle)
        {
            int rijen;

            //insert article subject
            string sql = @"INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES (@NAME,@MEDIA,@GAME);";

            var parameters = new
            {
                @NAME = puzzle.ArticleSubjectId.tittle,
                @MEDIA = puzzle.ArticleSubjectId.logo.Id,
                @GAME = puzzle.ArticleSubjectId.firstGameAppearance.Id
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
            int articleID = articleSubjectRepository.OphalenarticleSubjectIDViaTittleMediaGame(puzzle.ArticleSubjectId.tittle, Convert.ToInt32(puzzle.ArticleSubjectId.logo.Id), Convert.ToInt32(puzzle.ArticleSubjectId.firstGameAppearance.Id));

            //insert character
            string sql2 = @"INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,picarats,givenById,solvedById,madeById,inputType)
                            VALUES (@PUZ,@ART,@PIC,@GIV,@SOL,@MAD,@INP);";

            var parameters2 = new
            {
                @PUZ = puzzle.PuzzleAsset.ID,
                @ART = articleID,
                @PIC = puzzle.picarats,
                @GIV = puzzle.GivenById.ID,
                @SOL = puzzle.SolvedById.ID,
                @MAD = puzzle.MadeByID.ID,
                @INP = puzzle.PuzzleAsset.InputType
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

        public bool UpdatePuzzle(Puzzle puzzle)
        {
            string sql = @"UPDATE Layton.ArticleSubject SET tittle = @NAME,logo = @MEDIA ,firstGameAppearance = @GAME
                            WHERE id = @ID";
            var parameters = new
            {
                @NAME = puzzle.ArticleSubjectId.tittle,
                @MEDIA = puzzle.ArticleSubjectId.logo.Id,
                @GAME = puzzle.ArticleSubjectId.firstGameAppearance.Id,
                @ID = puzzle.ArticleSubjectId.Id
            };

            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var rijen = db.Execute(sql, parameters);
                if (rijen != 1)
                {
                    return false;
                }
            }

            string sql2 = @"UPDATE Layton.Puzzle SET puzzleAsset= @PUZ,articleSubjectId = @ARID,picarats = @PIC ,givenById = @GIV,solvedById = @SOL,madeById = @MAD
                            WHERE id = @ID";

            var parameters2 = new
            {
                @ARID = puzzle.ArticleSubjectId.Id,
                @PUZ = puzzle.PuzzleAsset.ID,
                @PIC = puzzle.picarats,
                @GIV = puzzle.GivenById.ID,
                @SOL = puzzle.SolvedById.ID,
                @MAD = puzzle.MadeByID.ID,
                @ID = puzzle.ID
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