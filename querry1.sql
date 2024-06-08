Select p.id,p.inputType,p.puzzleText,p.solutionOptions,p.solution,p.solutionText,p.picarats
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
;
