--delete bestaande data
DELETE FROM  Layton.Relation;
IF (IDENT_CURRENT('Layton.Relation') = 1) BEGIN DBCC checkident('Layton.Relation', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Relation', reseed,0);END;
DELETE FROM  Layton.Relationtype;
IF (IDENT_CURRENT('Layton.Relationtype') = 1) BEGIN DBCC checkident('Layton.Relationtype', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Relationtype', reseed,0);END;
DELETE FROM  Layton.Alias;
IF (IDENT_CURRENT('Layton.Alias') = 1) BEGIN DBCC checkident('Layton.Alias', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Alias', reseed,0);END;
DELETE FROM  Layton.PuzzleAccount;
IF (IDENT_CURRENT('Layton.PuzzleAccount') = 1) BEGIN DBCC checkident('Layton.PuzzleAccount', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.PuzzleAccount', reseed,0);END;
DELETE FROM  Layton.Hint;
IF (IDENT_CURRENT('Layton.Hint') = 1) BEGIN DBCC checkident('Layton.Hint', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Hint', reseed,0);END;
DELETE FROM  Layton.Puzzle;
IF (IDENT_CURRENT('Layton.Puzzle') = 1) BEGIN DBCC checkident('Layton.Puzzle', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Puzzle', reseed,0);END;
DELETE FROM  Layton.[Character];
IF (IDENT_CURRENT('Layton.[Character]') = 1) BEGIN DBCC checkident('Layton.[Character]', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.[Character]', reseed,0);END;
DELETE FROM  Layton.ArticleSubject;
IF (IDENT_CURRENT('Layton.ArticleSubject') = 1) BEGIN DBCC checkident('Layton.ArticleSubject', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.ArticleSubject', reseed,0);END;
DELETE FROM  Layton.Media;
IF (IDENT_CURRENT('Layton.Media') = 1) BEGIN DBCC checkident('Layton.Media', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Media', reseed,0);END;
DELETE FROM  Layton.Game;
IF (IDENT_CURRENT('Layton.Game') = 1) BEGIN DBCC checkident('Layton.Game', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Game', reseed,0);END;
DELETE FROM  Layton.Account;
IF (IDENT_CURRENT('Layton.Account') = 1) BEGIN DBCC checkident('Layton.Account', reseed,1);END
ELSE BEGIN DBCC checkident('Layton.Account', reseed,0);END;
Go

INSERT INTO Layton.Account (name,refID) VALUES ('Defaultname',1);

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Spectre''s Call','SC');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Eternal Diva','ED');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Miracle Mask','MM');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Azran Legacy','AL');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Curious Village','CV');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Diabolical Box','DB');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton vs. Phoenix Wright: Ace Attorney','VS');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Professor Layton and the Lost Future','LF');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Layton Brothers: Mystery Room','LBMR');

INSERT INTO Layton.Game (tittle,Gamecode) VALUES ('Layton''s Mystery Journey: Katrielle and the Millionaires'' Conspiracy','MC');

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/HershelLayton.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/LukeTriton.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Flora_Reinhold.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/EmmyAL.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Chelmey.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Don.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/FutureLuke.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Barton.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Granny_R.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Delmona.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('empty','',0);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/ClampGrosky.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Anthony_Herzen_PP_DB.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Jeandescole.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Bronev.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Aldus.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Keats.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Raymond.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Stachen.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Janice.png','',1);

INSERT INTO Layton.Media ([url],[url2],characterBool) VALUES ('https://www.joel-entertainment.be/afbeeldingen/img/Amelia_Ruth_PP_ED.png','',1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Professor Hershel Layton',1,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Luke Triton',2,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Flora Reinhold',3,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Emmy Altava',4,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Inspector Chelmey',5,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Don Paolo',6,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Clive',7,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Barton',8,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Granny Riddleton',9,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Dean Delmona',10,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Five Suspects',11,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Mysterious Note',12,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Shoe Shop Thief',13,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Chelmey''s Route',14,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('A Secure Room',15,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Fingerprint',16,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Secret Letter',17,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Bricks ''n'' Bullion',18,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Where''s the Village?',19,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Third Youngest',20,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Final Tile',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Medicine Time',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Puzzling Legend',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Ladder Puzzle',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Five-Card Shuffle',NULL,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('The Lazy Guard',NULL,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Clock the Tower',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('How Many Turns?',NULL,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Park the Car',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Four Cross the River',NULL,8);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Inspector Clamp Grosky',21,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Anthony�Herzen',22,6);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Jean Descole',23,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Leon Bronev',24,3);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Aldus',25,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Keats',26,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Raymond',27,1);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Stachenscarfen',28,5);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Janice Quatlane',29,2);

INSERT INTO Layton.ArticleSubject (tittle,logo,firstGameAppearance) VALUES ('Amelia Ruth',30,2);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (1,'London','Professor of archaeology','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (2,'London','Apprentice of�Hershel Layton','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (3,'St Mystere','Prot�g� of�Hershel Layton','female',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (4,'London','Journalist for�World Times','female',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (5,'London','Scotland Yard�Inspector','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (31,'Folsense','Scotland Yard�Inspector','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (6,'London','Scientist','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (32,'Folsense','Duke of Folsense','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (7,'London','Former Journalist','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (33,'Misthallery','Scientist','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (34,'London','Head of�Targent','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (35,'Misthallery','Cat','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (8,'London','Police Constable','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (10,'London','Dean of�Gressenheller University','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (9,'St Mystere','Puzzle Keeper','female',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (36,'St Mystere','Puzzle Keeper','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (37,'Misthallery','Jean Descole''s�Butler','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (38,'St Mystere','Picarat Keeper','male',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (39,'London','Opera singer','female',1);

INSERT INTO Layton.[Character] (articleSubjectId,hometown,occupation,gender,essential) VALUES (40,'London','School student','female',1);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,11,'Write Answer','"Five suspects are called into police headquarters for questioning. They give the following statements.
A: ""One of the five of us is lying.""
B: ""Two of the five of us are lying.""
C: ""I know these guys, and three of the five of us are lying.""
D: ""Don''t listen to a word they say. Out of the five of us, four are lying.""
E: ""All five of us are dirty rotten liars!""

The police only want to release the suspects who are telling the truth. How many people should they let go?"','Multiple of','#1','"That''s right!

Every suspect accused a different number of people. If anyone was telling the truth, it had to be one suspect, no more or less.

The only suspect whose statement fits that condition is D. It looks like he''s a free man now."',20,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,12,'Multiple Choice','"A detective who was mere days from cracking an international smuggling ring has suddenly gone missing. While inspecting his last-known location, you find a note.

The note appears to be nothing more than a series of numbers, but your gut instinct tells you that this note will reveal the name of the crime kingpin.

Currently there are three suspects in the case: Bill, John, and Todd. Can you break the detective''s code and find the criminal''s name?"','Multiple of','#1','"That''s right!

If you flip the note upside down, you''ll notice that the numbers resemble letters and that those letters form legible sentences. The message recorded there is ""Bill is boss. He sells oil.""

If you flip the note upside down, you''ll notice that the numbers resemble letters and that those letters form legible sentences. The message recorded there is ""Bill is boss. He sells oil."""',40,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,13,'Write Answer','"A woman in a shoe shop pays for a �30 pair of shoes with a �50 note. The salesman doesn''t have enough change, so he goes to the shop next door to break the �50 note, returns to his shop and gives the woman her change. A while later, the shopkeeper from next door storms into the shoe shop. It turns out that the note he gave her was a fake! The mortified shoe salesman gives the shopkeeper �50 from the till to apologise. Neither the customer nor the shoes she took are found.

In total, how much did the shoe shop lose?"','Multiple of','#1','"The shoes the customer made off with cost �30, and the change the salesman gave her cost him another �20, bringing his total losses to �50.

The salesman received �50 of real money in exchange for the fake note from the shopkeeper next door, and then gave her �50 back when she discovered the note he gave her was fake. These last two transactions cancel each other out."',25,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,14,'Draw Line','"""I took a few turns, but only one at a junction that had a cafe on it. I also passed in front of one hat shop. Oh, and one flower shop too. And I didn''t walk any farther than necessary.""

Now that you''ve heard his recollection, can you trace the route the inspector took through town?"','Multiple of','#1','You may have worked out the inspector''s path through town, but the search for those photo scraps is just beginning.',35,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,15,'Circle Answer','"Given that the doctor''s flat is on the eighth floor and that the door was securely locked, you might think that there was no way in or out of this room. However, a single suspicious detail provides a clue as to what went on here.

Look in all four directions and examine the room carefully. When you think you''ve found the tell-tale detail, circle it with the stylus and touch Submit. Be sure to circle only one object, or else your answer won''t count!"','Multiple of','#1','"Well spotted!

For some reason, part of the curtain has been ripped clean off! What could have happened here?"',30,5,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,16,'Tap Answer','"A fingerprint has been discovered at the scene of an unsolved crime!

Four suspects have been rounded up and brought into the station.

Compare the fingers of suspects A, B, C and D with the fingerprint shown beneath the magnifying glass to identify the culprit."','Multiple of','#1','"Suspect A is your culprit.

At first glance, B looks like a possible match, but the print left at the scene is a mirror image of the culprit''s finger."',15,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,17,'Circle Answer','"You receive a letter that says:
""The room in this photograph hides a secret. Remove one of the floor tiles to reveal the hidden treasure.""

In the same envelope as the letter is the photograph shown below, with the following note on the back:
""Follow the arrow to where the treasure lies...""

Which tile do you need to remove in order to find the treasure? Circle your answer."','Multiple of','#1','"That''s right!

The nose and mouth of the monkey in the picture on the wall combine to form an arrow shape. The treasure can be found under the floor tile directly beneath this arrow."',60,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,18,'Arrange','"A rowdy band of thieves are about to be apprehended and need to stash their swag according to their boss''s orders:

""Right, lads, these ''ere 10 bars o'' gold''ll fit right into that there brick wall. Nobody''ll be none the wiser! We''ll stash ''em ''ere ''til the ''eat dies down.
Oh, I almost forgot the important part: don''t go puttin'' any bigger bars on top of any smaller ones. Sound like a plan, lads?""

Place the gold bars into the wall to complete the boss''s orders!"','Multiple of','#1','What a clever way to hide the bullion! That boss is a criminal genius!',50,5,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,19,'Circle Answer','"""My village is on a road that leads to no other village. I look forward to seeing you there.""

Use your stylus to draw a circle around the right village, then touch Submit."','Multiple of','#1','"The only village that isn''t connected by roads to another village is the one in the upper-left area of the map.

It looks like you''re all ready to start solving puzzles!"',10,1,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,20,'Tap Answer','"""10 close brothers and sisters live together. Now Luke, let''s imagine that you''re the eighth child.
The oldest daughter is the second son''s younger sister and the third son''s older sister. The fourth son is the second daughter''s older brother and the oldest daughter''s younger brother. There are no boys in between the third and fourth daughters.
Is the third child from the bottom a boy or a girl?""
""I can''t tell just from this!""
Let''s tell Luke the answer in secret."','Multiple of','#1','"That''s right!

It''s a boy.

""I told you at the beginning, Luke:
""Let''s imagine that you''re the eighth child.""

My question was asking about the third child from the bottom, or in other words, the eighth oldest child. That eighth child was you, Luke, and I know better than anyone that you''re a boy!"""',25,9,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,21,'Select','"The floor below is made up of 24 tiles. It''s specially designed so that the tiles will fall away in a path, one by one, until they''re all gone.

Once the first tile falls, an adjacent tile falls, then one next to that and so on, following this order of suits: hearts, spades, diamonds, clubs. The first tile to fall, however, is not necessarily a heart.

If you can find the tile that will fall last, you can stop this floor from disappearing! Touch the last tile and then touch Submit."','Multiple of','#1','"Bingo!

Very impressive work!"',70,9,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,22,'Draw Line','"Dr Schrader needs to drink one fifth of this bottle of medicine per day over a period of five days. Unfortunately, the dosages aren''t marked on the bottle.

Dr Schrader has taken the first dose, and the amount of medicine in the bottle has been reduced to the level shown in the diagram. It''s now time for the second dose.

To where should be drink today? Draw a line on the bottle to mark the point which he should stop drinking."','Multiple of','#1','"You can rotate the bottle left or right and get the same result. Just make sure the medicine reaches the line you drew.

Looking at the diagram, you can see that a diagonal line like the one shown divides the rectangle into two. Since the rectangle makes up two fifths of the medicine, halving it gives you just the right amount!"',25,14,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,23,'Tap Answer','"This note contains instructions for disarming the traps in the door!

""One of the four buttons, A, B, C or D, disarms the traps. To find out which one it is, trace a path from the centre square, going horizontally or vertically from square to square in the order red, blue, yellow until you reach the correct button. You cannot pass through the same square twice.""

Touch the correct button, A to D."','Multiple of','#1','"Well done!

Button A on the top-left is the one that disarms the traps.

Now you can open the door!"',40,9,3,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,24,'Select and Submit','"Here''s a strange construction site. You have to inspect every ladder and girder, starting from the arrow and passing through points A, B, C and D in order.

You never take the same route twice, except to pass over or under a ladder. In what order do you use the white ladders?

Drag the numbered ladders over the white ladders to indicate their order."','Multiple of','#1','"That''s right!

No matter which route you take, the three ladders get used in the same order.

These routes may seem inefficient, but no matter which one you take, since you can''t go the same way twice, the distance travelled is the same."',30,7,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,25,'Multiple Choice','Three of the four images shown below are exactly the same picture rotated in a variety of ways. Can you find the odd one out?','Multiple of','#1','"Good job!

This puzzle is fairly straightforward, but catching the subtle difference in the picture can take a while."',30,18,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,26,'Write Answer','"The local museum has an exhibit that spans nine rooms, as shown in the diagram below. The entrance to the complex is marked by A, and the exit is marked by B.

The security guard on duty is a bit of a loafer and wants to walk each room of the exhibit while turning as few times as possible. What is the fewest number of turns he can make while still visiting every room?

As an example, the diagram below shows a course that involves six turns."','Multiple of','#1','It''s easy to be influenced by the fact that the example path shows the guard turning right angles to go from room to room, but you don''t need to follow that example!',30,18,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,27,'Circle Answer','"Lost in an unfamiliar town, you ask a passer-by for directions to the clock tower. He helpfully tells you:

""Go straight from here, then turn left at the first corner, turn right at the next corner, then turn left at the next corner it''ll be in front of you.""

Assuming that you start from somewhere on the map below, where is the clock tower? Circle a letter, A-H."','Multiple of','#1','"That''s right!

H marks the location of the clock tower.

You were standing at A and facing D when the passer-by gave you the directions."',25,18,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,28,'Mark Answer','"Chelmey sent his squad out to investigate an incident. Before leaving, he said this:
""I want you to search the entire area shown on this map. Take any route you want, but report how many times you turned in the process. You''re free to turn left or right, but U-turns are strictly forbidden!""

The bobbies completed their shift and returned to report their turns. Judging by their reports, though, it seems at least one man was loafing on the job. Touch the numbers you think are suspicious to mark them with an X."','Multiple of','#1','"The two men who took 105 and 113 turns must have been slacking off. Since the men started out on a horizontal path, you can infer that if they turned an odd number of times, they''d end up on a vertical path. Conversely, if they made an even number of turns, they''d end up on a horizontal road.

Any bobby who did his job properly would have to turn an even number of times to get back to the station, which is at the end of a horizontal road."',50,13,1,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,29,'Draw Line','"Barton needs to park his police car in the space indicated by the flag. When he encounters a cross, he has to turn left or right. When he meets a circle, he must keep going straight.

Assuming he''s not allowed to reverse the car, which route does Barton need to take in order to reach the parking space?

Draw a line from the police car to the parking space. As you can see, the parking space can only be entered from one side."','Multiple of','#1','"Barton has to go all the way around the parking space in order to get there.

Though you showed him the route he needed to take, all those turns seem to have confused Barton. He''s written off the police car and the inspector''s not happy!"',15,13,2,NULL);

INSERT INTO Layton.Puzzle (puzzleAsset,articleSubjectId,inputType,puzzleText,SolutionOptions,Solution,solutionText,picarats,givenById,solvedById,madeByid) VALUES (NULL,30,'Write Answer','"Four police officers, A, B, C and D, are chasing a criminal across a river. However, their boat only holds two people, so they can''t all cross at once.

It takes one minute for a police officer to row across, but after the first crossing he gets tired, so the second crossing takes two minutes, the third crossing takes three minutes, and so on.

What is the minimum number of minutes it would take for all four officers to cross the river?"','Multiple of','#1','"That''s right!

Six minutes. A and B go over on the first crossing, with A rowing. B rows the boat back. C then joins B in the boat and C rows across. A, B and C are now on the opposite side.
One of them needs to row back, but they have all rowed across the river once, so it doesn''t make any difference who goes. Once one of them has rowed back, D gets in and rows to the other side.
It therefore takes six minutes to get everyone across."',30,13,2,NULL);

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (1,1,'"This puzzle might look like a big mess at first, but it''s fairly simple when all is said and done.

Take E, for example, who says everyone is lying. If she is actually telling the truth, then her statement becomes a lie, and she must be ruled out. Yep, E''s a liar for sure."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (1,2,'"Let''s rule out another couple of suspects.

If A''s statement is true, then three other people should be saying the same thing as A. This is not the case, so A is a liar.

If B is telling the truth, two other suspects should say the same thing as B. Once again, this is not the case, so B must be lying."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (1,3,'"So, to sum things up, so far we''ve proven that A, B, and E are lying. Let''s examine the last two suspects.

If three people are lying, the other two suspects should have the same statement, but everyone is saying something different. On the other hand, if four of the five suspects are lying..."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (2,1,'"Here''s a little pearl of gumshoe wisdom.
The best way to understand something isn''t to study it intently from one perspective. Instead, try to approach the problem from a variety of angles."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (2,2,'"When you feel like you''ve seen all there is about a case, sometimes upending everything can give you a new view on matters.
Have you ever considered upending your DS?"');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (2,3,'"Hold your DS upside down and take another look at the note.
Do you notice anything about the note now?"');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (3,1,'"Had the shoe salesman not gone next door to get change, he might never have realised he lost money.

How much would he have lost if he had the change in the till?"');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (3,2,'"Since he used a fake note, the change the salesman got from next door was essentially ""money for nothing"". He gained �50.

In returning the money, he later lost �50."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (3,3,'The sneaky customer ended up getting away with shoes costing �30, as well as �20 in change.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (4,1,'The inspector says he took one turn at a junction with a cafe, but that doesn''t mean he had to turn in the direction of the cafe he saw. Instead, what he''s essentially saying here is that he was only able to turn once at any junction facing a cafe.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (4,2,'Begin by heading right from the starting point.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (4,3,'When you reach the goal, you''ll be coming at it from the left.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (5,1,'"Take a good look in all directions. You''re looking for something suspicious.

Dr Schrader''s flat is certainly full of all kinds of strange and rare objects, but ""strange and rare"" isn''t the same thing as ""suspicious""."');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (5,2,'The parts of the flat that the professor and Inspector Chelmey are in do not contain what you''re looking for.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (5,3,'The suspicious detail concerns one of a pair of objects.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (6,1,'Don''t jump to conclusions. Carefully consider all the options.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (6,2,'C looks completely wrong');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (6,3,'A fingerprint is actually a mirror image of the finger itself.');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (6,4,'"The answer is either A or B.

Remember Hint 3?"');

INSERT INTO Layton.Hint (puzzleId,hintIndex,hintText) VALUES (7,1,'An arrow has been drawn somewhere, and it''s easy to spot. Look carefully.');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Sir Dark Hat');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Professor');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Layton');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'The Puzzle Professor');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Mr Long Head');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Inquisitor Layton');

INSERT INTO Layton.Alias (characterId,alias) VALUES (1,'Daddy');

INSERT INTO Layton.Alias (characterId,alias) VALUES (2,'Little Luke');

INSERT INTO Layton.Alias (characterId,alias) VALUES (2,'Fluke');

INSERT INTO Layton.Alias (characterId,alias) VALUES (5,'Chelms');

INSERT INTO Layton.Alias (characterId,alias) VALUES (9,'Future Luke');

INSERT INTO Layton.Alias (characterId,alias) VALUES (9,'Big Luke');

INSERT INTO Layton.Alias (characterId,alias) VALUES (9,'Klaus');

INSERT INTO Layton.Alias (characterId,alias) VALUES (9,'Slightly Bigger Blue One');

INSERT INTO Layton.Alias (characterId,alias) VALUES (8,'The vampire');

INSERT INTO Layton.Alias (characterId,alias) VALUES (8,'The duke of Folsense');

INSERT INTO Layton.Alias (characterId,alias) VALUES (10,'Hershel Bronev');

INSERT INTO Layton.Alias (characterId,alias) VALUES (11,'Uncle Leon');

INSERT INTO Layton.Alias (characterId,alias) VALUES (15,'Elizabeth');

INSERT INTO Layton.Alias (characterId,alias) VALUES (18,'Stachen');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Father');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Mother');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Sibling');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Partner');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Child');

INSERT INTO Layton.Relationtype ([name]) VALUES ('Family');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Girlfriend');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Friend');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Apprentice');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Mentor');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Boss');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Rival');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Student');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Pet');

INSERT INTO Layton.Relationtype ([name]) VALUES ('a Companion');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Uncle');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Aunt');

INSERT INTO Layton.Relationtype ([name]) VALUES ('an Assistant');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Brother');

INSERT INTO Layton.Relationtype ([name]) VALUES ('the Sister');

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,2,10);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (2,1,18);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,4,11);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (4,1,18);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (4,2,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (2,4,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,5,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (5,1,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,7,12);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (7,1,12);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (5,13,11);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (13,5,18);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,3,1);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (3,1,5);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (2,3,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (3,2,8);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (1,14,11);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (14,1,18);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (2,9,12);

INSERT INTO Layton.Relation (character1,character2,relationtype) VALUES (9,2,12);

Go

